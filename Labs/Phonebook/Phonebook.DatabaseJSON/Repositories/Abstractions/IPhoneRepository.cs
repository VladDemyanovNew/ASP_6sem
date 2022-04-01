using System.Collections.Generic;

using Phonebook.DatabaseJSON.Entities;


namespace Phonebook.DatabaseJSON.Repositories.Abstractions
{
    public interface IPhoneRepository
    {
        IEnumerable<Phone> GetAll();

        Phone Get(int phoneId);

        void Create(Phone phoneCreateData);

        void Update(int phoneId, Phone phoneUpdateData);

        void Delete(int phoneId);
    }
}
