using System;
using System.Collections.Generic;

namespace Bookstore413.Models.ViewModels
{
    public class BookListViewModel
    {
        //the bundle being passed to view contains info about Books and Paging
        public IEnumerable<Book> Books { get; set; }
        public PagingInfo PagingInfo { get; set; }

        //we need to know category to filter, we set that in the controller
        public string CurrentCategory { get; set; }

    }
}
