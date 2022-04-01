using System.Web.Mvc;

using Phonebook.WebMVC.ViewModels;


namespace Phonebook.WebMVC.Controllers
{
    public class ErrorController : Controller
    {
        public ActionResult NotFound()
        {
            var httpRequest = this.HttpContext.Request;
            return View(new NotFoundViewModel()
            {
                RequestMethod = httpRequest.HttpMethod,
                RequestURI = httpRequest.Params["aspxerrorpath"]
            });
        }
    }
}