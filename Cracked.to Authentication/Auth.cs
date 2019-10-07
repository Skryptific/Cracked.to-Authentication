using System;
using System.Net;
using System.Text;
using System.Collections.Specialized;
using Newtonsoft.Json;
using System.Management;

namespace Cracked.to_Authentication
{
    public class Auth
    {
        public bool Authenticate(string authKey, string group) 
        {
            using (WebClient client = new WebClient())
            {
                client.Proxy = null;
                Uri uri = new Uri("https://cracked.to/auth.php");
                NameValueCollection postData = new NameValueCollection() {
                    { "a", "auth"},
                    { "k", authKey },
                    { "hwid", getHWID() }
                };

                string responseString = Encoding.UTF8.GetString(client.UploadValues(uri, postData));
                if (!responseString.Contains("error"))
                {
                    Response response = JsonConvert.DeserializeObject<Response>(responseString);
                    if (response.auth == true && (response.group == group || group == "-1")) // -1 stands for all groups.
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private string getHWID()
        {
            ManagementObjectSearcher mbs = new ManagementObjectSearcher("Select ProcessorId From Win32_processor");
            ManagementObjectCollection mbsList = mbs.Get();

            string hwid = "";
            foreach (ManagementObject mo in mbsList)
            {
                hwid = mo["ProcessorId"].ToString();
                break;
            }

            return hwid;
        }
    }
}
