using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using UserCrud.Domain;
using UserCrud.Entity;
using UserCrud.WebApi.Controllers;

namespace UserCrud.WebApi.ApiSecurity
{
    public class BasicAuthenticationAttribute : AuthorizeAttribute
    {
        private const string Realm = "My Realm";
        private static IAuthenticationDomain _authenticationDomain;
        private string[] _requieredRoles;

        public BasicAuthenticationAttribute(params string[] roles)
        {
            _requieredRoles = roles;
        }

        public void SetAuthenticationDomain()
        {
            if (_authenticationDomain == null)
            {
                var authenticationDomain = GlobalConfiguration.Configuration.DependencyResolver.GetService(typeof(IAuthenticationDomain));
                _authenticationDomain = (IAuthenticationDomain)authenticationDomain;
            }
        }

        public override void OnAuthorization(HttpActionContext actionContext)
        {
            if (actionContext.ControllerContext.Controller.GetType() == typeof(SecurityController)) return;

            if (actionContext.Request.Headers.Authorization == null)
            {
                actionContext.Response = actionContext.Request
                    .CreateResponse(HttpStatusCode.Unauthorized);
                // If the request was unauthorized, add the WWW-Authenticate header
                // to the response which indicates that it require basic authentication
                if (actionContext.Response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    actionContext.Response.Headers.Add("WWW-Authenticate",
                        string.Format("Basic realm=\"{0}\"", Realm));
                }
                return;
            }

            SetAuthenticationDomain();

            var usernamePasswordArray = GetAuthenticationHeader(actionContext);
            string username = string.Empty, password = string.Empty;
            if (usernamePasswordArray.Length == 2)
            {
                username = usernamePasswordArray[0];
                password = usernamePasswordArray[1];
            }

            var user = _authenticationDomain.LogInUser(username, password);
            if (user != null)
            {
                var identity = new GenericIdentity(username);
                identity.AddClaims(GetUserClaims(user, user.Roles));

                IPrincipal principal = new GenericPrincipal(identity, null);

                if (!IsRolePermissionOk(user.Roles))
                {
                    actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
                    return;
                }

                Thread.CurrentPrincipal = principal;
                if (HttpContext.Current != null)
                {
                    HttpContext.Current.User = principal;
                }
            }
            else
            {
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
            }
        }

        private bool IsRolePermissionOk(List<string> userRoles)
        {
            if (_requieredRoles == null) return true;

            foreach (var role in _requieredRoles)
                if (!userRoles.Contains(role)) return false;

            return true;
        }

        private string[] GetAuthenticationHeader(HttpActionContext actionContext)
        {
            string authenticationToken = actionContext.Request.Headers.Authorization.Parameter;

            string decodedAuthenticationToken = Encoding.UTF8.GetString(
                Convert.FromBase64String(authenticationToken));

            string[] usernamePasswordArray = decodedAuthenticationToken.Split(':');

            return usernamePasswordArray;
        }

        private IEnumerable<Claim> GetUserClaims(User user, List<string> roles)
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
    }
}