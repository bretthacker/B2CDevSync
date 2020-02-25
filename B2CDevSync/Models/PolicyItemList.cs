using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace B2CDevSync.Models
{
    /// <summary>
    /// {
    ///     "@odata.context":"https://graph.microsoft.com/testcpimtf/$metadata#trustFrameworkPolicies",
    ///     "value":[{"id":"B2C_1A_PasswordReset"},{"id":"B2C_1A_ProfileEdit"},{"id":"B2C_1A_SignUpOrSignInAAD"},{"id":"B2C_1A_signup_signin"},{"id":"B2C_1A_TrustFrameworkBase"},{"id":"B2C_1A_TrustFrameworkExtensions"}]
    /// }
    /// </summary>
    public class PolicyItemList
    {
        [JsonProperty(PropertyName = "@odata.context")]
        public string Context { get; set; }

        [JsonProperty(PropertyName = "value")]
        public IEnumerable<PolicyItem> Items { get; set; }
    }
    public class PolicyItem
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }
    }
}
