using Domain;
using MediatR;

namespace Core.Features.Users.Queries.GetUser;

public class GetUserQuery : IRequest<User>
{
    public int Id { get; set; }
}