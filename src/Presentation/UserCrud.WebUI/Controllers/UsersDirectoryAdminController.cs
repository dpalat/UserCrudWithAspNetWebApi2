using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using UserCrud.WebUI.Constants;
using UserCrud.WebUI.Dtos;
using UserCrud.WebUI.Services;
using UserCrud.WebUI.ViewModels;

namespace UserCrud.WebUI.Controllers
{
    [Authorize(Roles = RoleName.ADMIN)]
    public class UsersDirectoryAdminController : Controller
    {
        private readonly IUserService _userService;

        public UsersDirectoryAdminController(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<ActionResult> Index()
        {
            var usersDto = await _userService.GetAllUsersAsync(GetAccessToken());

            var viewModel = new List<UserDetailViewModel>();
            foreach (var userDto in usersDto)
            {
                viewModel.Add(Map(userDto));
            }
            return View(viewModel);
        }

        public async Task<ActionResult> Edit(string id)
        {
            if (string.IsNullOrWhiteSpace(id)) return HttpNotFound();

            var userDto = await _userService.GetAsync(id, GetAccessToken());
            if (userDto == null) return HttpNotFound();

            return View(Map(userDto));
        }

        [HttpPost]
        public async Task<ActionResult> Edit(UserDetailViewModel userViewModel)
        {
            if (ModelState.IsValid)
            {
                var userDto = Map(userViewModel);
                await _userService.UpdateAsync(userDto, GetAccessToken());
                return RedirectToAction(nameof(Index));
            }
            return View(userViewModel);
        }

        public async Task<ActionResult> Details(string id)
        {
            if (string.IsNullOrWhiteSpace(id)) return HttpNotFound();

            var userDto = await _userService.GetAsync(id, GetAccessToken());
            if (userDto == null) return HttpNotFound();

            return View(Map(userDto));
        }

        public async Task<ActionResult> Delete(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                return HttpNotFound();

            await _userService.DeleteAsync(id, GetAccessToken());
            return RedirectToAction(nameof(Index));
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(UserDetailViewModel userViewModel)
        {
            if (ModelState.IsValid)
            {
                var userDto = Map(userViewModel);
                await _userService.CreateAsync(userDto, GetAccessToken());
                return RedirectToAction(nameof(Index));
            }
            return View(userViewModel);
        }

        private UserDto Map(UserDetailViewModel userViewModel)
        {
            var roles = userViewModel.Roles.Split(',').ToList();

            return new UserDto
            {
                Id = userViewModel.Id,
                UserEmail = userViewModel.UserEmail,
                UserName = userViewModel.UserEmail,
                Name = userViewModel.Name,
                Roles = roles,
            };
        }

        private UserDetailViewModel Map(UserDto userDto)
        {
            var roles = string.Join(",", userDto.Roles);
            return new UserDetailViewModel
            {
                Id = userDto.Id,
                UserEmail = userDto.UserEmail,
                Name = userDto.Name,
                Roles = roles
            };
        }

        private string GetAccessToken()
        {
            HttpCookie myCookie = Request.Cookies["usercrud-token"];

            string accessToken = "";

            if (!string.IsNullOrEmpty(myCookie.Values["token"]))
            {
                accessToken = myCookie.Values["token"].ToString();
            }

            return accessToken;
        }
    }
}