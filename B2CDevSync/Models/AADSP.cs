using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B2CDevSync.Models
{
    public class SPList
    {
        [JsonProperty(PropertyName = "@odata.context")]
        public string Context { get; set; }

        [JsonProperty(PropertyName = "value")]
        public IEnumerable<AADSPResponse> Items { get; set; }
    }

    /// <summary>
    /// OAuth2Permissions is defined in the model, but it's rejected on POST
    /// </summary>
    public class AADSPResponse : AADSP
    {
        [JsonProperty(PropertyName = "oauth2Permissions")]
        public List<OAuth2Permission> OAuth2Permissions { get; set; }
    }

    public class AADSP
    {
        [JsonProperty(PropertyName = "accountEnabled")]
        public bool AccountEnabled { get; set; }

        [JsonProperty(PropertyName = "appDisplayName")]
        public string AppDisplayName { get; set; }

        [JsonProperty(PropertyName = "appId")]
        public string AppId { get; set; }

        [JsonProperty(PropertyName = "appOwnerOrganizationId")]
        public string AppOwnerOrganizationId { get; set; }

        [JsonProperty(PropertyName = "appRoleAssignmentRequired")]
        public bool AppRoleAssignmentRequired { get; set; }

        [JsonProperty(PropertyName = "displayName")]
        public string DisplayName { get; set; }

        [JsonProperty(PropertyName = "errorUrl")]
        public string ErrorUrl { get; set; }

        [JsonProperty(PropertyName = "homepage")]
        public string Homepage { get; set; }

        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "keyCredentials")]
        public List<KeyCredential> KeyCredentials { get; set; }

        [JsonProperty(PropertyName = "logoutUrl")]
        public string LogoutUrl { get; set; }

        [JsonProperty(PropertyName = "passwordCredentials")]
        public List<PasswordCredential> PasswordCredentials { get; set; }

        [JsonProperty(PropertyName = "preferredTokenSigningKeyThumbprint")]
        public string PreferredTokenSigningKeyThumbprint { get; set; }

        [JsonProperty(PropertyName = "publisherName")]
        public string PublisherName { get; set; }

        [JsonProperty(PropertyName = "replyUrls")]
        public List<string> ReplyUrls { get; set; }

        [JsonProperty(PropertyName = "samlMetadataUrl")]
        public string SamlMetadataUrl { get; set; }

        [JsonProperty(PropertyName = "servicePrincipalNames")]
        public List<string> ServicePrincipalNames { get; set; }

        [JsonProperty(PropertyName = "tags")]
        public List<string> Tags { get; set; }

        [JsonProperty(PropertyName = "appRoles")]
        public List<AppRole> AppRoles { get; set; }

        public AADSP()
        {
            AppRoles = new List<AppRole>();
            Tags = new List<string>();
            ServicePrincipalNames = new List<string>();
            ReplyUrls = new List<string>();
            PasswordCredentials = new List<PasswordCredential>();
            KeyCredentials = new List<KeyCredential>();
        }
    }

    public class OAuth2Permission
    {
        [JsonProperty(PropertyName = "adminConsentDescription")]
        public string AdminConsentDescription { get; set; }

        [JsonProperty(PropertyName = "adminConsentDisplayName")]
        public string AdminConsentDisplayName { get; set; }

        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "isEnabled")]
        public bool IsEnabled { get; set; }

        //[JsonProperty(PropertyName = "origin")]
        //public string Origin { get; set; }

        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }

        [JsonProperty(PropertyName = "userConsentDescription")]
        public string UserConsentDescription { get; set; }

        [JsonProperty(PropertyName = "userConsentDisplayName")]
        public string UserConsentDisplayName { get; set; }

        [JsonProperty(PropertyName = "value")]
        public string Value { get; set; }
    }

    public class AppRole
    {
        [JsonProperty(PropertyName = "allowedMemberTypes")]
        public List<string> AllowedMemberTypes { get; set; }

        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "displayName")]
        public string DisplayName { get; set; }

        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "idEnabled")]
        public string IsEnabled { get; set; }

        [JsonProperty(PropertyName = "origin")]
        public string Origin { get; set; }

        [JsonProperty(PropertyName = "value")]
        public string Value { get; set; }

        public AppRole()
        {
            AllowedMemberTypes = new List<string>();
        }
    }

    public class OAuth2PermissionGrants
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        /// <summary>
        /// ServicePrincipal ObjectId (set by ctor from passed-in AADSP object)
        /// </summary>
        [JsonProperty(PropertyName = "clientId")]
        public string ClientId { get; set; }

        /// <summary>
        /// "AllPrincipals" (set by ctor)
        /// </summary>
        [JsonProperty(PropertyName = "consentType")]
        public string ConsentType { get; set; }

        /// <summary>
        /// UTC Date (set by ctor) (currently ignored)
        /// </summary>
        [JsonProperty(PropertyName = "expiryTime")]
        public DateTimeOffset? ExpiryTime { get; set; }

        /// <summary>
        /// UTC Date (currently ignored)
        /// </summary>
        [JsonProperty(PropertyName = "startTime")]
        public DateTimeOffset? StartTime { get; set; }

        /// <summary>
        /// leave null
        /// </summary>
        [JsonProperty(PropertyName = "principalId")]
        public string PrincipalId { get; set; }

        /// <summary>
        /// Insert the Microsoft Graph API ServicePrincipal ObjectId
        /// (captured and set by ctor)
        /// </summary>
        [JsonProperty(PropertyName = "resourceId")]
        public string ResourceId { get; set; }
	    
        /// <summary>
        /// "openid offline_access" (set by ctor)
        /// </summary>
        [JsonProperty(PropertyName = "scope")]
        public string Scope { get; set; }

        public OAuth2PermissionGrants()
        {

        }
        public OAuth2PermissionGrants(AADSP servicePrincipal, string msGraphOID)
        {
            ClientId = servicePrincipal.Id;
            ConsentType = "AllPrincipals";
            ExpiryTime = new DateTimeOffset(DateTime.UtcNow.AddYears(2));
            ResourceId = msGraphOID;
            Scope = "openid offline_access";
        }
    }
}
