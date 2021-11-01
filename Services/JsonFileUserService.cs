using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using Microsoft.AspNetCore.Hosting;
using NetChatApp.Models;
using NetChatApp.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using System.Data;

namespace NetChatApp.Services
{
    public class JsonFileUserService
    {
        public string searchedUserString;
        public User searchedUser;

        private readonly MyDbContext _dbContext;
        private readonly UserManager<UserEntity> _userManager;
        private readonly IHttpContextAccessor _contextAccessor;

        // get wwwroot location since it may be different in other devices
        public IWebHostEnvironment WebHostEnvironment {get; }
        public JsonFileUserService(IWebHostEnvironment webHostEnvironment, UserManager<UserEntity> userManager, MyDbContext dbContext, IHttpContextAccessor contextAccessor)
        {
            WebHostEnvironment = webHostEnvironment;
            _userManager = userManager;
            _dbContext = dbContext;
            _contextAccessor = contextAccessor;
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

        public string GetUserID()
        {
            var CurrentUser =  _contextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            return CurrentUser;
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

        public IEnumerable<UserEntity> GetChatUsers(string SignedInUserId)
        {
            var CurrentUser = _dbContext.User.First(u => u.Id == SignedInUserId);
            var ChatingWithUser = _dbContext.UserChats.Where(c =>  c.User == CurrentUser).Select(c => c.ChatingWithId);
            return ChatingWithUser;
        }

        public IEnumerable<UserEntity> GetChatUsers_Reciver(string SignedInUserId)
        {
            var CurrentUser = _dbContext.User.First(u => u.Id == SignedInUserId);
            var ChatingWithUser = _dbContext.UserChats.Where(c => c.ChatingWithId == CurrentUser).Select(c => c.User);
            return ChatingWithUser;
        }

        public IEnumerable<ChatEntity> GetChats(string ChattingWithID, string SignedInUserId)
        {
            if(string.IsNullOrWhiteSpace(ChattingWithID))
            {
                return null;
            }
            // Get all chats in ChatEntity table with matching Ids
            Console.WriteLine("Finding chats");
            var chats = _dbContext.ChatEntities.OrderByDescending(d => d.Date).Where(c => c.SenderId == SignedInUserId && c.ReciverId == ChattingWithID || c.SenderId == ChattingWithID && c.ReciverId == SignedInUserId);
            // If there are no rows then return
            if(chats == null)
            {
                Console.WriteLine("No chats founds");
                return null;
            }
            // else return row chats
            return chats;
        }

        public bool CheckForChat(string chatingWithId, string signedInUserId)
        {
            var SignedUserToFriend = _dbContext.UserChats.Any(c => c.User.Id.Equals((signedInUserId)) && c.ChatingWithId.Id.Equals(chatingWithId));
            var FriendTOSignedUser = _dbContext.UserChats.Any(c => c.User.Id.Equals((chatingWithId)) && c.ChatingWithId.Id.Equals(signedInUserId));
            if(SignedUserToFriend)
            {
                return SignedUserToFriend;
            }
            if(FriendTOSignedUser)
            {
                return FriendTOSignedUser;
            }
            return SignedUserToFriend;
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

        public void AddChatToChats(string CurrentUserId, string ChatingWithId, string chatToAdd)
        {
            // At this point we know there is a chat to add to and both Ids are not empty and the chat is not empty
            // only thing we need to check for is if the chats inside the row of UserChatEntity is empty (We might not need to check but keep it in mind)
            var chat = new ChatEntity{
                ChatText = chatToAdd,
                SenderId = CurrentUserId,
                ReciverId = ChatingWithId,
                Date = DateTime.Now
            };
            _dbContext.Add<ChatEntity>(chat);
            _dbContext.SaveChanges();
        }

        public void CreateUserChats(string ChatingWithId, string CurrentUserId)
        {
            var CurrentUser = _dbContext.User.First(u => u.Id == CurrentUserId);
            var ChattingWithUser = _dbContext.User.First(u => u.Id == ChatingWithId);
            var UserChat = new UserChatsEntity{
                User = CurrentUser,
                ChatingWithId = ChattingWithUser,
            };
            _dbContext.Add<UserChatsEntity>(UserChat);
            _dbContext.SaveChanges();
        }
    }
}
