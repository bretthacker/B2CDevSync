using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Linq;
using System.Text;
using B2CDevSync.Models;
using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Windows.Forms;
using System.Net.Http.Formatting;
using System.Xml;
using B2CDevSync.Properties;

namespace B2CDevSync.Utils
{
    public class B2CPolicies: IDisposable
    {
        public event EventHandler<FileCopyEventArgs> FileActivityMessage;
        public event EventHandler<PolicyErrorArgs> PolicyErrorMessage;
        public string ZipPath;
        public string LastError;

        protected virtual void RaisePolicyError(PolicyErrorArgs e)
        {
            PolicyErrorMessage?.Invoke(this, e);
        }

        protected virtual void RaiseFileActivity(FileCopyEventArgs e)
        {
            FileActivityMessage?.Invoke(this, e);
        }

        const string starterPackRepo = "https://github.com/Azure-Samples/active-directory-b2c-custom-policy-starterpack/archive/master.zip";
        const string baseFolder = "active-directory-b2c-custom-policy-starterpack-master";
        private string _graphUrlBase;
        private static HttpClient _web;

        public B2CPolicies(string apiBase)
        {
            _graphUrlBase = apiBase;
            _web = new HttpClient();
            _web.Timeout = TimeSpan.FromMinutes(5);
            ZipPath = Path.Combine(Environment.CurrentDirectory, "StarterPackRepo", "master.zip");
        }

        public void RefreshToken(string token)
        {
            _web.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }

