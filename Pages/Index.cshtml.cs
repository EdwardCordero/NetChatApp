using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using NetChatApp.Models;
using NetChatApp.Services;

namespace NetChatApp.Pages
{
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
        public IEnumerable<User> chatUsers {get; private set;}

        [BindProperty]
        public IEnumerable<Chats> chats {get; private set;}

        [BindProperty]
        public string userChatingId {get; set;}

        

        public IndexModel(ILogger<IndexModel> logger, JsonFileUserService userService)
        {
            _logger = logger;
            UserService = userService;
        }

        public void OnGet()
        {
            Users = UserService.GetUsers();
            chatUsers = UserService.GetChatUsers();
            Console.WriteLine("started up");
        }

        public void OnPost()
        {
            chatUsers = UserService.GetChatUsers();
        }

        public void OnPostSearch()
        {
            chatUsers = UserService.GetChatUsers();
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

        public void OnPostChats()
        {
            Console.WriteLine("chating with user: " + userChatingId);
            chatUsers = UserService.GetChatUsers();
            chats = UserService.GetChats(userChatingId);
        }

        public void OnPostAddUser()
        {

        }

        public IEnumerable<Chats> UserChats(User userChating)
        {
            return chats = UserService.GetChats(userChating.Id);
        }
    }
}
