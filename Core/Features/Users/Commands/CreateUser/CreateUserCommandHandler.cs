using Core.Contracts.Persistence;
using Domain;
using MediatR;

namespace Core.Features.Users.Commands.CreateUser;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, int>
{
    private readonly IUserRepository _userRepository;

    public CreateUserCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        User user = new();

        user.IdProfile = request.IdProfile;
        user.FirstName = request.FirstName;
        user.LastName = request.LastName;
        user.Email = request.Email;
        user.UserName = request.UserName;
        user.HashPassword = request.HashPassword;

        var response = await _userRepository.CreateUserAsync(user);

        return response;
    }
}