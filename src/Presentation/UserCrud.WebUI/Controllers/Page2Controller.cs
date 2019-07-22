using System.Web.Mvc;
using UserCrud.WebUI.Constants;
using UserCrud.WebUI.Services;

namespace UserCrud.WebUI.Controllers
{
    [AuthorizeRoles(RoleName.PAGE2, RoleName.ADMIN)]
    public class Page2Controller : Controller
    {
        
        public ActionResult Index()
        {
            return View();
        }
    }
}