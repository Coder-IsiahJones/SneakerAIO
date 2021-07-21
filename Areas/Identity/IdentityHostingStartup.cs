using Microsoft.AspNetCore.Hosting;
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
            builder.ConfigureServices((context, services) =>
            {
                services.AddDbContext<AuthDbContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("AuthDbContextConnection")));

                services.AddDefaultIdentity<ApplicationUser>(options =>
                {
                    options.Password.RequireLowercase = false;
                    options.Password.RequireUppercase = false;
                    options.SignIn.RequireConfirmedAccount = false;
                })

                   .AddEntityFrameworkStores<AuthDbContext>();
            });
        }
    }
}