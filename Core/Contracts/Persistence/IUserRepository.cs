using Domain;

namespace Core.Contracts.Persistence;

public interface IUserRepository
{
    Task<User> GetLoginAsync(string username, string password);
    Task<User> GetUserAsync(int id);
    Task<List<User>> GetUsersAsync(string filter = "");
    Task<int> CreateUserAsync(User entity);
    Task UpdateUserAsync(User entity);
    Task DeleteUserAsync(User entity);
}