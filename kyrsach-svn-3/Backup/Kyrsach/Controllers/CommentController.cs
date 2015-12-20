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
    public class CommentController : Controller
    {
        //
        // GET: /Contact/
       CommentDAO commentDAO = new CommentDAO();
       ArticleDAO articleDAO = new ArticleDAO();

        public ActionResult Index(int? id)
        {
            ViewData["article"] = articleDAO.getAllArticles();
            return View(commentDAO.getAllComments());
        }

        public ActionResult Details(int id)
        {
            return View(commentDAO.getComment(id));
           
        }

        protected bool ViewDataSelectList(int idArticle)
        {
            var article = articleDAO.getAllArticles();
            ViewData["idArticle"] = new SelectList(article, "IdArticle", "name", idArticle);
            return article.Count() > 0;
        }

        public ActionResult Create(int id)
        {
            Comment c = new Comment();
            c.idArticle = id;
            c.text = null;
            c.dataAdd = DateTime.Now;
            if (!ViewDataSelectList(-1))
                return RedirectToAction("Index");
            return View("Create", c);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create(int idArticle, [Bind(Exclude = "IdArticle")] Comment comment)
        {
            try
            {
                if (commentDAO.addComment(idArticle, comment))
                    return RedirectToAction("Index", "Home");
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

        [Authorize(Roles = "Client, Manager")]
        public ActionResult Edit(int id)
        {
            Comment comment = commentDAO.getComment(id);
            if (!ViewDataSelectList(Convert.ToInt32(comment.Article.IdArticle)))
                return RedirectToAction("Index");
            return View(commentDAO.getComment(id));
        }


        [AcceptVerbs(HttpVerbs.Post)]
        [Authorize(Roles = "Client, Manager")]
        public ActionResult Edit(int idArticle, int id, Comment comment)
        {

            if (commentDAO.editComment(idArticle, comment))
                return RedirectToAction("Index");
            else
            {
                ViewDataSelectList(-1);
                return View("Edit", commentDAO.getComment(id));
            }
        }
        [Authorize(Roles = "Client, Manager")]
        public ActionResult Delete(int id)
        {
            return View("Delete", commentDAO.getComment(id));
        }

        [HttpPost, ActionName("Delete")]
        [Authorize(Roles = "Client, Manager")]
        public ActionResult Delete(int id, Comment comment)
        {

            if (commentDAO.deleteComment(id))
                return RedirectToAction("Index");
            else return View("Delete", commentDAO.getComment(id));

        }
    }
}
