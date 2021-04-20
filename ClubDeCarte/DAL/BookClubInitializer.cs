using ClubDeCarte.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ClubDeCarte.DAL
{
    public class BookClubInitializer : DropCreateDatabaseIfModelChanges<BookClubDBContext>
    {
        protected override void Seed(BookClubDBContext context)
        {
            var authors = new List<Author>
            {
                new Author {AuthorID = 0001, FirstName = "Agatha", LastName = "Cristie"},
                new Author {AuthorID = 0002, FirstName = "George RR", LastName = "Martin"},
                new Author {AuthorID = 0003, FirstName = "Eric-Emmanuel", LastName = "Schmit"},
                new Author {AuthorID = 0004, FirstName = "Frank", LastName = "Herbert"},
                new Author {AuthorID = 0005, FirstName = "Elena", LastName = "Ferrante"},
                new Author {AuthorID = 0006, FirstName = "Maren", LastName = "Stoffels"},
                new Author {AuthorID = 0007, FirstName = "Walter", LastName = "Tevis"},
                new Author {AuthorID = 0008, FirstName = "Emily", LastName = "Gunnis"},
                new Author {AuthorID = 0009, FirstName = "Mihail", LastName = "Soare"},
                new Author {AuthorID = 0010, FirstName = "John", LastName = "Steinbeck"}
            };
            authors.ForEach(a => context.Authors.Add(a));
            context.SaveChanges();

            var books = new List<Book>
            {
                new Book {BookID = 10001, Title = "Moarte printre nori", AuthorID = 0001, PublishingHouse = "Litera", ISBN = "9786063368486", Pages = 320 },
                new Book {Title = "Petrecerea de Halloween", AuthorID = 0001, PublishingHouse = "Litera", ISBN = "9786063366802", Pages = 320 },
                new Book {Title = "Cu cartile pe fata", AuthorID = 0001, PublishingHouse = "Litera", ISBN = "9786063368554", Pages = 264 },
                new Book {Title = "Urzeala tronurilor", AuthorID = 0002, PublishingHouse = "Armada", ISBN = "9786064309808" },
                new Book {Title = "Jurnalul unei iubiri pierdute", AuthorID = 0003, PublishingHouse = "Humanitas Fiction", ISBN = "9786067797671", Pages = 216},
                new Book {Title = "Omul care vedea dincolo de chipuri", AuthorID = 0003, PublishingHouse = "Humanitas Fiction", ISBN = "9786067793796", Pages = 304},
                new Book {Title = "Dragoste, pupeze si colaci", AuthorID = 0009, PublishingHouse = "Hoffman", ISBN = "9786064610706", Pages = 340},
                new Book {Title = "Fetita pierduta", AuthorID = 0008, PublishingHouse = "Litera", ISBN = "9786063372797", Pages = 352},
                new Book {Title = "Fetita din scrisoare", AuthorID = 0008, PublishingHouse = "Litera", ISBN = "9786063344589", Pages = 400},
                new Book {Title = "Gambitul Damei", AuthorID = 0007, PublishingHouse = "Bookzone", ISBN = "9786069700129", Pages = 250},
                new Book {Title = "Escape Room - Camera groazei", AuthorID = 0006, PublishingHouse = "Publisol", ISBN = "9786069739020"},
                new Book {Title = "Viata mincinoasa a adultilor", AuthorID = 0005, PublishingHouse = "Trei", ISBN = "9786069783634", Pages = 304},
                new Book {Title = "Prietena mea geniala", AuthorID = 0005, PublishingHouse = "Pandora M", ISBN = "9786069782033", Pages = 336},
                new Book {Title = "Dune", AuthorID = 0004, PublishingHouse = "Armada", ISBN = "9786064305251"},
                new Book {Title = "A fost odata un razboi", AuthorID = 0010, PublishingHouse = "Polirom", ISBN = "9789734682652", Pages = 264},
                new Book {Title = "Soareci si oameni", AuthorID = 0010, PublishingHouse = "Polirom", Pages = 160},
                new Book {Title = "Poneiul rosu", AuthorID = 0010, PublishingHouse = "Polirom", ISBN = "9789734682652", Pages = 180}
            };
            books.ForEach(b => context.Books.Add(b));
            context.SaveChanges();

            var bookReviews = new List<BookReview>
            {
                new BookReview {BookReviewID = 001, ReviewPhoto = "https://cdn.dc5.ro/img-prod/9789734633807-2481278-240.jpg", TitleReview = "Soareci si oameni", Description = "Romanul Șoareci și oameni, publicat în 1937, are ca fundal cele două mari probleme cu care s-a confruntat America la începutul anilor ’30: criza financiară și seceta care au afectat soarta fermierilor și a muncitorilor. Miezul romanului, însă, se află în relația dintre George și Lennie, ideal al prieteniei și sprijinului și în substanța tragică a misiunii lor: achiziționarea unor terenuri și construirea propriei case, vis care prinde contur până la un punct. Eșecul este însă vizibil în fiecare gest și ieșire a lui Lennie, om al naturii și al instinctului, cu o forță fizică incredibilă din care se alimentează idealul măreț, dar care sfârșește prin a-l nărui. Este, în ansamblu, atât un roman reprezentativ pentru un anumit peisaj temporal și social, dar mai mult este romanul prieteniei și singurătății, al fragilității ființei umane și a idealurilor pe care aceasta și le construiește. Romanul merită citit pentru doza lui de document, pentru o poveste foarte frumos conturată și gradată și pentru construcția personajelor: emoționante, empatice, cu reacții  pe cât de neașteptate, pe atât de justificabile din punct de vedere uman.",
                AddedOn = DateTime.Now, Tags = "1937, America"},
                new BookReview {BookReviewID = 002, ReviewPhoto = "", TitleReview = "Prietena mea geniala", Description = "În această carte, Elena Ferrante ne duce într-o suburbie din Napoli în a doua perioadă postbelică și ne face să trăim întâmplările prin ochii micuței Elena Greco. Prin copil, suntem scufundați în atmosfera din cartier, alcătuit din oameni care trăiesc, muncesc, se îndrăgostesc și ale căror povești sunt observate prin lentila vieții de zi cu zi. Pe lângă faptul că această poveste ne ține lipiți de paginile cărții, jucăm un rol activ în viața Elenei, care abandonează încet lumea copilăriei și învață să cunoască realitatea existenței.Această carte pare să conțină elemente biografice ale autoarei, nu există informații clare despre biografia Elenei Ferrante, decât orașul ei natal, Napoli tocmai pentru care este natural să recunoaștem în tânărul ei protagonist omonim cu aspirații de scriitor o urmă a vieții autoarei.",
                AddedOn = DateTime.Now, Tags = "Napoli, Italia, 1950, Biografie"}
            };
            bookReviews.ForEach(bR => context.BookReviews.Add(bR));
            context.SaveChanges();
        }
    }
}