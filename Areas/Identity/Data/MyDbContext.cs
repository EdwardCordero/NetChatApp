using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace NetChatApp.Areas.Identity.Data
{
    public class MyDbContext : IdentityDbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
            
        }

        public DbSet<UserEntity> User {get; set;}
        public  DbSet<UserChatsEntity> UserChats {get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // modelBuilder.Entity<UserEntity>()
            //     .Property(b => b.ProfileImage)
            //     .HasDefaultValue("https://upload.wikimedia.org/wikipedia/commons/thumb/e/ee/.NET_Core_Logo.svg/1024px-.NET_Core_Logo.svg.png");
            // modelBuilder.Entity<UserEntity>(e => e.Property(o => o.Password).HasColumnName)

            // modelBuilder.Entity<ChatEntity>()
            //     .Property(b => b.Date)
            //     .HasDefaultValueSql("getdate()");
        }
    }
}