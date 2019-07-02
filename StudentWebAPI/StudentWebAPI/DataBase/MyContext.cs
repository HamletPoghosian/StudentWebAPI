using Microsoft.EntityFrameworkCore;
using StudentWebAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentWebAPI.DataBase
{
    public class MyContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public MyContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
