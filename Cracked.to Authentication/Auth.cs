using System;
using System.Net;
using System.Text;
using System.Collections.Specialized;
using Newtonsoft.Json;
using System.Management;
using Cracked.to_Authentication.Models;
using Cracked.to_Authentication.Utils;

namespace Cracked.to_Authentication
{
    public class Auth
    {
        private readonly HardwareId _hardwareId = new HardwareId();
        
        public LoginResponse Authenticate(string authKey, string group)
        {
            var loginResponse = new LoginResponse
            {
                IsAuthenticated = false
            };

            using (var client = new WebClient())
            {
                client.Proxy = null;
                var uri = new Uri("https://cracked.to/auth.php");
                var postQuery = new NameValueCollection
                {
                    {"a", "auth"},
                    {"k", authKey},
                    {"hwid", _hardwareId.getHardwareId()}
                };

                var responseString = Encoding.UTF8.GetString(client.UploadValues(uri, postQuery));

                loginResponse = JsonConvert.DeserializeObject<LoginResponse>(responseString);
            }

            return loginResponse;
        }
    }
}