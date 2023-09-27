using Microsoft.EntityFrameworkCore;
using CRM.Core.Models;
namespace CRM.Core._DbContext
{
    public class CoreDbContext : DbContext
    {
        public CoreDbContext(DbContextOptions<CoreDbContext> options):base(options) {
        
        }
        public DbSet<Device> Devices { get; set; }
    }
}
