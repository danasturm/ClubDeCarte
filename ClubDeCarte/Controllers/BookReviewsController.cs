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

namespace ClubDeCarte.Controllers
{
    public class BookReviewsController : Controller
    {
        private BookClubDBContext db = new BookClubDBContext();

        // [Authorize(Roles = "User, Admin")]
        public ActionResult Index(string sortOrder, string searchString)
        {
            ViewBag.TitleSortParm = string.IsNullOrEmpty(sortOrder) ? "title_desc" : "";
            ViewBag.DateSortParam = sortOrder == "Date" ? "date_desc" : "Date";

            var books = from b in db.BookReviews select b;
            if (!string.IsNullOrEmpty(searchString))
            {
                books = books.Where(b => b.TitleReview.Contains(searchString) || b.Tags.Contains(searchString) ||
                                         b.AddedBy.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "title_desc":
                    books = books.OrderByDescending(b => b.TitleReview);
                    break;
                case "Date":
                    books = books.OrderBy(b => b.AddedOn);
                    break;
                case "date_desc":
                    books = books.OrderByDescending(b => b.AddedOn);
                    break;
                default:
                    books = books.OrderBy(b => b.TitleReview);
                    break;
            }
            return View(books.ToList());
        }

        [Authorize(Roles = "User, Admin")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookReview bookReview = db.BookReviews.Find(id);
            if (bookReview == null)
            {
                return HttpNotFound();
            }
            return View(bookReview);
        }

        //[Authorize(Roles = "User, Admin")]
        public ActionResult Create()
        {
            return View();
        }

        [Authorize(Roles = "User, Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BookReviewID,ReviewPhoto,TitleReview,Description,AddedBy,AddedOn,Tags")] BookReview bookReview)
        {
            if (ModelState.IsValid)
            {
                db.BookReviews.Add(bookReview);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bookReview);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookReview bookReview = db.BookReviews.Find(id);
            if (bookReview == null)
            {
                return HttpNotFound();
            }
            return View(bookReview);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BookReviewID,ReviewPhoto,TitleReview,Description,AddedBy,AddedOn,Tags")] BookReview bookReview)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bookReview).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bookReview);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookReview bookReview = db.BookReviews.Find(id);
            if (bookReview == null)
            {
                return HttpNotFound();
            }
            return View(bookReview);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BookReview bookReview = db.BookReviews.Find(id);
            db.BookReviews.Remove(bookReview);
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
