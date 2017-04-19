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
    public class ArticlesController : Controller
    {
        private examDBEntities db = new examDBEntities();

        // GET: Articles
        public ActionResult Index()
        {
            var articles = db.Articles.Include(a => a.User);
            return View(articles.ToList());
        }

        public ActionResult Exam(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Article article = db.Articles.Find(id);
            if (article == null)
            {
                return HttpNotFound();
            }
            ViewBag.aid = article.articleID;
            ViewBag.title = article.title;
            ViewBag.description = article.description;
            ViewBag.q1 = article.question1;
            ViewBag.q1a = article.question1_A;
            ViewBag.q1b = article.question1_B;
            ViewBag.q1c = article.question1_C;
            ViewBag.q1d = article.question1_D;



            ViewBag.q2 = article.question2;
            ViewBag.q2a = article.question2_A;
            ViewBag.q2b = article.question2_B;
            ViewBag.q2c = article.question2_C;
            ViewBag.q2d = article.question2_D;

            ViewBag.q3 = article.question3;
            ViewBag.q3a = article.question3_A;
            ViewBag.q3b = article.question3_B;
            ViewBag.q3c = article.question3_C;
            ViewBag.q3d = article.question3_D;

            ViewBag.q4 = article.question4;
            ViewBag.q4a = article.question4_A;
            ViewBag.q4b = article.question4_B;
            ViewBag.q4c = article.question4_C;
            ViewBag.q4d = article.question4_D;

            return View(article);
        }


        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Exam(ValidateMyChoice vd)
        {
            string answer1="", answer2="", answer3="", answer4="";
         
            if (ModelState.IsValid)
            {
               
                Article article = db.Articles.Find(vd.aid);

                if (article.question1_choice.Equals(vd.q1))
                {
                    answer1 = "green " + ":" + vd.q1;
                }
                if (!article.question1_choice.Equals(vd.q1))
                {
                    answer1 = "red " + ":" + vd.q1;
                }
                if (article.question2_choice.Equals(vd.q2))
                {
                    answer2 = "green " + ":" + vd.q2;
                
                 }
                if (!article.question2_choice.Equals(vd.q2))
                {
                    answer2 = "red " + ":" + vd.q2;
                }
                if (article.question3_choice.Equals(vd.q3))
                {
                    answer3 = "green " + ":" + vd.q3;
                }
                if (!article.question3_choice.Equals(vd.q3))
                {
                    answer3 = "red " + ":" + vd.q3;
                }
                if (article.question4_choice.Equals(vd.q4))
                {
                    answer4 = "green " + ":" + vd.q4;
                }
                if (!article.question4_choice.Equals(vd.q4))
                {
                    answer4 = "red " + ":" + vd.q4;
                }

            }
            List<String> sonuclar = new List<String>();
            sonuclar.Add(answer1);
       
            sonuclar.Add(answer2);
       
            sonuclar.Add(answer3);
 
            sonuclar.Add(answer4);
    
            return Json(sonuclar);

        }
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Article article = db.Articles.Find(id);
            if (article == null)
            {
                return HttpNotFound();
            }
            return View(article);
        }

        // POST: Articles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Article article = db.Articles.Find(id);
            db.Articles.Remove(article);
            db.SaveChanges();
            return RedirectToAction("Index");
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
