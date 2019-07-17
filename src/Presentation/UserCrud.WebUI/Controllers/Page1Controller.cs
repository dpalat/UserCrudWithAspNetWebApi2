using System.Web.Mvc;
using UserCrud.WebUI.Auth.Service;

namespace UserCrud.WebUI.Controllers
{
    [AuthorizeRoles(RoleName.PAGE1, RoleName.ADMIN)]
    public class Page1Controller : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}