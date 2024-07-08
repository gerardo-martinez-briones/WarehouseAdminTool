using MediatR;

namespace Core.Features.Users.Commands.DeleteUser;

public class DeleteUserCommand : IRequest
{
    public int Id { get; set; }
}