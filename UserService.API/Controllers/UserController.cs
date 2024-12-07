using System.Net;
using MediatR;
using Microsoft.AspNetCore.Mvc;
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
    
    [HttpGet("{userName}", Name = "GetUserByUserName")]
    [ProducesResponseType(typeof(IEnumerable<UserResponse>), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<IEnumerable<UserResponse>>> GetUserByUserName(string userName)
    {
        var query = new GetUserListQuery(userName);
        var orders = await _mediator.Send(query);
        return Ok(orders);
    }
    
    
    
    
    
}