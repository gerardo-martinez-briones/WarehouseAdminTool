using Domain;
using MediatR;

namespace Core.Features.Users.Queries.GetUsers;

public class GetUsersQuery : IRequest<List<User>>
{
    public string Filter { get; set; }
}