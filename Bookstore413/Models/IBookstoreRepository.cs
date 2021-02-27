using System;
using System.Linq;

namespace Bookstore413.Models
{
    //interface that defines structure of repository
    public interface IBookstoreRepository
    {
        IQueryable<Book> Books { get; }
    }
}
