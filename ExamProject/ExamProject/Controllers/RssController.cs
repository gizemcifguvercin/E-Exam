using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ExamProject.Helper;
using ExamProject.Models;
namespace ExamProject.Controllers
{
    public class RssController : Controller
    {
        private examDBEntities db = new examDBEntities();
        // GET: Rss
        public ActionResult CreateExam()
        {
            if (Session["LogedUserID"] == null)
            {
                return RedirectToAction("../Users/Login");
            }
            else
            {
                string url = "https://www.wired.com/category/science/science-blogs/feed/";
                var listitems = RssHelper.read(url);
                ViewBag.listItem = listitems;
                return View();
            }
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult CreateExam(Article article)
        {

             if (ModelState.IsValid)
              {
                 
                  article.userID = Convert.ToInt32(Session["LogedUserID"]);
                  article.creationDate = DateTime.Now.ToShortDateString();
                  
                  db.Articles.Add(article);

                 db.SaveChanges();
              }

            return Json("/Articles/Index");
      
        }
     

    }
}