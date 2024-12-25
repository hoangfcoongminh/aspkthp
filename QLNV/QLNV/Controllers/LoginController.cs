using QLNV.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLNV.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        private Model1 db = new Model1();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            var user = db.Taikhoans.Where(u => u.tendn.Equals(username) && u.matkhau.Equals(password)).FirstOrDefault();
            if (user == null)
            {
                ViewBag.Mess = "Sai";
                return View("Login");
            } else
            {
                Session["user"] = username;
                return RedirectToAction("Index", "NhanViens");
            }
        }

        public ActionResult Logout()
        {
            Session["user"] = null;
            return RedirectToAction("Index", "NhanViens");
        }
    }
}