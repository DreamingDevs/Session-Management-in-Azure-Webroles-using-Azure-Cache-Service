using Microsoft.WindowsAzure.ServiceRuntime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebRoleSession.Models;

namespace WebRoleSession.Controllers
{
        public class HomeController : Controller
        {
            public ActionResult Index()
            {
                return View(new UserViewModel());
            }

            [HttpPost]
            public ActionResult Details(UserViewModel model)
            {
                Session["UserName"] = model.Username;
                return View(model);
            }

            [HttpGet]
            public ActionResult Details()
            {

                ViewBag.Username = Session["UserName"] == null ? "Go back" : Session["UserName"].ToString();
                ViewBag.Instance = RoleEnvironment.CurrentRoleInstance.Id;
                return View();
            }
        }
}