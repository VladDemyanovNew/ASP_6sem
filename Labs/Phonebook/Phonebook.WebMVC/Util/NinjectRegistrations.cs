using Ninject.Modules;

using Phonebook.DatabaseSQL.Repositories;
using Phonebook.DatabaseSQL.Repositories.Abstractions;
using Phonebook.DatabaseSQL;

using Ninject.Web.Common;

namespace Phonebook.WebMVC.Util
{
    public class NinjectRegistrations : NinjectModule
    {
        public override void Load()
        {
            // InTransientScope - по умолчанию (создаётся на каждый вызов)
            // InSingletonScope - один на все вызвовы
            // InThreadScope - новый экземпляр на каждый поток
            // InRequestScope - новый экземпляр на каждый запрос
            Bind<IPhoneRepository>().To<PhoneRepository>()
                .InRequestScope()
                .WithConstructorArgument("dbContext", new PhonebookContext());
        }
    }
}