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
   
    public Task<IEnumerable<User>> GetUsers()
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<User>> CreateUser()
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<User>> UpdateUserRole()
    {
        throw new NotImplementedException();
    }
    

    public async Task<IEnumerable<User>> GetUserByUserName(string userName)
    {
        var userList = await _dbContext.Users
            .Where(o => o.Name == userName)
            .ToListAsync();
        return userList;
    }
}