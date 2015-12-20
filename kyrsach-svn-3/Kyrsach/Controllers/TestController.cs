using System;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Kyrsach.Models;
using Kyrsach.DAO;

namespace Kyrsach.Controllers
{
    public class TestController : Controller
    {
        private Database1Entities1 _entities = new Database1Entities1();
        TestDAO TestDAO = new TestDAO();


        public ActionResult Index(string nazvanie)
        {
            var search = from s in _entities.Tests select s;
            if (!String.IsNullOrEmpty(nazvanie))
            {
                search = search.Where(c => c.Name.Contains(nazvanie));
            }
            return View(search);
        }
        //
        // GET: /Home/Details/5

        public ActionResult Details(int id)
        {
            var test = TestDAO.getAllTests().First(m => m.IdTest == id);
            if (test != null)
            {
                return View("Details", test);
            }
            else
            {
                return HttpNotFound();
            }
        }

        public ActionResult Create()
        {
            Test c = new Test();
            c.Date = DateTime.Now;
            return View("Create", c);
        }

        // POST: /Home/Create
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create([Bind(Exclude = "IdTest")] Test test)
        {
            try
            {
                if (ModelState.IsValid && TestDAO.addTest(test))

                    return RedirectToAction("Index");
                else
                    return View("Create");
            }
            catch
            {
                return View("Create");
            }
        }
        //
        // GET: /Home/Edit/5
        //   [Authorize(Roles = "Administrator")]
        public ActionResult Edit(int id)
        {
            var test = TestDAO.getAllTests().First(m => m.IdTest == id);
            ViewData.Model = test;
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
                var test = TestDAO.getAllTests().First(m => m.IdTest == id);

                UpdateModel(test);
                TestDAO.editTest(test);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: /Movies/Delete/5
        //   [Authorize(Roles = "Administrator")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var test = TestDAO.getAllTests().First(m => m.IdTest == id);
            if (test == null)
            {
                return HttpNotFound();
            }
            return View(test);
        }

        // POST: /Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        // [ValidateAntiForgeryToken]
        //  [Authorize(Roles = "Administrator")]
        public ActionResult DeleteConfirmed(int id)
        {

            try
            {
                var test = TestDAO.getAllTests().First(m => m.IdTest == id);
                TestDAO.deleteTest(test);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
