﻿using System.Web.Mvc;

namespace UserCrud.WebUI.Services
{
    public class AuthorizeRolesAttribute : AuthorizeAttribute
    {
        public string ForbiddenViewName { get; set; } = "Forbidden";

        public AuthorizeRolesAttribute(params string[] roles)
        {
            Roles = string.Join(",", roles);
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            if (filterContext.HttpContext.Request.IsAuthenticated)
            {
                filterContext.HttpContext.Response.StatusCode = (int)System.Net.HttpStatusCode.Forbidden;
                var forbiddenView = new ViewResult { ViewName = ForbiddenViewName };
                filterContext.Result = forbiddenView;
            }
            else
            {
                base.HandleUnauthorizedRequest(filterContext);
            }
        }
    }
}