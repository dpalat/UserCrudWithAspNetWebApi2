using System.Web.Mvc;
using UserCrud.WebUI.Auth.Service;

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