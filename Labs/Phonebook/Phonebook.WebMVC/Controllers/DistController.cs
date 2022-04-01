using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

using Phonebook.DatabaseJSON.Entities;
using Phonebook.DatabaseJSON.Repositories.Abstractions;
using Phonebook.DatabaseJSON;

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
            this.phoneRepository.Create(phoneCreateData);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Update(int phoneId)
        {
            var phone = this.phoneRepository.Get(phoneId);
            return View(phone);
        }

        [HttpPost]
        public ActionResult UpdateSave(Phone phoneUpdateData)
        {
            // TODO: Add a validation for the existence of a phone with id = phoneUpdateData.Id
            this.phoneRepository.Update(phoneUpdateData.Id, phoneUpdateData);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int phoneId)
        {
            var phone = this.phoneRepository.Get(phoneId);
            return View(phone);
        }

        [HttpPost]
        public ActionResult DeleteSave(int phoneId)
        {
            // TODO: Add a validation for the existence of a phone with id = phoneId
            this.phoneRepository.Delete(phoneId);
            return RedirectToAction("Index");
        }
    }
}