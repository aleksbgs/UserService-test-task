using UserService.Core.Common;

namespace UserService.Core.Entities;

public class User: EntityBase
{
    public string? Name { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
    public string? Role { get; set; }
}