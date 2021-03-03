using System;
using System.Linq;
using Bookstore413.Models;
using Microsoft.AspNetCore.Mvc;


namespace Bookstore413.Components
{
    public class NavigationMenuViewComponent : ViewComponent
    {
        private IBookstoreRepository repository;

        //constructor
        public NavigationMenuViewComponent (IBookstoreRepository r)
        {
            repository = r;
        }

        public IViewComponentResult Invoke()
        {
            //get the type from the route data to know which is selected
            ViewBag.SelectedCategory = RouteData?.Values["category"];

            return View(repository.Books
                .Select(x => x.Category)
                .Distinct()
                .OrderBy(x => x)
                );
        }
    }
}
