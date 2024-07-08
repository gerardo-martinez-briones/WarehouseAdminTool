using Core.Contracts.Persistence;
using Domain;
using MediatR;

namespace Core.Features.Users.Queries.GetLogin;

public class GetLoginQueryHandler : IRequestHandler<GetLoginQuery, User>
{
    private readonly IUserRepository _userRepository;

    public GetLoginQueryHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<User> Handle(GetLoginQuery request, CancellationToken cancellationToken)
    {
        var response = await _userRepository.GetLoginAsync(request.Username, request.Password);

        return response;
    }
}