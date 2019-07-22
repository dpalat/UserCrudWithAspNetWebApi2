using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using UserCrud.WebUI.Dtos;
using UserCrud.WebUI.Models.Identity;

namespace UserCrud.WebUI.Services
{
    public class AuthenticationService
    {
        private readonly HttpClient _httpClient;
        private UserManager<ApplicationUser> _applicationUserManager;

        public AuthenticationService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _applicationUserManager = new UserManager<ApplicationUser>(new ApplicationUserStore());
        }

        public async Task<SignInStatus> SignIn(IAuthenticationManager authenticationManager, string email, string password, bool rememberMe = false)
        {
            authenticationManager.SignOut(DefaultAuthenticationTypes.ExternalCookie);

            var data = new { UserEmail = email, Password = password };
            var json = JsonConvert.SerializeObject(data);
            var stringContent = new StringContent(json, Encoding.UTF8, "application/json");

            var signInStatus = SignInStatus.Failure;
            try
            {
                var response = await _httpClient.PostAsync("Security/LogIn", stringContent);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();

                    var userDto = JsonConvert.DeserializeObject<UserDto>(jsonResponse);

                    var user = new ApplicationUser { UserName = userDto.UserName, Email = userDto.UserEmail };

                    var identity = await _applicationUserManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
                    identity.AddClaims(GetUserClaims(user, userDto.Roles));

                    authenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = rememberMe }, identity);
                    signInStatus = SignInStatus.Success;
                }
            }
            catch (System.Exception e)
            {
                Trace.TraceError(e.ToString());
            }

            return signInStatus;
        }

        private IEnumerable<Claim> GetUserClaims(ApplicationUser user, List<string> roles)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.NameIdentifier, user.UserName)
            };

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }
            return claims;
        }

        public void SignOut(IAuthenticationManager authenticationManager)
        {
            authenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
        }
    }
}