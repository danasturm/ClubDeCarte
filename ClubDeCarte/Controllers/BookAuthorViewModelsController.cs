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
            ViewBag.OtherAuthorSortParm = sortOrder == "OtherAuthors" ? "other_desc" : "OtherAuthors";
           
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            StringComparer currCmp = StringComparer.CurrentCulture;
            StringComparer currICCmp = StringComparer.CurrentCultureIgnoreCase;

            List<BookAuthorViewModel> bookAuthorPairs = new List<BookAuthorViewModel>();
            IEnumerable<Book> books = from b in db.Books select b;
            foreach (Book carte in books)
            {
                BookAuthorViewModel bookAuthorPair = new BookAuthorViewModel();
                bookAuthorPair.BookID = carte.BookID;
                bookAuthorPair.Title = carte.Title;
                bookAuthorPair.AuthorID = carte.AuthorID;
                bookAuthorPair.OtherAuthors = carte.OtherAuthors;
                bookAuthorPair.PublishingHouse = carte.PublishingHouse;
                bookAuthorPair.ISBN = carte.ISBN;
                bookAuthorPair.Pages = carte.Pages;
                bookAuthorPair.UrlPhotoCover = carte.UrlPhotoCover;
                bookAuthorPairs.Add(bookAuthorPair);
            }

            IEnumerable<Author> authors = from a in db.Authors select a;
            foreach (BookAuthorViewModel entry in bookAuthorPairs)
            {
                Author mainAuthor = authors.FirstOrDefault(a => a.AuthorID == entry.AuthorID);
                if (null != mainAuthor)
                {
                    entry.FirstName = mainAuthor.FirstName;
                    entry.LastName = mainAuthor.LastName;
                }
            }


            if (!string.IsNullOrEmpty(searchString))
            {
                bookAuthorPairs = (List<BookAuthorViewModel>)bookAuthorPairs.Where(b =>
                                         b.Title.Contains(searchString) ||
                                         b.ISBN.Contains(searchString) ||
                                         b.PublishingHouse.Contains(searchString) ||
                                         b.LastName.Contains(searchString) ||
                                         b.FirstName.Contains(searchString)).ToList();
            }


            switch (sortOrder)
            {
            case "title_desc":
                 bookAuthorPairs = bookAuthorPairs.OrderByDescending(b => b.Title).ToList();
                 break;
            case "OtherAuthors":
                 bookAuthorPairs = bookAuthorPairs.OrderBy(b => b.LastName).ToList();
                 break;
            case "other_desc":
                 bookAuthorPairs = bookAuthorPairs.OrderByDescending(b => b.LastName).ToList();
                 break;
            default:
                 bookAuthorPairs = bookAuthorPairs.OrderBy(b => b.Title).ToList();
                 break;
            }
            int pageSize = 5;
            int pageNumber = (page ?? 1);
            return View(bookAuthorPairs.ToPagedList(pageNumber, pageSize));
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
