using Core.Contracts.Persistence;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories;

public class UserRepository : IUserRepository
{
    private readonly ApplicationDbContext _dbContext;

    public UserRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<User> GetLoginAsync(string username, string password)
    {
        var response = await _dbContext.Users.Include(i => i.Profile)
            .Where(x => x.UserName.Equals(username)
                && x.HashPassword.Equals(password) && x.IsActive == true)
            .FirstOrDefaultAsync();

        return response;
    }

    public async Task<User> GetUserAsync(int id)
    {
        var response = await _dbContext.Users.Include(i => i.Profile)
            .Where(x => x.IdUser == id && x.IsActive == true)
            .FirstOrDefaultAsync();

        return response;
    }

    public async Task<List<User>> GetUsersAsync(string filter = "")
    {
        if (string.IsNullOrWhiteSpace(filter))
            return await _dbContext.Users.Include(i => i.Profile).Where(x => x.IsActive == true)
                .ToListAsync();
        else
        {
            return await _dbContext.Users.Include(i => i.Profile).Where(x => x.IsActive &&
                (x.FirstName.Contains(filter)
                    || x.LastName.Contains(filter)
                    || x.Email.Contains(filter)
                    || x.UserName.Contains(filter)))
                .ToListAsync();
        }
    }

    public async Task<int> CreateUserAsync(User entity)
    {
        await _dbContext.Users.AddAsync(entity);
        await _dbContext.SaveChangesAsync();

        return entity.IdUser;
    }

    public async Task UpdateUserAsync(User entity)
    {
        _dbContext.Entry(entity).State = EntityState.Modified;

        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteUserAsync(User entity)
    {
        _dbContext.Users.Remove(entity);

        await _dbContext.SaveChangesAsync();
    }
}