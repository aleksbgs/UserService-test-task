using System.Linq.Expressions;
using UserService.Core.Entities;

namespace UserService.Core.Repositories;

public interface IUserRepository: IAsyncRepository<User>
{
    Task<IEnumerable<User>> GetAllUsers();
}