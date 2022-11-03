using Microsoft.EntityFrameworkCore;
using Model.Entity;

namespace DAL
{
    public class DBContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<House> Houses { get; set; }

        public DBContext(DbContextOptions<DBContext> options) : base(options)
        {
        }
    }
}
