using Microsoft.EntityFrameworkCore;

namespace LoginandSignup.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {

        }
        public DbSet<UserModel> Users { get; set; }
       
        
    }
}
