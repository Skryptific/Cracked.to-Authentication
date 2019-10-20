using Newtonsoft.Json;

namespace Cracked_to_Authentication
{
    public class Response
    {
        [JsonProperty("auth")]
        public bool Auth { get; set; }

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
