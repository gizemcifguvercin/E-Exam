using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ExamProject.Models;

namespace ExamProject.Controllers
{
    public class UsersController : Controller
    {
        private examDBEntities db = new examDBEntities();

        // GET: Users
        public ActionResult Index()
        {
            return View(db.Users.ToList());
        }
        public ActionResult Login()
        {
            if (Session["LogedUserID"] != null)
            {
                return RedirectToAction("../Rss/CreateExam");
            }
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(User u)
        {
            ViewBag.errorMessage = "";
            if (ModelState.IsValid)
            {
                using (examDBEntities dc = new examDBEntities())
                {
                 

                    var user = db.Users.Where(a => a.userName.Equals(u.userName) && a.password.Equals(u.password)).FirstOrDefault();
                     
                    if (user != null)
                    {
                        Session["LogedUserID"] = user.userID;
                        return RedirectToAction("../Rss/CreateExam");
                    }
                    else
                    {

                        TempData["errorMessage"] = "Hatalı Kullanıcı Adı Veya Parola";
                        return RedirectToAction("../Users/Login");
                        
                    }

                }
            }
            return View(u.ToString());
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            Session["LogedUserID"] = null;
            return RedirectToAction("../Users/Login");
        }
    
       

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
