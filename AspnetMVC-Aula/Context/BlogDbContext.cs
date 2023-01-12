using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WebAspnet_.Models
{
    public class BlogDbContext : DbContext
    {

        public DbSet<User> Users { get; set; }
        public BlogDbContext(DbContextOptions<BlogDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}