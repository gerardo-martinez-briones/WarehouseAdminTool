using Domain;
using MediatR;

namespace Core.Features.Users.Queries.GetLogin;

public class GetLoginQuery : IRequest<User>
{
    public string Username { get; set; }
    public string Password { get; set; }
}