using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using UserCrud.WebUI.Models.Identity;
using UserCrud.WebUI.Services;
using UserCrud.WebUI.ViewModels;

namespace UserCrud.WebUI.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private UserManager<ApplicationUser> _applicationUserManager;
        private AuthenticationService _authenticationService;

        public AccountController(AuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
            _applicationUserManager = new UserManager<ApplicationUser>(new ApplicationUserStore());
        }

        //
        // GET: /Account/Login
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        //
        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var result = await _authenticationService.SignIn(AuthenticationManager, model.Email, model.Password, model.RememberMe);

            switch (result)
            {
                case SignInStatus.Success:
                    SetTokenCookie(model);

                    return RedirectToLocal(returnUrl);

                case SignInStatus.LockedOut:
                    return View("Lockout");

                case SignInStatus.Failure:
                default:
                    ModelState.AddModelError("", "Invalid login attempt.");
                    return View(model);
            }
        }

        //
        // GET: /Account/Register
        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        //
        // POST: /Account/Register
        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
                var result = await _applicationUserManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    await _authenticationService.SignIn(AuthenticationManager, model.Email, model.Password, false);

                    return RedirectToAction("Index", "Home");
                }
                AddErrors(result);
            }

            return View(model);
        }

        //
        // POST: /Account/LogOff
        [HttpPost]
        public ActionResult LogOff()
        {
            _authenticationService.SignOut(AuthenticationManager);

            return RedirectToAction("Index", "Home");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_applicationUserManager != null)
                {
                    _applicationUserManager.Dispose();
                    _applicationUserManager = null;
                }
            }

            base.Dispose(disposing);
        }

        #region Helpers

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Home");
        }

        private void SetTokenCookie(LoginViewModel model)
        {
            var byteArray = Encoding.ASCII.GetBytes($"{model.Email}:{model.Password}");
            HttpCookie myCookie = new HttpCookie("usercrud-token");
            myCookie.Values.Add("token", Convert.ToBase64String(byteArray));
            myCookie.Expires = DateTime.Now.AddHours(12);
            Response.Cookies.Add(myCookie);
        }

        #endregion Helpers
    }
}