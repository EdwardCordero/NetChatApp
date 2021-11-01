using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Identity;
using NetChatApp.Areas.Identity.Data;
using NetChatApp.Services;

namespace NetChatApp.Pages
{
    [Authorize]
    public class PrivacyModel : PageModel
    {
        private readonly ILogger<PrivacyModel> _logger;
        public JsonFileUserService _userService;

        public PrivacyModel(ILogger<PrivacyModel> logger, JsonFileUserService userService)
        {
            _logger = logger;
            _userService = userService;
        }

        [BindProperty]
        public string SignedInUserId {get; set;}

        public void OnGet()
        {
            SignedInUserId = _userService.GetUserID();
        }
    }
}
