using System.Collections.Generic;
using System.Threading.Tasks;
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
        private readonly UserService _userService = new UserService();

        public async Task<ActionResult> Index()
        {
            var usersDto = await _userService.GetAllUsers();

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

            var userDto = await _userService.GetAsync(id);
            if (userDto == null) return HttpNotFound();

            return View(Map(userDto));
        }

        private UserDetailViewModel Map(UserDto userDto)
        {
            return new UserDetailViewModel { Roles = string.Join(",", userDto.Roles), Email = userDto.UserEmail, Id = userDto.Id.ToString() };
        }
    }
}