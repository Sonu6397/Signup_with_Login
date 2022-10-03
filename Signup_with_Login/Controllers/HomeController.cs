using Signup_with_Login.dbo_connet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Signup_with_Login.Controllers
{
    public class HomeController : Controller
    {
        dummyEntities db = new dummyEntities();
        public ActionResult Index()
        {
            var res = db.Student_tbl.ToList();
            return View(res);
        }
        public ActionResult Signup()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Signup(Student_tbl a)
        {
           
            if (ModelState.IsValid == false)
            {
                db.Student_tbl.Add(a);
                db.SaveChanges();
                ModelState.Clear();
            }
            return RedirectToAction("Login");
        }

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Student_tbl L)
        {
            var Login = db.Student_tbl.Where(x => x.Email == L.Email && x.Password == L.Password).FirstOrDefault();
            if (Login != null)
            {
                TempData["LoginSuccessFully"] = "<script>alert('Login SuccessFully ??')</script>";
                return RedirectToAction("index", "Home");
            }
            else
            {
                ViewBag.ErrorMessage = "<script>alert('user Password is invalid ??')</script>";
                return View();
            }
        }

        public ActionResult LogOut()
        {

            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}