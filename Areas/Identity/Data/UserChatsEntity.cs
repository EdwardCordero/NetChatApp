using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace NetChatApp.Areas.Identity.Data
{
    public class UserChatsEntity
    {
        [Key]
        public string ChatId {get;set;}

        public UserEntity User {get; set;}

        public UserEntity ChatingWithId {get; set;}

        public IEnumerable<ChatEntity> Chats {get; set;}
    }
}