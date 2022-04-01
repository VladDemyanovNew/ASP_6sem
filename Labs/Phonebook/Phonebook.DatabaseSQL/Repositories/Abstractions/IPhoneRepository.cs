using System.Collections.Generic;
using System.Threading.Tasks;

using Phonebook.DatabaseSQL.Entites;


namespace Phonebook.DatabaseSQL.Repositories.Abstractions
{
    public interface IPhoneRepository
    {
        IEnumerable<Phone> GetAll();

        Task<Phone> Get(int phoneId);

        Task Create(Phone phoneCreateData);

        Task Update(int phoneId, Phone phoneUpdateData);

        Task Delete(int phoneId);
    }
}
