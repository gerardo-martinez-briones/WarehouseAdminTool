using Core.Contracts.Persistence;
using Domain;
using MediatR;

namespace Core.Features.Users.Queries.GetUser;

public class GetUserQueryHandler : IRequestHandler<GetUserQuery, User>
{
    private readonly IUserRepository _userRepository;

    public GetUserQueryHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<User> Handle(GetUserQuery request, CancellationToken cancellationToken)
    {
        var response = await _userRepository.GetUserAsync(request.Id);

        return response;
    }
}