using AutoMapper;
using MediatR;
using UserService.Application.Queries;
using UserService.Application.Responses;
using UserService.Core.Repositories;

namespace UserService.Application.Handlers;

public class GetUserListQueryHandler : IRequestHandler<GetUserListQuery, List<UserResponse>>
{
    private readonly IUserRepository _orderRepository;
    private readonly IMapper _mapper;

    public GetUserListQueryHandler(IUserRepository orderRepository, IMapper mapper)
    {
        _orderRepository = orderRepository;
        _mapper = mapper;
    }

    public async Task<List<UserResponse>> Handle(GetUserListQuery request, CancellationToken cancellationToken)
    {
        var userList = await _orderRepository.GetUserByUserName(request.UserName);
        return _mapper.Map<List<UserResponse>>(userList);
    }
}