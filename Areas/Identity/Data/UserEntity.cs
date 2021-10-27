using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace NetChatApp.Areas.Identity.Data
{
    public class UserEntity : IdentityUser
    {
        [PersonalData]
        [Display(Name = "First Name")]
        public string FirstName {get; set;}

        [PersonalData]
        [Display(Name = "Last Name")]
        public string LastName {get; set;}

        public string Password {get; set;}
        public string ProfileImage {get; set;}
    }
}