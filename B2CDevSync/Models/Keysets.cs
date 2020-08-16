using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B2CDevSync.Models
{
    /// <summary>
    /// {
    ///     "@odata.context":"https://graph.microsoft.com/beta/trustFramework/keySets",
    ///     "value":[{"id":"B2C_1A_PasswordReset"},{"id":"B2C_1A_ProfileEdit"},{"id":"B2C_1A_SignUpOrSignInAAD"},{"id":"B2C_1A_signup_signin"},{"id":"B2C_1A_TrustFrameworkBase"},{"id":"B2C_1A_TrustFrameworkExtensions"}]
    /// }
    /// </summary>
    public class KeysetList
    {
        [JsonProperty(PropertyName = "@odata.context")]
        public string Context { get; set; }

        [JsonProperty(PropertyName = "value")]
        public IEnumerable<TFKeyset> Items { get; set; }
    }

    public class TFKeyset
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "keys")]
        public IList<TFKey> Keys { get; set; }
    }

    public class TFKeyGen
    {
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty(PropertyName = "use")]
        public TFKeyUse Use { get; set; }

        /// <summary>
        /// The "kty" (key type) parameter identifies the cryptographic algorithm family used with the key, The valid values are rsa, oct.
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty(PropertyName = "kty")]
        public TFKeyKty Kty { get; set; }

        /// <summary>
        /// Symmetric Key for oct key type. This is the field that is used to send the secret. Field cannot be read back.
        /// </summary>
        [JsonProperty(PropertyName = "k")]
        public string K { get; set; }

        /// <summary>
        /// The nbf (not before) claim identifies the time before which the JWT MUST NOT be accepted for processing. 
        /// The processing of the nbf claim requires that the current date/time MUST be after or equal to the 
        /// not-before date/time listed in the nbf claim.
        /// NumericDate, RFC 7519 (Unix epoch time)
        /// </summary>
        [JsonProperty(PropertyName = "nbf")]
        public long? Nbf { get; set; }

        /// <summary>
        /// NumericDate, RFC 7519 (Unix epoch time)
        /// </summary>
        [JsonProperty(PropertyName = "exp")]
        public long? Exp { get; set; }
    }

    /// <summary>
    /// The "use" (public key use) parameter identifies the intended use of the public key. 
    /// The "use" parameter is employed to indicate whether a public key is used for encrypting data or 
    /// verifying the signature on data. Possible values are 1. "sig" (signature) 2. "enc" (encryption)
    /// </summary>
    public enum TFKeyUse
    {
        sig,
        enc
    }

    /// <summary>
    /// The "kty" (key type) parameter identifies the cryptographic algorithm family used with the key
    /// </summary>
    public enum TFKeyKty
    {
        rsa,
        oct
    }

    public class TFKey
    {
        [JsonProperty(PropertyName = "x5c")]
        public string[] X5c { get; set; }

        [JsonProperty(PropertyName = "kid")]
        public string Kid { get; set; }

        [JsonProperty(PropertyName = "kty")]
        public string Kty { get; set; }

        [JsonProperty(PropertyName = "use")]
        public string Use { get; set; }

        [JsonProperty(PropertyName = "e")]
        public string E { get; set; }

        [JsonProperty(PropertyName = "d")]
        public string D { get; set; }

        [JsonProperty(PropertyName = "n")]
        public string N { get; set; }

        [JsonProperty(PropertyName = "p")]
        public string P { get; set; }

        [JsonProperty(PropertyName = "q")]
        public string Q { get; set; }

        [JsonProperty(PropertyName = "dp")]
        public string Dp { get; set; }

        [JsonProperty(PropertyName = "dq")]
        public string Dq { get; set; }

        [JsonProperty(PropertyName = "qi")]
        public string Qi { get; set; }

        [JsonProperty(PropertyName = "k")]
        public string K { get; set; }

        [JsonProperty(PropertyName = "nbf")]
        public long? Nbf { get; set; }

        [JsonProperty(PropertyName = "exp")]
        public long? Exp { get; set; }
    }
}
