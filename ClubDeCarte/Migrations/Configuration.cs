namespace ClubDeCarte.Migrations
{
    using ClubDeCarte.DAL;
    using ClubDeCarte.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ClubDeCarte.DAL.BookClubDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(BookClubDBContext context)
        {
        /*    context.Authors.AddOrUpdate(
                a => a.AuthorID,
                new Author { FirstName = "Agatha", LastName = "Cristie" },
                new Author { FirstName = "George RR", LastName = "Martin" },
                new Author { FirstName = "Eric-Emmanuel", LastName = "Schmit" },
                new Author { FirstName = "Frank", LastName = "Herbert" },
                new Author { FirstName = "Elena", LastName = "Ferrante" },
                new Author { FirstName = "Maren", LastName = "Stoffels" },
                new Author { FirstName = "Walter", LastName = "Tevis" },
                new Author { FirstName = "Emily", LastName = "Gunnis" },
                new Author { FirstName = "Mihail", LastName = "Soare" },
                new Author { FirstName = "John", LastName = "Steinbeck" }
                );
          */
        }
    }
}
