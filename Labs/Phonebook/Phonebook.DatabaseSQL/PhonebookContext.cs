using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Phonebook.DatabaseSQL.Entities;

namespace Phonebook.DatabaseSQL
{
    public class PhonebookContext : DbContext
    {
        public PhonebookContext() : base("Phonebook") { }

        public DbSet<Phone> Phones { get; set; }
    }
}
