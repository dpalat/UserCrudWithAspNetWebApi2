using System.Web.Mvc;

namespace UserCrud.WebUI.Controllers
{
    [Authorize]
    public class Page1Controller : Controller
    {
        // GET: Page1
        public ActionResult Index()
        {
            return View();
        }
    }
}