
using Microsoft.EntityFrameworkCore;

using Rocky.Models;

namespace Rocky.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Category> Category { get; set; }

        public DbSet<Record> Record { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
    }
}
