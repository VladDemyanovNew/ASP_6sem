namespace Lab8a.Database.Entities;

public class Phone : BaseEntity
{
    public string Name { get; set; } = String.Empty;

    public string? PhoneNumber { get; set; }
}
