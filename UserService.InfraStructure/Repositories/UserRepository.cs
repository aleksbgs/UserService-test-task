using Microsoft.EntityFrameworkCore;
using UserService.Core.Entities;
using UserService.Core.Repositories;
using UserService.InfraStructure.Data;

namespace UserService.InfraStructure.Repositories;

public class UserRepository : RepositoryBase<User>, IUserRepository
{
   
    public UserRepository(UserContext dbContext): base(dbContext)
    {
 
    }
    public async Task<IEnumerable<User>> GetAllUsers()
    {
        return await _dbContext
            .Users
            .ToListAsync();
    }
}