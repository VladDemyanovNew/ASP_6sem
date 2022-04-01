using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

using Phonebook.DatabaseJSON.Entities;
using Phonebook.DatabaseJSON.Repositories.Abstractions;
using System;
using System.Linq;

namespace Phonebook.DatabaseJSON.Repositories
{
    public class PhoneRepository : IPhoneRepository
    {
        private readonly string pathToFile;

        public PhoneRepository()
        {
            var exePath = AppDomain.CurrentDomain.BaseDirectory;
            var pathToFile = Path.Combine(exePath, "Data", "Phonebook.json");

            this.pathToFile = pathToFile;
        }

        public void Create(Phone phoneCreateData)
        {
            var phones = this.GetAll().ToList();

            phoneCreateData.Id = phones.Count == 0 ? 1 : phones.Last().Id + 1;
            phones.Add(phoneCreateData);

            var json = JsonConvert.SerializeObject(phones);

            using (var writer = new StreamWriter(this.pathToFile, false))
            {
                writer.Write(json);
            }
        }

        public void Delete(int phoneId)
        {
            var phones = this.GetAll();

            phones = phones.Where(phone => phone.Id != phoneId).ToList();
            var json = JsonConvert.SerializeObject(phones);

            using (var writer = new StreamWriter(this.pathToFile, false))
            {
                writer.Write(json);
            }
        }

        public Phone Get(int phoneId)
        {
            var phones = this.GetAll();

            return phones.Where(phone => phone.Id == phoneId).First();
        }

        public IEnumerable<Phone> GetAll()
        {
            var json = string.Empty;

            using (var reader = new StreamReader(this.pathToFile))
            {
                json = reader.ReadToEnd();
            }

            var phones = JsonConvert.DeserializeObject<IEnumerable<Phone>>(json);

            return phones;
        }

        public void Update(int phoneId, Phone phoneUpdateData)
        {
            var phones = this.GetAll();

            var phone = phones.Where(x => x.Id == phoneId).First();
            phone.Name = phoneUpdateData.Name;
            phone.PhoneNumber = phoneUpdateData.PhoneNumber;

            var json = JsonConvert.SerializeObject(phones);

            using (var writer = new StreamWriter(this.pathToFile, false))
            {
                writer.Write(json);
            }
        }
    }
}
