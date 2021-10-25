using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetChatApp.Models;
using NetChatApp.Services;
using NetChatApp.Pages;

namespace NetChatApp.Controllers
{
    public class UserController : ControllerBase
    {
        public JsonFileUserService UserService {get; }
        public UserController(JsonFileUserService userService)
        {
            this.UserService = userService;
        } 

        public ActionResult FindUser(string searchUserString)
        {
            UserService.FindUser(searchUserString);
            Console.WriteLine("running");
            return RedirectToPage("/Index", new{searchUserString}); 
        }
    }
}