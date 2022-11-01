using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace DAL
{
    public class DBContextFactory : IDesignTimeDbContextFactory<DBContext>
    {
        public DBContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("local.settings.json", true, true)
                .Build();

            string connection = configuration["SqlConnectionString"];
            var optionsBuilder = new DbContextOptionsBuilder<DBContext>();

            optionsBuilder.UseSqlServer(connection);

            return new DBContext(optionsBuilder.Options);
        }
    }
}
