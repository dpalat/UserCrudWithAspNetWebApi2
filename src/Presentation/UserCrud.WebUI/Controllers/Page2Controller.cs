using System.Web.Mvc;

namespace UserCrud.WebUI.Controllers
{
    [Authorize]
    public class Page2Controller : Controller
    {
        // GET: Page2
        public ActionResult Index()
        {
            return View();
        }
    }
}