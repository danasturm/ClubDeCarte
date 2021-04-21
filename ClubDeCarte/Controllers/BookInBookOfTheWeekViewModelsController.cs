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
    public class BookInBookOfTheWeekViewModelsController : Controller
    {
        private BookClubDBContext db = new BookClubDBContext();

        // GET: BookInBookOfTheWeekViewModels
        public ActionResult Index()
        {
            return View(db.BookInBookOfTheWeekViewModels.ToList());
        }

        // GET: BookInBookOfTheWeekViewModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookInBookOfTheWeekViewModel bookInBookOfTheWeekViewModel = db.BookInBookOfTheWeekViewModels.Find(id);
            if (bookInBookOfTheWeekViewModel == null)
            {
                return HttpNotFound();
            }
            return View(bookInBookOfTheWeekViewModel);
        }

        // GET: BookInBookOfTheWeekViewModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BookInBookOfTheWeekViewModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BookInBookOfTheWeekViewModelID,BookOfTheWeekID,BookID,Title,UrlPhotoCover,Description,ValidFrom,ValidTo")] BookInBookOfTheWeekViewModel bookInBookOfTheWeekViewModel)
        {
            if (ModelState.IsValid)
            {
                db.BookInBookOfTheWeekViewModels.Add(bookInBookOfTheWeekViewModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bookInBookOfTheWeekViewModel);
        }

        // GET: BookInBookOfTheWeekViewModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookInBookOfTheWeekViewModel bookInBookOfTheWeekViewModel = db.BookInBookOfTheWeekViewModels.Find(id);
            if (bookInBookOfTheWeekViewModel == null)
            {
                return HttpNotFound();
            }
            return View(bookInBookOfTheWeekViewModel);
        }

        // POST: BookInBookOfTheWeekViewModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BookInBookOfTheWeekViewModelID,BookOfTheWeekID,BookID,Title,UrlPhotoCover,Description,ValidFrom,ValidTo")] BookInBookOfTheWeekViewModel bookInBookOfTheWeekViewModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bookInBookOfTheWeekViewModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bookInBookOfTheWeekViewModel);
        }

        // GET: BookInBookOfTheWeekViewModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookInBookOfTheWeekViewModel bookInBookOfTheWeekViewModel = db.BookInBookOfTheWeekViewModels.Find(id);
            if (bookInBookOfTheWeekViewModel == null)
            {
                return HttpNotFound();
            }
            return View(bookInBookOfTheWeekViewModel);
        }

        // POST: BookInBookOfTheWeekViewModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BookInBookOfTheWeekViewModel bookInBookOfTheWeekViewModel = db.BookInBookOfTheWeekViewModels.Find(id);
            db.BookInBookOfTheWeekViewModels.Remove(bookInBookOfTheWeekViewModel);
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
