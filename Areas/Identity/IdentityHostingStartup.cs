using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SneakerAIO.Areas.Identity.Data;
using SneakerAIO.Data;

[assembly: HostingStartup(typeof(SneakerAIO.Areas.Identity.IdentityHostingStartup))]
namespace SneakerAIO.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<SneakerDbContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("SneakerDbContextConnection")));

                services.AddDefaultIdentity<ApplicationUser>(options =>
                {
                    options.SignIn.RequireConfirmedAccount = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireUppercase = false;
                })

                    .AddEntityFrameworkStores<SneakerDbContext>();
            });
        }
    }
}