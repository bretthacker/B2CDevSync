using B2CDevSync.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace B2CDevSync.Utils
{
    public class B2CApps
    {
        public string LastError;

        private static HttpClient _web;
        private static string _msGraphOid;

        public B2CApps()
        {
            _web = new HttpClient
            {
                Timeout = TimeSpan.FromMinutes(5)
            };
        }

        public void RefreshToken(string token)
        {
            _web.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

        }

        /// <summary>
        /// Work through steps to create a successful Azure AD B2C app registration
        /// </summary>
        /// <returns></returns>
        public async Task<App> CreateB2CApp(App app)
        {
            //Create the Application Object
            app = await CreateApp(app);

            //Create the Service Principal Object
            var sp = await CreateServicePrincipal(app);

            //Get MSGraph OID
            if (_msGraphOid == null)
            {
                _msGraphOid = await GetMSGraphSPOID();
            }

            //Create the Oauth2PermissionGrants
            var grants = await CreateOAuth2PermissionGrants(sp, _msGraphOid);

            //Generate an Application Key
            var appKey = await PatchApplicationKey(app);
            app.PasswordCredentials.Add(appKey);

            //Publish a Scope on your Application Registration
            //PublishApiScopes() is TBD

            //Assign your Application to a Permission
            //AssignPermission() is TBD

            return app;
        }

        //private async Task AssignPermission()
        //{
        //    throw new NotImplementedException();
        //}
        //private async Task PublishApiScopes()
        //{
        //    throw new NotImplementedException();
        //}

        private async Task<PasswordCredential> PatchApplicationKey(App app, DateTimeOffset? startDateTime = null, DateTimeOffset? endDateTime = null)
        {
            try
            {
                var grant = new PasswordCredential
                {
                    DisplayName = app.DisplayName
                };
                if (startDateTime != null)
                {
                    grant.StartDateTime = startDateTime;
                }
                if (endDateTime != null)
                {
                    grant.EndDateTime = endDateTime;
                }

                HttpResponseMessage rm;
                var formatter = new JsonMediaTypeFormatter();
                formatter.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
                HttpContent data = new ObjectContent<PasswordCredential>(grant, formatter);

                rm = await _web.PostAsync(string.Format("https://graph.microsoft.com/beta/applications/{0}/addPassword", app.Id), data);
                if (rm.Content != null)
                {
                    var res = await rm.Content.ReadAsStringAsync();
                    if (!rm.IsSuccessStatusCode)
                    {
                        var err = JsonConvert.DeserializeObject<GraphError>(res);
                        var msg = "Error creating application: " + err.Error.Message;
                        Logging.WriteToAppLog(msg, EventLogEntryType.Error);
                        LastError = msg;
                        return null;
                    }

                    var obj = JsonConvert.DeserializeObject<PasswordCredential>(res);
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
                Logging.WriteToAppLog("Error creating service principal", EventLogEntryType.Error, ex);
                LastError = "Error creating service principal: " + ex.Message;
                return null;
            }
        }
        private async Task<string> GetMSGraphSPOID()
        {
            try
            {
                var url = "https://graph.microsoft.com/beta/servicePrincipals?$filter=publisherName eq 'Microsoft Graph' or (displayName eq 'Microsoft Graph' or startswith(displayName,'Microsoft Graph'))";
                HttpResponseMessage rm;
                rm = await _web.GetAsync(url);
                if (!rm.IsSuccessStatusCode)
                {
                    return null;
                }

                var res = await rm.Content.ReadAsStringAsync();
                var obj = JsonConvert.DeserializeObject<SPList>(res);
                return obj.Items.Single().Id;
            }
            catch (Exception ex)
            {
                Logging.WriteToAppLog("Error getting B2C policy", EventLogEntryType.Error, ex);
                return null;
            }
        }

        public async Task<OAuth2PermissionGrants> CreateOAuth2PermissionGrants(AADSP appSP, string MSGraphOID)
        {
            try
            {
                var grant = new OAuth2PermissionGrants(appSP, MSGraphOID);

                HttpResponseMessage rm;
                var formatter = new JsonMediaTypeFormatter();
                formatter.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
                HttpContent data = new ObjectContent<OAuth2PermissionGrants>(grant, formatter);

                rm = await _web.PostAsync("https://graph.microsoft.com/beta/oauth2PermissionGrants", data);
                if (rm.Content != null)
                {
                    var res = await rm.Content.ReadAsStringAsync();
                    if (!rm.IsSuccessStatusCode)
                    {
                        var err = JsonConvert.DeserializeObject<GraphError>(res);
                        var msg = "Error creating application: " + err.Error.Message;
                        Logging.WriteToAppLog(msg, EventLogEntryType.Error);
                        LastError = msg;
                        return null;
                    }

                    var obj = JsonConvert.DeserializeObject<OAuth2PermissionGrants>(res);
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
                Logging.WriteToAppLog("Error creating service principal", EventLogEntryType.Error, ex);
                LastError = "Error creating service principal: " + ex.Message;
                return null;
            }
        }

        public async Task<AADSP> CreateServicePrincipal(App app)
        {
            try
            {
                var newSP = new AADSP
                {
                    AppId = app.AppId,
                    DisplayName = app.DisplayName,
                    ReplyUrls = app.Web.RedirectUris,
                    AccountEnabled = true
                };

                HttpResponseMessage rm;
                var formatter = new JsonMediaTypeFormatter();
                formatter.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
                HttpContent data = new ObjectContent<AADSP>(newSP, formatter);

                rm = await _web.PostAsync("https://graph.microsoft.com/beta/serviceprincipals", data);
                if (rm.Content != null)
                {
                    var res = await rm.Content.ReadAsStringAsync();
                    if (!rm.IsSuccessStatusCode)
                    {
                        var err = JsonConvert.DeserializeObject<GraphError>(res);
                        var msg = "Error creating application: " + err.Error.Message;
                        Logging.WriteToAppLog(msg, EventLogEntryType.Error);
                        LastError = msg;
                        return null;
                    }

                    var obj = JsonConvert.DeserializeObject<AADSPResponse>(res);
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
                Logging.WriteToAppLog("Error creating service principal", EventLogEntryType.Error, ex);
                LastError = "Error creating service principal: " + ex.Message;
                return null;
            }

        }

        /// <summary>
        /// Call MS Graph to create an app registration
        /// </summary>
        /// <param name="app"></param>
        /// <returns></returns>
        public async Task<App> CreateApp(App app)
        {
            try
            {
                HttpResponseMessage rm;
                var formatter = new JsonMediaTypeFormatter();
                formatter.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
                HttpContent data = new ObjectContent<App>(app, formatter);

                rm = await _web.PostAsync("https://graph.microsoft.com/beta/applications", data);
                if (rm.Content != null)
                {
                    var res = await rm.Content.ReadAsStringAsync();
                    if (!rm.IsSuccessStatusCode)
                    {
                        var err = JsonConvert.DeserializeObject<GraphError>(res);
                        var msg = "Error creating application: " + err.Error.Message;
                        Logging.WriteToAppLog(msg, EventLogEntryType.Error);
                        LastError = msg;
                        return null;
                    }

                    var obj = JsonConvert.DeserializeObject<App>(res);
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

        public async Task<IList<App>> GetAppListAsync()
        {
            try
            {
                HttpResponseMessage rm;
                rm = await _web.GetAsync("https://graph.microsoft.com/beta/applications");
                if (!rm.IsSuccessStatusCode)
                {
                    return null;
                }

                var res = await rm.Content.ReadAsStringAsync();
                var obj = JsonConvert.DeserializeObject<AppList>(res);
                return obj.Items.ToList();
            }
            catch (Exception ex)
            {
                Logging.WriteToAppLog("Error getting B2C policy", EventLogEntryType.Error, ex);
                return null;
            }
        }
    }
}
