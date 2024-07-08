using MediatR;

namespace Core.Features.Users.Commands.CreateUser;

public class CreateUserCommand : IRequest<int>
{
    public int IdProfile { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string UserName { get; set; }
    public string HashPassword { get; set; }
}