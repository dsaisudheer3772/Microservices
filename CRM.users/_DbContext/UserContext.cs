using Microsoft.EntityFrameworkCore;
using CRM.Users.Models;
namespace CRM.Users._DbContext
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> options) : base(options) { 
        
        }
        
        public DbSet<RegisterUser> RegisterUsers { get; set; }
    }
}
