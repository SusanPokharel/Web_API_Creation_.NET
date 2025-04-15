using Microsoft.EntityFrameworkCore;
using Web_API_Creation.Entities;

namespace Web_API_Creation{

public class ApplicationDbContext :DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :base(options)
    {
        
    }
    
    public DbSet<User> Users { get; set; }
}
}