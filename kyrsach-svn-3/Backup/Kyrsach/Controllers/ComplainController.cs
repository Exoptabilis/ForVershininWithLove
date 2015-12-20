using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using System.Data.Entity;
using System.Data;
using System.Data.SqlClient;
using Kyrsach.Models;
using Kyrsach.DAO;

namespace Kyrsach.Controllers
{
    public class ComplainController : Controller
    {
        //
        // GET: /Contact/
       ComplainDAO complainDAO = new ComplainDAO();
       ArticleDAO articleDAO = new ArticleDAO();

        public ActionResult Index(int? id)
        {
            ViewData["article"] = articleDAO.getAllArticles();
            return View(complainDAO.getAllComplains());
        }

        public ActionResult Details(int id)
        {
                return View(complainDAO.getComplain(id));
           
        }

        protected bool ViewDataSelectList(int idArticle)
        {
            var article = articleDAO.getAllArticles();
            ViewData["idArticle"] = new SelectList(article, "IdArticle", "name", idArticle);
            return article.Count() > 0;
        }

        public ActionResult Create(int id)
        {
            Complain c = new Complain();
            c.idArticle = id;
            c.type = null;
            c.text = null;
            c.dataAdd = DateTime.Now;
            if (!ViewDataSelectList(-1))
                return RedirectToAction("Index");
            return View("Create", c);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create(int idArticle, [Bind(Exclude = "IdArticle")] Complain complain)
        {
            try
            {
                if (complainDAO.addComplain(idArticle, complain))
                    return RedirectToAction("Index","Home");
                else
                {
                    ViewDataSelectList(idArticle);
                    return View("Create");
                }
                   
            }
            catch
            {
                return View("Create");
            }
        }

        [Authorize(Roles = "Client")]
        public ActionResult Edit(int id)
        {
            Complain complain = complainDAO.getComplain(id);
            if (!ViewDataSelectList(Convert.ToInt32(complain.Article.IdArticle)))
                return RedirectToAction("Index");
            return View(complainDAO.getComplain(id));
        }


        [AcceptVerbs(HttpVerbs.Post)]
        [Authorize(Roles = "Client")]
        public ActionResult Edit(int idArticle, int id, Complain complain)
        {

            if (complainDAO.editComplain(idArticle, complain))
                return RedirectToAction("Index");
            else
            {
                ViewDataSelectList(-1);
                return View("Edit", complainDAO.getComplain(id));
            }
        }

        [Authorize(Roles = "Client")]
        public ActionResult Delete(int id)
        {
            return View("Delete", complainDAO.getComplain(id));
        }

        [HttpPost, ActionName("Delete")]
        [Authorize(Roles = "Clients")]
        public ActionResult Delete(int id, Complain complain)
        {

            if (complainDAO.deleteComplain(id))
                return RedirectToAction("Index");
            else return View("Delete", complainDAO.getComplain(id));

        }
    }
}
