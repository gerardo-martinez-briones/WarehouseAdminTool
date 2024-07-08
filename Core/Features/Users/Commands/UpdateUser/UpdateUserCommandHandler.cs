using Core.Contracts.Persistence;
using Domain;
using MediatR;

namespace Core.Features.Users.Commands.UpdateUser;

public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand>
{
    private readonly IUserRepository _userRepository;

    public UpdateUserCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<Unit> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        User user = new();

        user.IdUser = request.IdUser;
        user.IdProfile = request.IdProfile;
        user.FirstName = request.FirstName;
        user.LastName = request.LastName;
        user.Email = request.Email;
        user.UserName = request.UserName;
        user.HashPassword = request.HashPassword;

        await _userRepository.UpdateUserAsync(user);

        return Unit.Value;
    }
}