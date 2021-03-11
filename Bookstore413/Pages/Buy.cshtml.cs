using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bookstore413.Infrastructure;
using Bookstore413.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Bookstore413.Pages
{
    //inherit from Page Model
    public class BuyModel : PageModel
    {
        //instance of repository
        private IBookstoreRepository repository;

        //constructor
        public BuyModel(IBookstoreRepository repo)
        {
            repository = repo;
        }

        //properties
        public Cart Cart { get; set; }
        public string ReturnUrl { get; set; }

        //methods
        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
            Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
        }

        public IActionResult OnPost(long bookId, string returnUrl)
        {
            Book book = repository.Books.FirstOrDefault(b => b.BookId == bookId);

            Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();

            Cart.AddItem(book, 1);

            HttpContext.Session.SetJson("cart", Cart);

            return RedirectToPage(new { returnUrl = returnUrl });
        }

        //new method for removing items from cart
        //public IActionResult OnPostRemove(long BookId, string returnUrl)
        //{
        //    Cart.RemoveLine(Cart.Lines.First(cl => cl.Book.BookId == BookId).Book);

        //    return RedirectToPage(new { returnUrl = returnUrl });
        //}
    }
}
