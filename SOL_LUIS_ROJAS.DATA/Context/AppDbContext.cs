using SOL_LUIS_ROJAS.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOL_LUIS_ROJAS.DATA.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<Book> Books { get; set; }

        public DbSet<BookLoan> BookLoans { get; set; }

        public DbSet<User> Users { get; set; }

        public AppDbContext()
            : base("DefaultConnection")
        {
        }

        public static AppDbContext Create()
        {
            return new AppDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<BookLoan>()
                .HasRequired(x => x.User)
                .WithMany(x => x.BookLoans)
                .HasForeignKey(x => x.UserId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<BookLoan>()
                .HasRequired(x => x.Book)
                .WithMany(x => x.BookLoans)
                .HasForeignKey(x => x.BookId)
                .WillCascadeOnDelete(false);

        }
    }
}
