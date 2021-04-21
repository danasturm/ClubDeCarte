using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ClubDeCarte.DAL;
using ClubDeCarte.Models;
using PagedList;

namespace ClubDeCarte.Controllers
{
    public class BookAuthorViewModelsController : Controller
    {
        private BookClubDBContext db = new BookClubDBContext();

        [Authorize(Roles = "User, Admin")]
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {

            ViewBag.CurrentSort = sortOrder;
            ViewBag.TitleSortParm = string.IsNullOrEmpty(sortOrder) ? "title_desc" : "";
            ViewBag.OtherAutorSortParm = sortOrder == "OtherAuthors" ? "other_desc" : "OtherAuthors";
           
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var books = from b in db.BookAuthorViewModels select b;

            if (!string.IsNullOrEmpty(searchString))
            {
                books = books.Where(b => b.Title.Contains(searchString) || b.OtherAuthors.Contains(searchString) ||
                                         b.ISBN.Contains(searchString) || b.PublishingHouse.Contains(searchString) ||
                                         b.LastName.Contains(searchString) || b.FirstName.Contains(searchString));

            }
            switch (sortOrder)
            {
                case "title_desc":
                    books = books.OrderByDescending(b => b.Title);
                    break;
                case "OtherAuthors":
                    books = books.OrderBy(b => b.LastName);
                    break;
                case "other_desc":
                    books = books.OrderByDescending(b => b.LastName);
                    break;
                default:
                    books = books.OrderBy(b => b.Title);
                    break;
            }
            int pageSize = 5;
            int pageNumber = (page ?? 1);
            return View(books.ToPagedList(pageNumber, pageSize));
        }

        [Authorize(Roles = "User, Admin")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookAuthorViewModel bookAuthorViewModel = db.BookAuthorViewModels.Find(id);
            if (bookAuthorViewModel == null)
            {
                return HttpNotFound();
            }
            return View(bookAuthorViewModel);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BookAuthorViewModelID,BookID,AuthorID,UrlPhotoCover,FirstName,LastName,Title,OtherAuthors,PublishingHouse,ISBN,Pages")] BookAuthorViewModel bookAuthorViewModel)
        {
            if (ModelState.IsValid)
            {
                db.BookAuthorViewModels.Add(bookAuthorViewModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bookAuthorViewModel);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookAuthorViewModel bookAuthorViewModel = db.BookAuthorViewModels.Find(id);
            if (bookAuthorViewModel == null)
            {
                return HttpNotFound();
            }
            return View(bookAuthorViewModel);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BookAuthorViewModelID,BookID,AuthorID,UrlPhotoCover,FirstName,LastName,Title,OtherAuthors,PublishingHouse,ISBN,Pages")] BookAuthorViewModel bookAuthorViewModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bookAuthorViewModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bookAuthorViewModel);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookAuthorViewModel bookAuthorViewModel = db.BookAuthorViewModels.Find(id);
            if (bookAuthorViewModel == null)
            {
                return HttpNotFound();
            }
            return View(bookAuthorViewModel);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BookAuthorViewModel bookAuthorViewModel = db.BookAuthorViewModels.Find(id);
            db.BookAuthorViewModels.Remove(bookAuthorViewModel);
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
