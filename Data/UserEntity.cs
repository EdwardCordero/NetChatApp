using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace NetChatApp.Data
{
    public class UserEntity
    {
        public string Id {get; set;}

        [Required]
        [Display(Name = "First Name")]
        public string FirstName {get; set;}

        [Required]
        [Display(Name = "Last Name")]
        public string LastName {get; set;}

        [Required]
        public string password {get; set;}
        public string ProfileImage {get; set;}
    }
}