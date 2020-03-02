using Newtonsoft.Json;

namespace Cracked.to_Authentication.Models
{
    public class LoginResponse
    {
        [JsonProperty("auth")]
        public bool IsAuthenticated { get; set; }
        
        [JsonProperty("username")]
        public string Username { get; set; }
        
        [JsonProperty("posts")]
        public string Posts { get; set; }
        
        [JsonProperty("likes")]
        public string Likes { get; set; }
        
        [JsonProperty("group")]
        public string Group { get; set; }
    }
}