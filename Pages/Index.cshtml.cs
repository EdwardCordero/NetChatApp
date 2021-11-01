using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using NetChatApp.Areas.Identity.Data;
using NetChatApp.Models;
using NetChatApp.Services;

namespace NetChatApp.Pages
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public JsonFileUserService UserService;
        public IEnumerable<User> Users {get; private set;}

        [BindProperty]
        public string specificUser { get; set; }

        [BindProperty]
        public User searchedUser {get; private set;}
        public string searchedUserName;
        public string searchUserID;

        [BindProperty]
        public IEnumerable<UserEntity> ChatAsSender {get; private set;}

        [BindProperty]
        public IEnumerable<UserEntity> ChatAsReciver {get; private set;}

        [BindProperty]
        public bool DoesUserHaveChat {get; private set;}

        [BindProperty]
        public IEnumerable<ChatEntity> Chats {get; set;}

        [BindProperty]
        public IEnumerable<Chats> chatJson {get; private set;}

        [BindProperty]
        public string userChatingId {get; set;}

        [BindProperty]
        public string LoggedInUserId {get; set;}

        public IndexModel(ILogger<IndexModel> logger, JsonFileUserService userService)
        {
            _logger = logger;
            UserService = userService;
        }

        public void OnGet()
        {
            Users = UserService.GetUsers();
            LoggedInUserId = UserService.GetUserID();
            ChatAsSender = UserService.GetChatUsers(LoggedInUserId);
            ChatAsReciver = UserService.GetChatUsers_Reciver(LoggedInUserId);
            Console.WriteLine("started up");
        }

        public void OnPost()
        {
            LoggedInUserId = UserService.GetUserID();
            ChatAsSender = UserService.GetChatUsers(LoggedInUserId);
            ChatAsReciver = UserService.GetChatUsers_Reciver(LoggedInUserId);
        }

        public void OnPostSearch()
        {
            LoggedInUserId = UserService.GetUserID();
            ChatAsSender = UserService.GetChatUsers(LoggedInUserId);
            ChatAsReciver = UserService.GetChatUsers_Reciver(LoggedInUserId);
            if(string.IsNullOrWhiteSpace(specificUser))
            {
                RedirectToPage("/Index");
            }
            else{
                searchedUser = UserService.FindUser(specificUser);
                if(searchedUser == null)
                {
                    Console.WriteLine("No results found");
                }
                else {
                    searchedUserName = searchedUser.Name;
                    searchUserID = searchedUser.Id;
                    Console.WriteLine(searchedUserName);
                }
            }
        }

        [BindProperty]
        public string newChat {get; set;}
        public void OnPostChats()
        {
            LoggedInUserId = UserService.GetUserID();
            ChatAsSender = UserService.GetChatUsers(LoggedInUserId);
            ChatAsReciver = UserService.GetChatUsers_Reciver(LoggedInUserId);
            DoesUserHaveChat = UserService.CheckForChat(userChatingId, LoggedInUserId);
            if(DoesUserHaveChat)
            {
                Chats = UserService.GetChats(userChatingId, LoggedInUserId);
            }
            else{
                //Create chat row 
                UserService.CreateUserChats(userChatingId, LoggedInUserId);
            }
            if(string.IsNullOrWhiteSpace(newChat))
            {
                return; 
            }
            Console.WriteLine("Adding chat with user: " + userChatingId);
            UserService.AddChatToChats(LoggedInUserId, userChatingId, newChat);
        }
    }
}
