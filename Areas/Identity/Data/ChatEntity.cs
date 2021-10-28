using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace NetChatApp.Areas.Identity.Data
{
    public class ChatEntity
    {
        [Key]
        public string ChatId {get; set;}

        public string ChatText {get; set;}

        public UserEntity Reciver {get; set;}

        public UserEntity Sender {get; set;}

        public DateTime CreatedOnDate {get; set;}

        public string test {get; set;}
    }
}