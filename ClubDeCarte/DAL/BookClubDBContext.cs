using ClubDeCarte.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace ClubDeCarte.DAL
{
    public class BookClubDBContext : DbContext
    {
        public BookClubDBContext()
            : base("BookClubDBContext")
        {
           Database.SetInitializer(new MigrateDatabaseToLatestVersion<BookClubDBContext, ClubDeCarte.Migrations.Configuration>("BookClubDBContext"));
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<BookReview> BookReviews { get; set; }
        public DbSet<BookOfTheWeek> BookOfTheWeeks { get; set; }
        public DbSet<Event> Events { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public System.Data.Entity.DbSet<ClubDeCarte.Models.ProjectRole> ProjectRoles { get; set; }
    }
}