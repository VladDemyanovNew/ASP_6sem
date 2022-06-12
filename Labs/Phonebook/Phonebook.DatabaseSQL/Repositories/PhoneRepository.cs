using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

using Phonebook.DatabaseSQL.Entities;
using Phonebook.DatabaseSQL.Repositories.Abstractions;


namespace Phonebook.DatabaseSQL.Repositories
{
    public class PhoneRepository : IPhoneRepository
    {
        private readonly PhonebookContext dbContext;

        public PhoneRepository(PhonebookContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Phone> CreateAsync(Phone phone)
        {
            _ = this.dbContext.Phones.Add(phone);
            _ = await this.dbContext.SaveChangesAsync();
            return phone;
        }

        public async Task DeleteAsync(int phoneId)
        {
            var phone = await this.GetAsync(phoneId);
            _ = this.dbContext.Phones.Remove(phone);
            _ = await this.dbContext.SaveChangesAsync();
        }

        public async Task<Phone> GetAsync(int phoneId) =>
            await this.dbContext.Phones.FindAsync(phoneId);

        public IQueryable<Phone> GetAll() => this.dbContext.Phones;
        
        public async Task UpdateAsync(Phone phone)
        {
            this.dbContext.Entry(phone).State = EntityState.Modified;
            _ = await this.dbContext.SaveChangesAsync();
        }
    }
}
