using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Phonebook.DatabaseSQL.Entities;


namespace Phonebook.DatabaseSQL.Repositories.Abstractions
{
    public interface IPhoneRepository
    {
        IQueryable<Phone> GetAll();

        Task<Phone> GetAsync(int phoneId);

        Task<Phone> CreateAsync(Phone phone);

        Task UpdateAsync(Phone phone);

        Task DeleteAsync(int phoneId);
    }
}
