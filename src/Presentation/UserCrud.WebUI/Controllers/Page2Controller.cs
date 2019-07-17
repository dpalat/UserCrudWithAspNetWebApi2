﻿using System.Web.Mvc;
using UserCrud.WebUI.Auth.Service;

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