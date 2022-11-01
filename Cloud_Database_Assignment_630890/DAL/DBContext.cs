using Microsoft.EntityFrameworkCore;
using Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
