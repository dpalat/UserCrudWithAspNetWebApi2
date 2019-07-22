using System.Web.Mvc;
using UserCrud.WebUI.Constants;
using UserCrud.WebUI.Services;

namespace UserCrud.WebUI.Controllers
{
    [AuthorizeRoles(RoleName.PAGE3, RoleName.ADMIN)]
    public class Page3Controller : Controller
    {
        // GET: Page3
        public ActionResult Index()
        {
            return View();
        }
    }
}