using Microsoft.Extensions.Logging;
using UserService.Core.Entities;
using UserService.InfraStructure.Data;

namespace UserService.Infrastructure.Data
{
    public class UserContextSeed
    {
        public static async Task SeedAsync(UserContext userContext, ILogger<UserContextSeed> logger)
        {
            if (!userContext.Users.Any())
            {
                userContext.Users.AddRange(GetUsers());
                await userContext.SaveChangesAsync();
                logger.LogInformation($"Users Database: {typeof(UserContext).Name} seeded!!!");
            }
        }

        private static IEnumerable<User> GetUsers()
        {
            return new List<User>
            {
                new()
                {
                    Name = "Tramp",
                    Email = "tramp@eCommerce.net",
                    Role = "Admin"
                },
                new()
                {
                    Name = "Putin",
                    Email = "putin@eCommerce.net",
                    Role = "user"
                },
            };
        }
    }
}