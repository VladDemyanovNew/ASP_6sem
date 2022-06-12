namespace Lab8a.Services.Abstractions;

using Lab8a.Database.Entities;

public interface IPhoneService
{
    IQueryable<Phone> GetAll();

    Task<Phone> GetAsync(int phoneId);

    Task<Phone> CreateAsync(Phone phone);

    Task UpdateAsync(Phone phone);

    Task DeleteAsync(int phoneId);
}
