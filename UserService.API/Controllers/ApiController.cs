using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace UserService.API.Controllers;

[ApiVersion("1")]
[Route("api/v{version:apiVersion}/[controller]")]
[ApiController]
public class ApiController : ControllerBase
{
}