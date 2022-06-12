namespace Lab8a.Services;

using Lab8a.Database;
using Lab8a.Database.Entities;
using Lab8a.Services.Abstractions;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

public class PhoneService : IPhoneService
{
    private readonly Lab8aContext _dbContext;

    public PhoneService(Lab8aContext dbContext)
    {
        this._dbContext = dbContext;
    }

    public async Task<Phone> CreateAsync(Phone phone)
    {
        this._dbContext.Phones.Add(phone);
        _ = await this._dbContext.SaveChangesAsync();

        return phone;
    }

    public async Task DeleteAsync(int phoneId)
    {
        var phone = this._dbContext.Phones.FirstOrDefault(phone => phone.Id == phoneId);
        if (phone == null)
        {
            throw new BadHttpRequestException("Can't delete phone, because it doesn't exist");
        }

        this._dbContext.Phones.Remove(phone);
        _ = await this._dbContext.SaveChangesAsync();
    }

    public IQueryable<Phone> GetAll() => this._dbContext.Phones;

    public async Task<Phone> GetAsync(int phoneId)
    {
        var phone = await this._dbContext.Phones.FindAsync(phoneId);
        if (phone == null)
        {
            throw new BadHttpRequestException("Phone doesn't exist");
        }

        return phone;
    }

    public async Task UpdateAsync(Phone phone)
    {
        var doesPhoneExist = await this._dbContext.Phones.AnyAsync(item => item.Id == phone.Id);
        if (!doesPhoneExist)
        {
            throw new BadHttpRequestException("Can't update phone, because it doesn't exist");
        }

        this._dbContext.Entry(phone).State = EntityState.Modified;
        _ = await this._dbContext.SaveChangesAsync();
    }
}
