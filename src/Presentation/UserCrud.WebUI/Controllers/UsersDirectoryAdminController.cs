using System.Web.Mvc;
using UserCrud.WebUI.Auth.Service;

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