using System;
using Microsoft.EntityFrameworkCore;

namespace Bookstore413.Models
{
    //context class inherits from dbContext to bring in funcitonality, represents db session
    public class BookstoreDbContext : DbContext
    {
        //constructor
        public BookstoreDbContext(DbContextOptions<BookstoreDbContext> options) : base (options)
        {

        }

        //this returns a dbset of type book
        public DbSet<Book> Books { get; set; }
    }
}
