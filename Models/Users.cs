using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace NetChatApp.Models
{
    public class User 
    {
        public string Id {get; set;}
        public string Name {get; set;}
        [JsonPropertyName("ProfileImg")]
        public string ProfileImage {get; set;}

        public override string ToString() => JsonSerializer.Serialize<User>(this);
    }
}