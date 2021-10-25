using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace NetChatApp.Data
{
    public class UserEntity
    {
        public string Id {get; set;}
        public string FirstName {get; set;}
        public string LastName {get; set;}
        public string ProfileImage {get; set;}
    }
}