using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using System.IO;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Service.Interface;
using Service.Service;
using DAL.Interface;
using DAL.Repository;
using DAL;

[assembly: FunctionsStartup(typeof(SendMail.Timer.Startup))]
namespace SendMail.Timer
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("local.settings.json", true, true)
                .Build();

            builder.Services.AddScoped<IMailService, MailService>();
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IUserRepository, UserRepository>();

            builder.Services.AddDbContext<DBContext>(options =>
                options.UseSqlServer(configuration["SqlConnectionString"]));
        }
    }
}