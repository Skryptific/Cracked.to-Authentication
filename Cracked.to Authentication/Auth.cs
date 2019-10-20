using System;
using System.Net;
using System.Text;
using System.Collections.Specialized;
using Newtonsoft.Json;
using System.Management;

namespace Cracked_to_Authentication
{
    public class Auth
    {
        public bool Authenticate(string authKey, string group)
        {
            using (var client = new WebClient())
            {
                client.Proxy = null;

                var uri = new Uri("https://cracked.to/auth.php");

                var postData = new NameValueCollection
                {
                    { "a", "auth"},
                    { "k", authKey },
                    { "hwid", GetHWID() }
                };

                var responseString = Encoding.UTF8.GetString(client.UploadValues(uri, postData));

                if (!responseString.Contains("error"))
                {
                    var response = JsonConvert.DeserializeObject<Response>(responseString);

                    if (response.Auth && (response.Group == group || group == "-1")) // -1 stands for all groups.
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private string GetHWID()
        {
            var mbs = new ManagementObjectSearcher("Select ProcessorId From Win32_processor");
            ManagementObjectCollection mbsList = mbs.Get();

            var hwid = string.Empty;

            foreach (ManagementObject mo in mbsList)
            {
                hwid = mo["ProcessorId"].ToString();
                break;
            }

            return hwid;
        }
    }
}
