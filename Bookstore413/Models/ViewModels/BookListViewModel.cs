using System;
using System.Collections.Generic;

namespace Bookstore413.Models.ViewModels
{
    public class BookListViewModel
    {
        //the bundle being passed to view contains info about Books and Paging
        public IEnumerable<Book> Books { get; set; }
        public PagingInfo PagingInfo { get; set; }

    }
}
