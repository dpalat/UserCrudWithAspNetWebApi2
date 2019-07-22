using System.Web.Mvc;
using UserCrud.WebUI.Constants;
using UserCrud.WebUI.Services;


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