        public async Task RefreshStarterpack(IProgress<int> fileProgress)
        {
            // Create a file stream to store the downloaded data.
            // This really can be any type of writeable stream.
            using (var file = new FileStream(ZipPath, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                await _web.DownloadAsync(starterPackRepo, file, fileProgress);
            }

            using (ZipArchive archive = ZipFile.OpenRead(ZipPath))
            {
                float totalEntries = archive.Entries.Count;
                var currCount = 0;
                foreach (ZipArchiveEntry entry in archive.Entries)
                {
                    var fullpath = Path.Combine(Environment.CurrentDirectory, "StarterPackRepo", entry.FullName);
                    if (entry.Length == 0)
                    {
                        if (Directory.Exists(fullpath) && currCount==0)
                        {
                            //root directory, wipe it out so we can restart
                            Directory.Delete(fullpath, true);
                        }
                        Directory.CreateDirectory(fullpath);
                    } 
                    else
                    {
                        entry.ExtractToFile(fullpath);
                    }
                    currCount++;
                }
            }
        }

        public async Task<string> GetProfileAsync(string id)
        {
            try
            {
                var url = String.Format(_graphUrlBase, id + "/$value");
                HttpResponseMessage rm;
                rm = await _web.GetAsync(url);
                if (rm.Content != null)
                {
                    var res = await rm.Content.ReadAsStringAsync();
                    if (!rm.IsSuccessStatusCode)
                    {
                        var err = JsonConvert.DeserializeObject<GraphError>(res);
                        Logging.WriteToAppLog("Error creating application: " + err.Error.Message, EventLogEntryType.Error);
                        return null;
                    }
                    var body = await rm.Content.ReadAsStringAsync();
                    return body;
                }
                else
                {
                    LastError = "No content was returned";
                    return null;
                }
            }
            catch (Exception ex)
            {
                Logging.WriteToAppLog("Error getting B2C policy", EventLogEntryType.Error, ex);
                LastError = "Error getting B2C policy: " + ex.Message;
                return null;
            }
        }

        public async Task<IList<PolicyItem>> GetListAsync()
        {
            try
            {
                HttpResponseMessage rm;
                rm = await _web.GetAsync("https://graph.microsoft.com/beta/trustFramework/policies");
                if (!rm.IsSuccessStatusCode)
                {
                    return null;
                }

                var res = await rm.Content.ReadAsStringAsync();
                var obj = JsonConvert.DeserializeObject<PolicyItemList>(res);
                return obj.Items.ToList();
            }
            catch (Exception ex)
            {
                Logging.WriteToAppLog("Error getting B2C policy", EventLogEntryType.Error, ex);
                return null;
            }
        }

        public async Task<TFKeyset> CreateKeyset(string id)
        {
            try
            {
                var ks = new TFKeyset
                {
                    Id = id
                };

                HttpResponseMessage rm;
                var formatter = new JsonMediaTypeFormatter();
                formatter.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
                HttpContent data = new ObjectContent<TFKeyset>(ks, formatter);

                rm = await _web.PostAsync("https://graph.microsoft.com/beta/trustFramework/keySets", data);
                if (rm.Content != null)
                {
                    var res = await rm.Content.ReadAsStringAsync();
                    if (!rm.IsSuccessStatusCode)
                    {
                        var err = JsonConvert.DeserializeObject<GraphError>(res);
                        var msg = "Error creating keyset: " + err.Error.Message;
                        Logging.WriteToAppLog(msg, EventLogEntryType.Error);
                        LastError = msg;
                        return null;
                    }

                    var obj = JsonConvert.DeserializeObject<TFKeyset>(res);
                    return obj;
                }
                else
                {
                    LastError = "No content was returned";
                    return null;
                }
            }
            catch (Exception ex)
            {
                Logging.WriteToAppLog("Error creating keyset", EventLogEntryType.Error, ex);
                LastError = "Error creating keyset: " + ex.Message;
                return null;
            }
        }

        public async Task<TFKey> GenerateKey(TFKeyset keyset, TFKeyKty kty, TFKeyUse use, DateTimeOffset? activationDate = null, DateTimeOffset? expiryDate = null)
        {
            try
            {
                var gen = new TFKeyGen
                {
                    Use = use,
                    Kty = kty
                };

                if (activationDate != null)
                {
                    //1000 ms x 60 seconds * 5 minutes
                    long fiveMinutes = 1000 * 60 * 5;
                    gen.Nbf = activationDate.Value.ToUnixTimeSeconds() - fiveMinutes;
                }
                if (expiryDate != null)
                {
                    //1000 ms x 60 seconds * 60 minutes * 24 hours * 365 days
                    long twoYears = (long)1000 * 60 * 60 * 24 * 365 * 2;
                    gen.Exp = expiryDate.Value.ToUnixTimeSeconds() + twoYears;
                }

                HttpResponseMessage rm;
                var formatter = new JsonMediaTypeFormatter();
                formatter.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
                HttpContent data = new ObjectContent<TFKeyGen>(gen, formatter);

                var url = string.Format("https://graph.microsoft.com/beta/trustFramework/keySets/{0}/generateKey", keyset.Id);
                rm = await _web.PostAsync(url, data);
                if (rm.Content != null)
                {
                    var res = await rm.Content.ReadAsStringAsync();
                    if (!rm.IsSuccessStatusCode)
                    {
                        var err = JsonConvert.DeserializeObject<GraphError>(res);
                        var msg = "Error generating key: " + err.Error.Message;
                        Logging.WriteToAppLog(msg, EventLogEntryType.Error);
                        LastError = msg;
                        return null;
                    }

                    var obj = JsonConvert.DeserializeObject<TFKey>(res);
                    return obj;
                }
                else
                {
                    LastError = "No content was returned";
                    return null;
                }
            }
            catch (Exception ex)
            {
                Logging.WriteToAppLog("Error creating application", EventLogEntryType.Error, ex);
                LastError = "Error creating application: " + ex.Message;
                return null;
            }
        }

        public async Task<TFKey> UploadKeysetSecret(TFKeyset keySet, string secret, TFKeyUse use, DateTimeOffset? activationDate = null, DateTimeOffset? expiryDate = null)
        {
            try
            {
                var gen = new TFKeyGen
                {
                    Use = use,
                    K = secret,
                    Kty = TFKeyKty.oct
                };
                if (activationDate != null)
                {
                    //1000 ms x 60 seconds * 5 minutes
                    long fiveMinutes = 1000 * 60 * 5;
                    gen.Nbf = activationDate.Value.ToUnixTimeSeconds() - fiveMinutes;
                }
                if (expiryDate != null)
                {
                    //1000 ms x 60 seconds * 60 minutes * 24 hours * 365 days
                    long twoYears = (long)1000 * 60 * 60 * 24 * 365 * 2;
                    gen.Exp = expiryDate.Value.ToUnixTimeSeconds() + twoYears;
                }

                HttpResponseMessage rm;
                var formatter = new JsonMediaTypeFormatter();
                formatter.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
                HttpContent data = new ObjectContent<TFKeyGen>(gen, formatter);

                var url = string.Format("https://graph.microsoft.com/beta/trustFramework/keySets/{0}/generateKey", keySet.Id);
                rm = await _web.PostAsync(url, data);
                if (rm.Content != null)
                {
                    var res = await rm.Content.ReadAsStringAsync();
                    if (!rm.IsSuccessStatusCode)
                    {
                        var err = JsonConvert.DeserializeObject<GraphError>(res);
                        var msg = "Error uploading secret: " + err.Error.Message;
                        Logging.WriteToAppLog(msg, EventLogEntryType.Error);
                        LastError = msg;
                        return null;
                    }

                    var obj = JsonConvert.DeserializeObject<TFKey>(res);
                    return obj;
                }
                else
                {
                    LastError = "No content was returned";
                    return null;
                }
            }
            catch (Exception ex)
            {
                Logging.WriteToAppLog("Error uploading secret", EventLogEntryType.Error, ex);
                LastError = "Error uploading secret: " + ex.Message;
                return null;
            }
        }

        public async Task DeleteKeyset(TFKeyset keyset)
        {
            try
            {
                HttpResponseMessage rm;
                rm = await _web.DeleteAsync(string.Format("https://graph.microsoft.com/beta/trustFramework/keySets/{0}", keyset.Id));

                if (rm.Content != null)
                {
                    var res = await rm.Content.ReadAsStringAsync();
                    if (!rm.IsSuccessStatusCode)
                    {
                        var err = JsonConvert.DeserializeObject<GraphError>(res);
                        var msg = "Error deleting keyset: " + err.Error.Message;
                        Logging.WriteToAppLog(msg, EventLogEntryType.Error);
                        LastError = msg;
                        return;
                    }

                }
                else
                {
                    LastError = "No content was returned";
                    return;
                }
            }
            catch (Exception ex)
            {
                Logging.WriteToAppLog("Error deleting keyset", EventLogEntryType.Error, ex);
                LastError = ex.Message;
            }
        }

        public async Task<IList<TFKeyset>> GetKeySetsAsync()
        {
            try
            {
                HttpResponseMessage rm;
                rm = await _web.GetAsync("https://graph.microsoft.com/beta/trustFramework/keySets");
                if (!rm.IsSuccessStatusCode)
                {
                    return null;
                }

                var res = await rm.Content.ReadAsStringAsync();
                var obj = JsonConvert.DeserializeObject<KeysetList>(res);
                return obj.Items.ToList();
            }
            catch (Exception ex)
            {
                Logging.WriteToAppLog("Error getting B2C policy", EventLogEntryType.Error, ex);
                return null;
            }
        }

        public async Task<string> UpsertAsync(string id, string xmlPolicyString)
        {
            try
            {
                var url = String.Format(_graphUrlBase, id + "/$value");
                var httpContent = new StringContent(xmlPolicyString, Encoding.UTF8, "application/xml");
                var rm = await _web.PutAsync(url, httpContent);
                if (!rm.IsSuccessStatusCode)
                {
                    var str = await rm.Content.ReadAsStringAsync();
                    var message = JsonConvert.DeserializeObject<GraphError>(str);
                    var ex = new Exception(message.Error.Message);
                    Logging.WriteToAppLog("Error upserting policy", EventLogEntryType.Error, ex);

                    RaisePolicyError(new PolicyErrorArgs
                    {
                        Error = message
                    });

                    return null;
                }
                RaiseFileActivity(new FileCopyEventArgs
                {
                    FilePath = id,
                    Action = FileAction.PolicyUploaded
                });
                return (rm.StatusCode == HttpStatusCode.OK) ? "updated" : "added";
            }
            catch (Exception ex)
            {
                Logging.WriteToAppLog("Error updating or adding B2C policy", EventLogEntryType.Error, ex);
                return null;
            }
        }

        public async Task<bool> DeleteAsync(string id)
        {
            try
            {
                var rm = await _web.DeleteAsync(string.Format("https://graph.microsoft.com/beta/trustFramework/policies/{0}", id));
                if (!rm.IsSuccessStatusCode)
                {
                    Logging.WriteToAppLog("Error deleting B2C policy", EventLogEntryType.Error, new Exception(await rm.Content.ReadAsStringAsync()));
                    return false;
                }
                RaiseFileActivity(new FileCopyEventArgs
                {
                    FilePath = id,
                    Action = FileAction.PolicyDeleted
                }); return true;
            }
            catch (Exception ex)
            {
                Logging.WriteToAppLog("Error deleting B2C policy", EventLogEntryType.Error, ex);
                return false;
            }
        }

        public async Task ReadAndReplacePolicyTemplate(
            string newFolderPath, 
            string templateName, 
            string tenant, 
            string iefAppId, 
            string iefProxyAppId,
            string basePolicyName,
            string facebookAppId = null
        )
        {
            basePolicyName = string.Format("B2C_1A_{0}", basePolicyName);
            var templatePath = Path.Combine(Environment.CurrentDirectory, "StarterPackRepo", baseFolder, templateName);
            var folder = Directory.GetFiles(templatePath, "*.xml");

            var xDoc = new XmlDocument();
            XmlNamespaceManager nsmgr = new XmlNamespaceManager(xDoc.NameTable);
            nsmgr.AddNamespace("xmlns:xsi", "http://www.w3.org/2001/XMLSchema-instance");
            nsmgr.AddNamespace("xmlns:xsd", "http://www.w3.org/2001/XMLSchema");
            nsmgr.AddNamespace("cpim", "http://schemas.microsoft.com/online/cpim/schemas/2013/06");

            var filecoll = new Dictionary<string, string>();
            string basePol="", extPol = "", susiPol = "", profilePol = "", pwResetPol = "";

            //loop to set the policy names
            foreach (string filePath in folder)
            {
                var fileName = Path.GetFileName(filePath);
                switch (fileName)
                {
                    case "TrustFrameworkBase.xml":
                        basePol = string.Format("{0}Base", basePolicyName);
                        break;
                    case "TrustFrameworkExtensions.xml":
                        extPol = string.Format("{0}Extensions", basePolicyName);
                        break;
                    case "SignUpOrSignin.xml":
                        susiPol = string.Format("{0}SUSI", basePolicyName);
                        break;
                    case "ProfileEdit.xml":
                        profilePol = string.Format("{0}ProfileEdit", basePolicyName);
                        break;
                    case "PasswordReset.xml":
                        pwResetPol = string.Format("{0}PwReset", basePolicyName);
                        break;
                }
            }

            //loop again to update the values
            foreach (string filePath in folder)
            {
                var fileName = Path.GetFileName(filePath);
                var str = File.ReadAllText(filePath);
                //replace tenant in all files
                str = str.Replace("yourtenant", tenant);

                xDoc.LoadXml(str);
                XmlNode root = xDoc.DocumentElement;
                switch (fileName)
                {
                    case "TrustFrameworkBase.xml":
                        root.SelectSingleNode("/cpim:TrustFrameworkPolicy", nsmgr).Attributes["PolicyId"].Value = basePol;
                        root.SelectSingleNode("/cpim:TrustFrameworkPolicy", nsmgr).Attributes["TenantId"].Value = string.Format("{0}.onmicrosoft.com", tenant);
                        root.SelectSingleNode("/cpim:TrustFrameworkPolicy", nsmgr).Attributes["PublicPolicyUri"].Value = string.Format("http://{0}.onmicrosoft.com/{1}", tenant, basePol);
                        break;

                    case "TrustFrameworkExtensions.xml":
                        root.SelectSingleNode("/cpim:TrustFrameworkPolicy", nsmgr).Attributes["PolicyId"].Value = extPol;
                        root.SelectSingleNode("/cpim:TrustFrameworkPolicy", nsmgr).Attributes["TenantId"].Value = string.Format("{0}.onmicrosoft.com", tenant);
                        root.SelectSingleNode("/cpim:TrustFrameworkPolicy", nsmgr).Attributes["PublicPolicyUri"].Value = string.Format("http://{0}.onmicrosoft.com/{1}", tenant, extPol);
                        root.SelectSingleNode("/cpim:TrustFrameworkPolicy/cpim:BasePolicy/cpim:TenantId", nsmgr).InnerText = string.Format("{0}.onmicrosoft.com", tenant);
                        root.SelectSingleNode("/cpim:TrustFrameworkPolicy/cpim:BasePolicy/cpim:PolicyId", nsmgr).InnerText = basePol;

                        root.SelectSingleNode("//cpim:TechnicalProfile[@Id='login-NonInteractive']/cpim:Metadata/cpim:Item[@Key='client_id']", nsmgr).InnerText = iefProxyAppId;
                        root.SelectSingleNode("//cpim:TechnicalProfile[@Id='login-NonInteractive']/cpim:Metadata/cpim:Item[@Key='IdTokenAudience']", nsmgr).InnerText = iefAppId;

                        root.SelectSingleNode("//cpim:TechnicalProfile[@Id='login-NonInteractive']/cpim:InputClaims/cpim:InputClaim[@ClaimTypeReferenceId='client_id']", nsmgr).Attributes["DefaultValue"].Value = iefProxyAppId;
                        root.SelectSingleNode("//cpim:TechnicalProfile[@Id='login-NonInteractive']/cpim:InputClaims/cpim:InputClaim[@ClaimTypeReferenceId='resource_id']", nsmgr).Attributes["DefaultValue"].Value = iefAppId;

                        if (facebookAppId != null)
                        {
                            root.SelectSingleNode("//cpim:TechnicalProfile[@Id='Facebook-OAUTH']/cpim:Metadata/cpim:Item[@Key='client_id']", nsmgr).InnerText = facebookAppId;
                        }
                        break;

                    case "SignUpOrSignin.xml":
                        root.SelectSingleNode("/cpim:TrustFrameworkPolicy", nsmgr).Attributes["PolicyId"].Value = susiPol;
                        root.SelectSingleNode("/cpim:TrustFrameworkPolicy", nsmgr).Attributes["TenantId"].Value = string.Format("{0}.onmicrosoft.com", tenant);
                        root.SelectSingleNode("/cpim:TrustFrameworkPolicy", nsmgr).Attributes["PublicPolicyUri"].Value = string.Format("http://{0}.onmicrosoft.com/{1}", tenant, susiPol);
                        root.SelectSingleNode("/cpim:TrustFrameworkPolicy/cpim:BasePolicy/cpim:TenantId", nsmgr).InnerText = string.Format("{0}.onmicrosoft.com", tenant);
                        root.SelectSingleNode("/cpim:TrustFrameworkPolicy/cpim:BasePolicy/cpim:PolicyId", nsmgr).InnerText = extPol;
                        break;

                    case "ProfileEdit.xml":
                        root.SelectSingleNode("/cpim:TrustFrameworkPolicy", nsmgr).Attributes["PolicyId"].Value = profilePol;
                        root.SelectSingleNode("/cpim:TrustFrameworkPolicy", nsmgr).Attributes["TenantId"].Value = string.Format("{0}.onmicrosoft.com", tenant);
                        root.SelectSingleNode("/cpim:TrustFrameworkPolicy", nsmgr).Attributes["PublicPolicyUri"].Value = string.Format("http://{0}.onmicrosoft.com/{1}", tenant, profilePol);
                        root.SelectSingleNode("/cpim:TrustFrameworkPolicy/cpim:BasePolicy/cpim:TenantId", nsmgr).InnerText = string.Format("{0}.onmicrosoft.com", tenant);
                        root.SelectSingleNode("/cpim:TrustFrameworkPolicy/cpim:BasePolicy/cpim:PolicyId", nsmgr).InnerText = extPol;
                        break;

                    case "PasswordReset.xml":
                        root.SelectSingleNode("/cpim:TrustFrameworkPolicy", nsmgr).Attributes["PolicyId"].Value = pwResetPol;
                        root.SelectSingleNode("/cpim:TrustFrameworkPolicy", nsmgr).Attributes["TenantId"].Value = string.Format("{0}.onmicrosoft.com", tenant);
                        root.SelectSingleNode("/cpim:TrustFrameworkPolicy", nsmgr).Attributes["PublicPolicyUri"].Value = string.Format("http://{0}.onmicrosoft.com/{1}", tenant, pwResetPol);
                        root.SelectSingleNode("/cpim:TrustFrameworkPolicy/cpim:BasePolicy/cpim:TenantId", nsmgr).InnerText = string.Format("{0}.onmicrosoft.com", tenant);
                        root.SelectSingleNode("/cpim:TrustFrameworkPolicy/cpim:BasePolicy/cpim:PolicyId", nsmgr).InnerText = extPol;

                        break;
                }

                str = root.OuterXml;
                filecoll.Add(fileName, str);
            }

            //commit changes locally then sync to tenant, in this order
            File.WriteAllText(Path.Combine(newFolderPath, "TrustFrameworkBase.xml"), filecoll["TrustFrameworkBase.xml"]);
            await UpsertAsync(basePol, filecoll["TrustFrameworkBase.xml"]);

            File.WriteAllText(Path.Combine(newFolderPath, "TrustFrameworkExtensions.xml"), filecoll["TrustFrameworkExtensions.xml"]);
            await UpsertAsync(extPol, filecoll["TrustFrameworkExtensions.xml"]);

            File.WriteAllText(Path.Combine(newFolderPath, "SignUpOrSignin.xml"), filecoll["SignUpOrSignin.xml"]);
            await UpsertAsync(susiPol, filecoll["SignUpOrSignin.xml"]);

            File.WriteAllText(Path.Combine(newFolderPath, "ProfileEdit.xml"), filecoll["ProfileEdit.xml"]);
            await UpsertAsync(profilePol, filecoll["ProfileEdit.xml"]);

            if (filecoll["PasswordReset.xml"] != null)
            {
                File.WriteAllText(Path.Combine(newFolderPath, "PasswordReset.xml"), filecoll["PasswordReset.xml"]);
                await UpsertAsync(pwResetPol, filecoll["PasswordReset.xml"]);
            }
        }

        public void Dispose()
        {
            _web.Dispose();
            _web = null;
       }
    }

    public class PolicyErrorArgs: EventArgs
    {
        public GraphError Error { get; set; }
    }
}
