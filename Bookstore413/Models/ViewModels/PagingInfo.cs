using System;


namespace Bookstore413.Models.ViewModels
{
    //view model that bundles data to display in the index view
    public class PagingInfo
    {
        public int TotalNumItems { get; set; }
        public int ItemsPerPage { get; set; }
        public int CurrentPage { get; set; }

        //calculate total number of pages we need to display
        public int TotalPages => (int)(Math.Ceiling((decimal)TotalNumItems / ItemsPerPage));
    }
}
