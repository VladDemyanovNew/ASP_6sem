using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Phonebook.DatabaseSQL.Entites;
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

        public Task Create(Phone phoneCreateData)
        {
            throw new System.NotImplementedException();
        }

        public Task Delete(int phoneId)
        {
            throw new System.NotImplementedException();
        }

        public Task<Phone> Get(int phoneId)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Phone> GetAll()
        {
            return this.dbContext.Set<Phone>().AsNoTracking();
        }

        public Task Update(int phoneId, Phone phoneUpdateData)
        {
            throw new System.NotImplementedException();
        }
    }
}
