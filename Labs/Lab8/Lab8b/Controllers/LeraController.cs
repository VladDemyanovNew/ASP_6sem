namespace Lab8b.Controllers;

using Lab8b.Database;
using Lab8b.Database.Entities;
using Lab8b.Services.Abstractions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class LeraController : ControllerBase
{
    private readonly IUserService _userService;

    public LeraController(IUserService userService)
    {
        this._userService = userService;
    }

    /// <summary>
    /// Gets all users.
    /// </summary>
    [HttpGet]
    public IQueryable<User> GetAll() => this._userService.GetAll();

    /// <summary>
    /// Gets user by Id.
    /// </summary>
    [HttpGet("{userId}")]
    public async Task<User> Get(int userId) => await this._userService.GetAsync(userId);

    /// <summary>
    /// Deletes user by Id.
    /// </summary>
    [HttpDelete("{userId}")]
    public async Task<User> Delete(int userId) => await this._userService.DeleteAsync(userId);

    /// <summary>
    /// Creates a new user.
    /// </summary>
    [HttpPost]
    public async Task<User> Post([FromBody] User user) => await this._userService.AddAsync(user);

    /// <summary>
    /// Updates a user.
    /// </summary>
    [HttpPut]
    public async Task<User> Put([FromBody] User user) => await this._userService.UpdateAsync(user);
}
