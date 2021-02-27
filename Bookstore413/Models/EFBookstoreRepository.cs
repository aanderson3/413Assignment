using System;
using System.Linq;

namespace Bookstore413.Models
{
    public class EFBookstoreRepository : IBookstoreRepository
    {
        private BookstoreDbContext _context;

        //constructor
        public EFBookstoreRepository(BookstoreDbContext context)
        {
            _context = context;
        }

        public IQueryable<Book> Books => _context.Books;


    }
}
