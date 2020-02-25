using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Props = B2CDevSync.Properties.Settings;

namespace B2CDevSync.Utils
{
    public class Auth
    {
        private readonly string _authority;
        private readonly TokenCache _cache;
        private readonly AuthenticationContext _context;
        private readonly string _clientId;
        private readonly string _redirectUri;
        private readonly string _tenant;
        private string _token;
        private DateTimeOffset _tokenExpiration;

        private readonly string _resource = "https://graph.microsoft.com";

        public string Token
        {
            get {
                if (_tokenExpiration < DateTime.Now)
                {
                    RefreshToken();
                }
                return _token;
            }

            private set
            {
                _token = value;
            }
        }

        public string ErrorMessage { get; set; }

        internal Auth(Props settings)
        {
            _clientId = settings.SyncAppId;
            _authority = settings.AADAuthority;
            _tenant = settings.B2CTenant;
            _redirectUri = settings.RedirectUri;
            _cache = new TokenCache();
            var auth = String.Format(_authority, _tenant);
            _context = new AuthenticationContext(auth, _cache);
        }

        public async Task<UserInfo> Login()
        {
            try
            {
                //var redirectUri = "urn:ietf:wg:oauth:2.0:oob";
                var authResult = await _context.AcquireTokenAsync(_resource, _clientId, new Uri(_redirectUri), new PlatformParameters(PromptBehavior.SelectAccount));
                return authResult.UserInfo;
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
                return null;
            }
        }

        public void Logout()
        {
            _context.TokenCache.Clear();

        }

        private void RefreshToken()
        {
            try
            {
                var res = _context.AcquireTokenSilentAsync(_resource, _clientId).Result;
                _token = res.AccessToken;
                _tokenExpiration = res.ExpiresOn;
            }
            catch (Exception ex)
            {
                _token = null;
                ErrorMessage = ex.Message;
            }
        }
    }
}
