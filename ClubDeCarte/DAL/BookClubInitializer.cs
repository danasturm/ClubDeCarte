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
                new Book {Title = "Petrecerea de Halloween", AuthorID = 0001, PublishingHouse = "Litera", ISBN = "9786063366802", Pages = 320, UrlPhotoCover = "https://s13emagst.akamaized.net/products/742/741205/images/res_7fd5ef1071c0fc3cca12039e27d2d772.jpg?width=450&height=450&hash=2C79D408878A7496117669C9A3911F55" },
                new Book {Title = "Cu cartile pe fata", AuthorID = 0001, PublishingHouse = "Litera", ISBN = "9786063368554", Pages = 264, UrlPhotoCover = "http://mcdn.elefant.ro/mnresize/150/150/images/18/225718/cu-cartile-pe-fata-agatha-christie_1_fullsize.jpg" },
                new Book {Title = "Urzeala tronurilor", AuthorID = 0002, PublishingHouse = "Armada", ISBN = "9786064309808", Pages = 940, UrlPhotoCover = "https://nemira.ro/media/catalog/product/cache/1/image/650x/040ec09b1e35df139433887a97daa66f/b/o/boxset_got_cantec-de-gheata-si-foc.jpg" },
                new Book {Title = "Jurnalul unei iubiri pierdute", AuthorID = 0003, PublishingHouse = "Humanitas Fiction", ISBN = "9786067797671", Pages = 216, UrlPhotoCover = "https://s13emagst.akamaized.net/products/35886/35885686/images/res_f2e0c4eaae272d7fcf58a5f1f1be3332.jpg?width=450&height=450&hash=02F1637E071CB196B953524A8A5ECE4D5" },
                new Book {Title = "Omul care vedea dincolo de chipuri", AuthorID = 0003, PublishingHouse = "Humanitas Fiction", ISBN = "9786067793796", Pages = 304, UrlPhotoCover = "https://s13emagst.akamaized.net/products/15485/15484650/images/res_0f81cc0199a87ccb1f654b788ca734c5.jpg?width=450&height=450&hash=690474C74783974DE78670EC3A38F555" },
                new Book {Title = "Dragoste, pupeze si colaci", AuthorID = 0009, PublishingHouse = "Hoffman", ISBN = "9786064610706", Pages = 340, UrlPhotoCover = "https://s13emagst.akamaized.net/products/33196/33195443/images/res_2604ec99adaab969b5bad8ce00936b89.jpg?width=450&height=450&hash=F88C0CE2FC2D675A898606CDFC1620B7" },
                new Book {Title = "Fetita pierduta", AuthorID = 0008, PublishingHouse = "Litera", ISBN = "9786063372797", Pages = 352, UrlPhotoCover = "https://s13emagst.akamaized.net/products/36572/36571795/images/res_b6447036ae62aeb145cd858b6338818f.jpg?width=450&height=450&hash=2D23C548E685AD2CACDAD791DEA97BB2" },
                new Book {Title = "Fetita din scrisoare", AuthorID = 0008, PublishingHouse = "Litera", ISBN = "9786063344589", Pages = 400, UrlPhotoCover = "https://s13emagst.akamaized.net/products/26790/26789081/images/res_78185ba28be3bae523df4b88f2db102c.jpg?width=450&height=450&hash=3782CD0BE750ECFC20EF1013792C0FAC" },
                new Book {Title = "Gambitul Damei", AuthorID = 0007, PublishingHouse = "Bookzone", ISBN = "9786069700129", Pages = 250, UrlPhotoCover = "https://bookzone.ro/landings/gambitul-damei/img/Carte.png" },
                new Book {Title = "Escape Room - Camera groazei", AuthorID = 0006, PublishingHouse = "Publisol", ISBN = "9786069739020", Pages = 277, UrlPhotoCover = "https://s13emagst.akamaized.net/products/36188/36187196/images/res_f87bb6ab2b9477f32756c50c8ee91862.jpg?width=450&height=450&hash=D4C72856EF3CA43A8F5456C3ED044F2A" },
                new Book {Title = "Viata mincinoasa a adultilor", AuthorID = 0005, PublishingHouse = "Trei", ISBN = "9786069783634", Pages = 304, UrlPhotoCover = "http://mcdn.elefant.ro/mnresize/150/150/is/product-images/cartero/c69f70cb/8877/4492/9671/292f9b590165/c69f70cb-8877-4492-9671-292f9b590165_1.jpg" },
                new Book {Title = "Prietena mea geniala", AuthorID = 0005, PublishingHouse = "Pandora M", ISBN = "9786069782033", Pages = 336, UrlPhotoCover = "https://s13emagst.akamaized.net/products/19508/19507517/images/res_b29aa1e770c6a40a3d53985f88663712.jpg?width=450&height=450&hash=19E240992F8F63F26E885D7E02576155" },
                new Book {Title = "Dune", AuthorID = 0004, PublishingHouse = "Armada", ISBN = "9786064305251", Pages = 950, UrlPhotoCover = "http://mcdn.elefant.ro/mnresize/150/150/images/83/2004583/dune_1_fullsize.jpg" },
                new Book {Title = "A fost odata un razboi", AuthorID = 0010, PublishingHouse = "Polirom", ISBN = "9789734682652", Pages = 264, UrlPhotoCover = "https://s13emagst.akamaized.net/products/32929/32928816/images/res_3bd983965c7df1f6a68cb5ce26b18ecf.jpg?width=450&height=450&hash=17823CB062195657B9F675C2A089BE88" },
                new Book {Title = "Soareci si oameni", AuthorID = 0010, PublishingHouse = "Polirom", ISBN = "9786063368456", Pages = 160, UrlPhotoCover = "https://s13emagst.akamaized.net/products/340/339662/images/res_37ebd3a405b076cbd3c44a94edf14f1b.jpg?width=450&height=450&hash=3FE37E0D8BBB20FC807C4046D05DAC8A" },
                new Book {Title = "Poneiul rosu", AuthorID = 0010, PublishingHouse = "Polirom", ISBN = "9789734682652", Pages = 160, UrlPhotoCover = "https://s13emagst.akamaized.net/products/4851/4850426/images/res_7e3357c01fc45f6a6236a7249cdce843.jpg?width=450&height=450&hash=48E34961CB23B5EB7548CD8474FEA356" },
                 new Book {Title = "Moarte printre nori", AuthorID = 0001, PublishingHouse = "Litera", ISBN = "9786063368486", Pages = 320, UrlPhotoCover = "https://s13emagst.akamaized.net/products/29623/29622735/images/res_54c8e7688ac285b564dfdeebab3d41ad.jpg?width=450&height=450&hash=3660B099C2C93DD3E9FAAFFA99E24593" }
            };
            books.ForEach(b => context.Books.Add(b));
            context.SaveChanges();

            var bookReviews = new List<BookReview>
            {
                new BookReview { ReviewPhoto = "https://cdn.dc5.ro/img-prod/9789734633807-2481278-240.jpg", TitleReview = "Soareci si oameni", AuthorBookReviewed = "John Steinbeck", Description = "Romanul soareci si oameni, publicat în 1937, are ca fundal cele doua mari probleme cu care s-a confruntat America la începutul anilor ’30: criza financiara si seceta care au afectat soarta fermierilor si a muncitorilor. Miezul romanului, însa, se afla în relatia dintre George si Lennie, ideal al prieteniei si sprijinului si în substanta tragica a misiunii lor: achizitionarea unor terenuri si construirea propriei case, vis care prinde contur pâna la un punct. Esecul este însa vizibil în fiecare gest si iesire a lui Lennie, om al naturii si al instinctului, cu o forta fizica incredibila din care se alimenteaza idealul maret, dar care sfârseste prin a-l narui. Este, în ansamblu, atât un roman reprezentativ pentru un anumit peisaj temporal si social, dar mai mult este romanul prieteniei si singuratatii, al fragilitatii fiintei umane si a idealurilor pe care aceasta si le construieste. Romanul merita citit pentru doza lui de document, pentru o poveste foarte frumos conturata si gradata si pentru constructia personajelor: emotionante, empatice, cu reactii pe cât de neasteptate, pe atât de justificabile din punct de vedere uman.",
                AddedOn = DateTime.Now, Tags = "1937, America"},
                new BookReview {ReviewPhoto = "https://s13emagst.akamaized.net/products/19508/19507517/images/res_b29aa1e770c6a40a3d53985f88663712.jpg?width=450&height=450&hash=19E240992F8F63F26E885D7E02576155", TitleReview = "Prietena mea geniala", AuthorBookReviewed = "Elena Ferrante", Description = "În această carte, Elena Ferrante ne duce într-o suburbie din Napoli în a doua perioadă postbelică și ne face să trăim întâmplările prin ochii micuței Elena Greco. Prin copil, suntem scufundați în atmosfera din cartier, alcătuit din oameni care trăiesc, muncesc, se îndrăgostesc și ale căror povești sunt observate prin lentila vieții de zi cu zi. Pe lângă faptul că această poveste ne ține lipiți de paginile cărții, jucăm un rol activ în viața Elenei, care abandonează încet lumea copilăriei și învață să cunoască realitatea existenței.Această carte pare să conțină elemente biografice ale autoarei, nu există informații clare despre biografia Elenei Ferrante, decât orașul ei natal, Napoli tocmai pentru care este natural să recunoaștem în tânărul ei protagonist omonim cu aspirații de scriitor o urmă a vieții autoarei.",
                AddedOn = DateTime.Now, Tags = "Napoli, Italia, 1950, Biografie"}
            };
            bookReviews.ForEach(bR => context.BookReviews.Add(bR));
            context.SaveChanges();
        }
    }
}