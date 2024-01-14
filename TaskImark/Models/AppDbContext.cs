using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace TaskImark.Models
{
    public class AppDbContext : DbContext
    {
        
        
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<Visitor> Visitors { get; set; }
    }
}
