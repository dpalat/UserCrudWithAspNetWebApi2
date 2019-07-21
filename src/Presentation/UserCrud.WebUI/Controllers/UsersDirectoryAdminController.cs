using System.Web.Mvc;
using UserCrud.WebUI.Constants;

namespace UserCrud.WebUI.Controllers
{
    [Authorize(Roles = RoleName.ADMIN)]
    public class UsersDirectoryAdminController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}