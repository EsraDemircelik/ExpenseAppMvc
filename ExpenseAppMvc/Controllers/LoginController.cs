using ExpenseAppMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ExpenseAppMvc.Controllers
{
    public class LoginController : Controller
    {
        Context c = new Context();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public PartialViewResult Partial1()
        {
            List<SelectListItem> value = (from x in c.UserRoles.ToList()
                                          select new SelectListItem
                                          {
                                              Text = x.UserRoleName,
                                              Value = x.Id.ToString()
                                          }).ToList();
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult Partial1(User user)
        {
            c.Users.Add(user);
            c.SaveChanges();
            return PartialView();
        }
        [HttpGet]
        public ActionResult Login1()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login1(User user)
        {
            var informations = c.Users.FirstOrDefault
            (x => x.Username == user.Username && x.Password == user.Password);
            if (informations != null)
            {
                FormsAuthentication.SetAuthCookie(informations.Username, false);
                Session["UserName"] = informations.Username.ToString();
                return RedirectToAction("Index", "ExpenseForm");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        [HttpGet]
        public ActionResult ManagerLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ManagerLogin(User user)
        {
            var informations = c.Users.FirstOrDefault
            (x => x.Username == user.Username && x.Password == user.Password);
            if (informations != null)
            {
                FormsAuthentication.SetAuthCookie(informations.Username, false);
                Session["UserName"] = informations.Username.ToString();

                return RedirectToAction("Index", "Manager");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        [HttpGet]
        public ActionResult AccountantLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AccountantLogin(User user)
        {
            var informations = c.Users.FirstOrDefault
            (x => x.Username == user.Username && x.Password == user.Password);
            if (informations != null)
            {
                FormsAuthentication.SetAuthCookie(informations.Username, false);
                Session["UserName"] = informations.Username.ToString();
                return RedirectToAction("Index", "Accountant");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        [HttpGet]
        public ActionResult AdminLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AdminLogin(User user)
        {
            var informations = c.Users.FirstOrDefault
            (x => x.Username == user.Username && x.Password == user.Password);
            if (informations != null)
            {
                FormsAuthentication.SetAuthCookie(informations.Username, false);
                Session["UserName"] = informations.Username.ToString();
                return RedirectToAction("Index", "Admin");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index");
        }
    }
}