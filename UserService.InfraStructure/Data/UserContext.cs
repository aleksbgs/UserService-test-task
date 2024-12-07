using Microsoft.EntityFrameworkCore;
using UserService.Core.Entities;

namespace UserService.InfraStructure.Data;

public class UserContext:DbContext
{
    public UserContext(DbContextOptions<UserContext> options):base(options)
    {
        
    }
    public DbSet<User> Users { get; set; }
}