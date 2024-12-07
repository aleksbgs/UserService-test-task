using System.Net;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using UserService.Application.Commands;
using UserService.Application.Queries;
using UserService.Application.Responses;

namespace UserService.API.Controllers;

public class UserController : ApiController
{
    private readonly IMediator _mediator;
    private readonly ILogger<UserController> _logger;

    public UserController(IMediator mediator, ILogger<UserController> logger)
    {
        _mediator = mediator;
        _logger = logger;
    }
    [HttpPost("CreateUser")]
    [ProducesResponseType(typeof(IEnumerable<UserResponse>), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<IEnumerable<UserResponse>>> CreateUser([FromBody] CreateUserCommand createUserCommand)
    {
        var user = await _mediator.Send(createUserCommand);
        return Ok(user);
    }
    [HttpPut(Name = "UpdateUserRole")]
    [ProducesResponseType(typeof(IEnumerable<UserResponse>), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<int>> UpdateUserRole([FromBody] UpdateUserCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }
    [HttpGet]
    [Route("GetUsers")]
    [ProducesResponseType(typeof(IList<UserResponse>), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<IList<UserResponse>>> GetUsers()
    {
        var query = new GetAllUsersQuery();
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    
    
    
    
    
}