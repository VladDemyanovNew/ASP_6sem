using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Threading.Tasks;

using Phonebook.DatabaseSQL.Repositories.Abstractions;
using Phonebook.DatabaseSQL.Entities;

namespace Phonebook.WebMVC.Controllers
{
    public class DistController : Controller
    {
        private readonly IPhoneRepository phoneRepository;

        public DistController(IPhoneRepository phoneRepository)
        {
            this.phoneRepository = phoneRepository;
        }

        [HttpGet]
        public ActionResult Index()
        {
            // ViewBag.PropertyName
            // ViewData["PropertyName"]
            // TempData["PropertyName"]
            var phones = this.phoneRepository.GetAll();
            return View(phones);
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddSave(Phone phoneCreateData)
        {
            _ = this.phoneRepository.CreateAsync(phoneCreateData);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<ActionResult> Update(int phoneId)
        {
            var phone = await this.phoneRepository.GetAsync(phoneId);
            return View(phone);
        }

        [HttpPost]
        public ActionResult UpdateSave(Phone phoneUpdateData)
        {
            _ = this.phoneRepository.UpdateAsync(phoneUpdateData);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<ActionResult> Delete(int phoneId)
        {
            var phone = await this.phoneRepository.GetAsync(phoneId);
            return View(phone);
        }

        [HttpPost]
        public async Task<ActionResult> DeleteSave(int phoneId)
        {
            await this.phoneRepository.DeleteAsync(phoneId);
            return RedirectToAction("Index");
        }
    }
}