using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Kyrsach.Models;
using Kyrsach.DAO;

namespace Kyrsach.Controllers
{
    public class HomeController : Controller
    {
        private Database1Entities1 _entities = new Database1Entities1();
        ArticleDAO articleDAO = new ArticleDAO();
        TestDAO testDAO = new TestDAO();

        public ActionResult Index(string nazvanie)
        {
            var search = from s in _entities.Articles select s;
            if (!String.IsNullOrEmpty(nazvanie))
            {
                search = search.Where(c => c.name.Contains(nazvanie));
            }
            return View(search);
        }
        //
        // GET: /Home/Details/5
        public ActionResult Details(int id)
        {
            var article = articleDAO.getAllArticles().First(m => m.IdArticle == id);
            if (article != null)
            {
                return View("Details", article);
            }
            else
            {
                return HttpNotFound();
            }
        }

        protected bool ViewDataSelectList(int idTest)
        {
            var test = testDAO.getAllTests();
            ViewData["IdTest"] = new SelectList(test, "IdTest", "name", idTest);
            return test.Count() > 0;
        }

        public ActionResult Create(int id)
        {
            Article c = new Article();
            c.idTest = id;
            c.text = null;
            c.dataAdd = DateTime.Now;
            if (!ViewDataSelectList(-1))
                return RedirectToAction("Index");
            return View("Create", c);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create(int idTest, [Bind(Exclude = "IdTest")] Article article)
        {
            try
            {
                if (articleDAO.addArticle(idTest, article))
                    return RedirectToAction("Index", "Home");
                else
                {
                    ViewDataSelectList(idTest);
                    return View("Create");
                }

            }
            catch
            {
                return View("Create");
            }
        }
        //
        // GET: /Home/Edit/5
        public ActionResult Edit(int id)
        {

            var article= articleDAO.getAllArticles().First(m => m.IdArticle == id);
            ViewData.Model = article;
            return View();
        }
        //
        // POST: /Home/Edit/5
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Edit(int id, FormCollection collection)
        {

            try
            {
                var article = articleDAO.getAllArticles().First(m => m.IdArticle == id);

                UpdateModel(article);
                articleDAO.editArticle(article);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: /Movies/Delete/5
        //[Authorize(Roles = "Administrator")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var article = articleDAO.getAllArticles().First(m => m.IdArticle == id);
            if (article == null)
            {
                return HttpNotFound();
            }
            return View(article);
        }

        // POST: /Movies/Delete/5
        [HttpPost, ActionName("Delete")]
       // [ValidateAntiForgeryToken]
        //[Authorize(Roles = "Administrator")]
        public ActionResult DeleteConfirmed(int id)
        {
            
            try
            {
                var article = articleDAO.getAllArticles().First(m => m.IdArticle == id);
                articleDAO.deleteArticle(article);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult SearchForArticle(string nazvanie)
        {
            var names = from s in _entities.Articles select s;
            if (!String.IsNullOrEmpty(nazvanie))
            {
                names = names.Where(c => c.name.Contains(nazvanie));
            }
            return View();
        }
    }
}
