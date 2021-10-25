using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using Microsoft.AspNetCore.Hosting;
using NetChatApp.Models;

namespace NetChatApp.Services
{
    public class JsonFileUserService
    {
        public string searchedUserString;
        public User searchedUser;
        // get wwwroot location since it may be different in other devices
        public IWebHostEnvironment WebHostEnvironment {get; }
        public JsonFileUserService(IWebHostEnvironment webHostEnvironment)
        {
            WebHostEnvironment = webHostEnvironment;
        }

        // get file by starting at the webhost environment and combine its path with strings
        public string UsersListFileName
        {
            get{return Path.Combine(WebHostEnvironment.WebRootPath, "data", "users.json");}
        }

        public string ChatUsersFileName
        {
            get{return Path.Combine(WebHostEnvironment.WebRootPath, "data", "chats-users.json");}
        }

        public string ChatsFileName(string userID)
        {
            return Path.Combine(WebHostEnvironment.WebRootPath, "data", userID + "-chat-data.json");
        }

        // get all the users by IEnumberating through file same as foreach
        public IEnumerable<User> GetUsers()
        {
            using(var jsonFileReader = File.OpenText(UsersListFileName))
            {
                return JsonSerializer.Deserialize<User[]>(jsonFileReader.ReadToEnd(),
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });
            }
        }

        public void StartNewChat(string UserId)
        {
            using(var jsonFileReader = File.OpenText(UsersListFileName))
            {
                JsonSerializer.Serialize<string>(UserId);
            }
        }

        public IEnumerable<User> GetChatUsers()
        {
            using(var jsonFileReader = File.OpenText(ChatUsersFileName))
            {
                return JsonSerializer.Deserialize<User[]>(jsonFileReader.ReadToEnd(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
            }
        }

        public IEnumerable<Chats> GetChats(string userID)
        {
            Console.WriteLine("finding chats");
            using(var jsonFileReader = File.OpenText(ChatsFileName(userID)))
            {
                return JsonSerializer.Deserialize<Chats[]>(jsonFileReader.ReadToEnd(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
            }
        }

        public User FindUser(string UserString)
        {
            try
            {
                searchedUserString = UserString;
                searchedUser = GetUsers().First(x => x.Name == UserString);
            }
            catch(InvalidOperationException) {
                return searchedUser = null;
            }
            return searchedUser;
        }

        public void AddUserToChatList(User user)
        {
            
        }
    }
}
