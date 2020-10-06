using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.NetCore.BookStore.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        public virtual DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            modelbuilder.Entity<Book>().HasData(
                    new Book { Id = 1, Name = "the catcher in the rye", Author = "j.d.salinger", CopiesNumber = 6, BorrowedCopies = 4, Rate = (float)3.1, CopiesLeft = 2 },
                    new Book { Id = 2, Name = "to kill a mockingbird", Author = "harper lee", CopiesNumber = 5, BorrowedCopies = 1, Rate = (float)4.2, CopiesLeft = 4 },
                    new Book { Id = 3, Name = "pride and prejudice", Author = "jane austen", CopiesNumber = 7, BorrowedCopies = 2, Rate = (float)4.9, CopiesLeft = 5 },
                    new Book { Id = 4, Name = "harry potter and the philosopher's stone", Author = "j. k. rowling", CopiesNumber = 4, BorrowedCopies = 1, Rate = (float)4.8, CopiesLeft = 3 },
                    new Book { Id = 5, Name = "hamlet", Author = "wiiliam shakespeare", CopiesNumber = 3, BorrowedCopies = 0, Rate = (float)4.6, CopiesLeft = 3 },
                    new Book { Id = 6, Name = "othelo", Author = "wiiliam shakespeare", CopiesNumber = 3, BorrowedCopies = 0, Rate = (float)4.4, CopiesLeft = 3 },
                    new Book { Id = 7, Name = "the fault in our stars", Author = "john green", CopiesNumber = 5, BorrowedCopies = 0, Rate = (float)3.4, CopiesLeft = 5 },
                    new Book { Id = 8, Name = "wolf hall", Author = "hilary mantelr", CopiesNumber = 3, BorrowedCopies = 0, Rate = (float)3.9, CopiesLeft = 3 },
                    new Book { Id = 9, Name = "life of pi", Author = "yann martel", CopiesNumber = 4, BorrowedCopies = 1, Rate = (float)4, CopiesLeft = 3 }

                );
        }
    }
}
