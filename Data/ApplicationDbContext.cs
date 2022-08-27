using TWebApplicationMVC1.Models;
using Microsoft.EntityFrameworkCore;

namespace TWebApplicationMVC1.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {

        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

        public DbSet<Users> Users { get; set; }
    }
}
