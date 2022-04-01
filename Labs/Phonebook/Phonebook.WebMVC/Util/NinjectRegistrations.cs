using Ninject.Modules;

using Phonebook.DatabaseSQL.Repositories;
using Phonebook.DatabaseSQL.Repositories.Abstractions;
using Phonebook.DatabaseSQL;

namespace Phonebook.WebMVC.Util
{
    public class NinjectRegistrations : NinjectModule
    {
        public override void Load()
        {
            Bind<IPhoneRepository>().To<PhoneRepository>();
            Bind<PhonebookContext>().To<PhonebookContext>();
        }
    }
}