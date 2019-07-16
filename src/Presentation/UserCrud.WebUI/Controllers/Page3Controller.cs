using System.Web.Mvc;

namespace UserCrud.WebUI.Controllers
{
    [Authorize]
    public class Page3Controller : Controller
    {
        // GET: Page3
        public ActionResult Index()
        {
            return View();
        }
    }
}