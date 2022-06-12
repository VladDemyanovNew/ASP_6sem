using Lab8b.Database;
using Lab8b.Database.Entities;
using Lab8b.Services.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Lab8b.Services;

public class UserService : IUserService
{
    private readonly Lab8bContext _dbContext;

    public UserService(Lab8bContext dbContext)
    {
        this._dbContext = dbContext;
    }

    public async Task<User> AddAsync(User user)
    {
        this._dbContext.Users.Add(user);
        _ = await this._dbContext.SaveChangesAsync();

        return user;
    }

    public async Task<User> DeleteAsync(int userId)
    {
        var user = this._dbContext.Users.FirstOrDefault(user => user.Id == userId);
        if (user == null)
        {
            throw new BadHttpRequestException("Can't delete user, because it doesn't exist");
        }

        this._dbContext.Users.Remove(user);
        _ = await this._dbContext.SaveChangesAsync();

        return user;
    }

    public async Task<User> GetAsync(int userId)
    {
        var user = await this._dbContext.Users.FindAsync(userId);
        if (user == null)
        {
            throw new BadHttpRequestException("User doesn't exist");
        }

        return user;
    }

    public IQueryable<User> GetAll() => this._dbContext.Users;

    public async Task<User> UpdateAsync(User user)
    {
        var doesPhoneExist = await this._dbContext.Users.AnyAsync(item => item.Id == user.Id);
        if (!doesPhoneExist)
        {
            throw new BadHttpRequestException("Can't update user, because it doesn't exist");
        }

        this._dbContext.Entry(user).State = EntityState.Modified;
        _ = await this._dbContext.SaveChangesAsync();

        return user;
    }
}
