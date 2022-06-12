namespace Lab8b.Database.Entities;

using Lab8b.Database.Constants;

public class User
{
    public int Id { get; set; }

    public string? LastName { get; set; }

    public string? FirtsName { get; set; }

    public string Email { get; set; } = string.Empty;

    public string Password { get; set; } = string.Empty;

    public string Status { get; set; } = UserStatus.Active;

    public string Role { get; set; } = string.Empty;
}
