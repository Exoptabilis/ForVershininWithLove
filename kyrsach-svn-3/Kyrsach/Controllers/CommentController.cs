using System;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Kyrsach.Models;
using Kyrsach.DAO;
using WebMatrix.WebData;
using System.Data;


namespace Kyrsach.Controllers
{
    public class CommentController : Controller
    {
        private Database1Entities1 _entities = new Database1Entities1();
        UsersContext _user = new UsersContext();

        CommentDAO commentDAO = new CommentDAO();
        TestDAO testDAO = new TestDAO();

        //
        // GET: /Home/Details/5
        public ActionResult Details(int id)
        {
            var comment = commentDAO.getAllComents().First(m => m.IdComment == id);
            if (comment != null)
            {
                comment.Mark = 10;
                    if (comment.Answer1 != comment.Test.Answer1)
                    {
                        comment.Mark -= 2;
                    }
                    if (comment.Answer2 != comment.Test.Answer2)
                    {
                        comment.Mark -= 2;
                    }
                    if (comment.Answer3 != comment.Test.Answer3)
                    {
                        comment.Mark -= 2;
                    }
                    if (comment.Answer4 != comment.Test.Answer4)
                    {
                        comment.Mark -= 2;
                    }
                    if (comment.Answer5 != comment.Test.Answer5)
                    {
                        comment.Mark -= 2;
                    }
                _entities.SaveChanges();
                return View("Details", comment);
            }
            else
            {
                return HttpNotFound();
            }
        }

        public ActionResult Index(string nazvanie)
        {
            var search = from s in _entities.Comments select s;
            if (!String.IsNullOrEmpty(nazvanie))
            {
                search = search.Where(c => c.UserName.Contains(nazvanie));
            }
            return View(search);
        }

        protected bool ViewDataSelectList(int idTest)
        {
            var test = testDAO.getAllTests();
            ViewData["IdTest"] = new SelectList(test, "IdTest", "name", idTest);
            return test.Count() > 0;
        }
        //
        // GET: /Home/Create
        public ActionResult Create(int id = 0)
        {
            Comment c = new Comment();
            c.idTest = id;
            c.Test = testDAO.getTest(id);
            c.UserName = WebSecurity.CurrentUserName;
            c.dataAdd = DateTime.Now;
            if (!ViewDataSelectList(-1))
                return RedirectToAction("Index");
            return View("Create", c);
        }
        //
        // POST: /Home/Create
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create(int idTest,[Bind(Exclude = "IdComment")] Comment comment)
        {
            try
            {   
                comment.Test = testDAO.getTest(idTest);

                if (ModelState.IsValid && commentDAO.addComment(idTest, WebSecurity.CurrentUserName, comment))

                    return RedirectToAction("Index");
                else
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            catch
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
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
            var coment = commentDAO.getAllComents().First(m => m.IdComment == id);
            if (coment == null)
            {
                return HttpNotFound();
            }
            return View(coment);
        }

        // POST: /Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        // [ValidateAntiForgeryToken]
        //[Authorize(Roles = "Administrator")]
        public ActionResult DeleteConfirmed(int id)
        {

            try
            {
                var comment = commentDAO.getAllComents().First(m => m.IdComment == id);
                commentDAO.deleteComment(comment);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            var comment = commentDAO.getAllComents().First(m => m.IdComment == id);
            ViewData.Model = comment;
            return View();
        }
        //
        // POST: /Home/Edit/5
        [AcceptVerbs(HttpVerbs.Post)]
        //  [Authorize(Roles = "Administrator")]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                var comment = commentDAO.getAllComents().First(m => m.IdComment == id);

                UpdateModel(comment);
                commentDAO.editComment(comment);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }

}
