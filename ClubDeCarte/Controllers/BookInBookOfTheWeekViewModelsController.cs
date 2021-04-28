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

      
        public ActionResult Index()
        {
            List<BookInBookOfTheWeekViewModel> bookOfTheWeekPairs = new List<BookInBookOfTheWeekViewModel>();
            IEnumerable<BookOfTheWeek> bookOfTheWeeks = from bW in db.BookOfTheWeeks select bW;
            foreach (BookOfTheWeek carteaSaptamanii in bookOfTheWeeks)
            {
                BookInBookOfTheWeekViewModel aboutBook = new BookInBookOfTheWeekViewModel();
                aboutBook.BookOfTheWeekID = carteaSaptamanii.BookOfTheWeekID;
                aboutBook.BookID = carteaSaptamanii.BookID;
                aboutBook.Description = carteaSaptamanii.Description;
                aboutBook.ValidFrom = carteaSaptamanii.ValidFrom;
                aboutBook.ValidTo = carteaSaptamanii.ValidTo;
                bookOfTheWeekPairs.Add(aboutBook);
            }

            IEnumerable<Book> books = from b in db.Books select b;
            foreach (BookInBookOfTheWeekViewModel entry in bookOfTheWeekPairs)
            {
                Book aboutBook = books.FirstOrDefault(b => b.BookID == entry.BookID);
                if (null != aboutBook)
                {
                    entry.Title = aboutBook.Title;
                    entry.UrlPhotoCover = aboutBook.UrlPhotoCover;
                }
            }


            return View(bookOfTheWeekPairs.ToList());
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
