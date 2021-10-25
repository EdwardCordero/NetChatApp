using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace NetChatApp.Models
{
    public class Chats 
    {
        public DateTime date {get; set;}
        public string chat {get; set;}
        public string sender{get; set;}

        public string reciver{get;set;} 

        public override string ToString() => JsonSerializer.Serialize<Chats>(this);
    }
}