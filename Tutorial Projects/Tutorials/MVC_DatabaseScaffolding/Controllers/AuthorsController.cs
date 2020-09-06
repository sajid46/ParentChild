using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVC_DatabaseScaffolding.Models;

namespace MVC_DatabaseScaffolding.Controllers
{
    public class AuthorsController : Controller
    {
        private PropertyDBEntities db = new PropertyDBEntities();

        // GET: Authors
        private IClassDI _classDI;
        public ActionResult Index(IClassDI classDI)
        {
            this._classDI = classDI;

            //var lst = (from a in db.Authors
            //           join b in db.Books on a.ID equals b.AuthorID into ab
            //           from c in ab.DefaultIfEmpty()
            //           orderby a.ID
            //           select new
            //           {
            //               ID = a.ID,
            //               Author1 = a.Author1,
            //               Book1 = c.Book1,
            //               Price = c.Price,
            //               BookId = (int?)c.ID 
            //           }).ToList();

            

            //var lst = (from a in db.vw_AutherBook select a).ToList();

            //vw_AutherBook vw_autherBook;
            List<vw_AutherBook> lst_vw_AutherBooks = new List<vw_AutherBook>();
            lst_vw_AutherBooks = _classDI.Get();
            //foreach (var item in lst)
            //{
            //    vw_autherBook = new vw_AutherBook();
            //    vw_autherBook.ID = item.ID;
            //    vw_autherBook.Author = item.Author;
            //    vw_autherBook.Book = item.Book;
            //    vw_autherBook.BookID = item.BookID;
            //    vw_autherBook.Price = item.Price;
            //    lst_vw_AutherBooks.Add(vw_autherBook);

            //}



            return View(lst_vw_AutherBooks);

                        //return View(db.Authors.ToList());
        }

        // GET: Authors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Author author = db.Authors.Find(id);
            if (author == null)
            {
                return HttpNotFound();
            }
            return View(author);
        }

        // GET: Authors/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Authors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Author1")] Author author)
        {
            if (ModelState.IsValid)
            {
                db.Authors.Add(author);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(author);
        }

        // GET: Authors/Edit/5
        public ActionResult Edit(int? id, int? bookId)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Author author = db.Authors.Find(id);
            Book book = db.Books.Find(bookId);

            vw_AutherBook authorbook = new vw_AutherBook();
            //authorbook.Author = author.Author1;
            //authorbook.Book = book.Book1;



            if (author == null)
            {
                return HttpNotFound();
            }
            return View(authorbook);
        }

        // POST: Authors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Author1")] Author author)
        {
            if (ModelState.IsValid)
            {
                db.Entry(author).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(author);
        }

        // GET: Authors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Author author = db.Authors.Find(id);
            if (author == null)
            {
                return HttpNotFound();
            }
            return View(author);
        }

        // POST: Authors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Author author = db.Authors.Find(id);
            db.Authors.Remove(author);
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
