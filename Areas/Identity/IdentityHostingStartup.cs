using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NetChatApp.Areas.Identity.Data;

[assembly: HostingStartup(typeof(NetChatApp.Areas.Identity.IdentityHostingStartup))]
namespace NetChatApp.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<MyDbContext>(options =>
                    options.UseMySQL(
                        context.Configuration.GetConnectionString("Default")));
            });
        }
    }
}