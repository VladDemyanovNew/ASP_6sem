using Lab8b.Database.Entities;

namespace Lab8b.Services.Abstractions;

public interface IUserService
{
    IQueryable<User> GetAll();

    Task<User> AddAsync(User user);

    Task<User> UpdateAsync(User user);

    Task<User> GetAsync(int userId);

    Task<User> DeleteAsync(int userId);
}
