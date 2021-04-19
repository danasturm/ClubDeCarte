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
    public class BookOfTheWeeksController : Controller
    {
        private BookClubDBContext db = new BookClubDBContext();

       
        public ActionResult Index()
        {
            return View(db.BookOfTheWeeks.ToList());
        }

        
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookOfTheWeek bookOfTheWeek = db.BookOfTheWeeks.Find(id);
            if (bookOfTheWeek == null)
            {
                return HttpNotFound();
            }
            return View(bookOfTheWeek);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BookOfTheWeekID,BookID,ValidFrom,ValidTo")] BookOfTheWeek bookOfTheWeek)
        {
            if (ModelState.IsValid)
            {
                db.BookOfTheWeeks.Add(bookOfTheWeek);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bookOfTheWeek);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookOfTheWeek bookOfTheWeek = db.BookOfTheWeeks.Find(id);
            if (bookOfTheWeek == null)
            {
                return HttpNotFound();
            }
            return View(bookOfTheWeek);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BookOfTheWeekID,BookID,ValidFrom,ValidTo")] BookOfTheWeek bookOfTheWeek)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bookOfTheWeek).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bookOfTheWeek);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookOfTheWeek bookOfTheWeek = db.BookOfTheWeeks.Find(id);
            if (bookOfTheWeek == null)
            {
                return HttpNotFound();
            }
            return View(bookOfTheWeek);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BookOfTheWeek bookOfTheWeek = db.BookOfTheWeeks.Find(id);
            db.BookOfTheWeeks.Remove(bookOfTheWeek);
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
