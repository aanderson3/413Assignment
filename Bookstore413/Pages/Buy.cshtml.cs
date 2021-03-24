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
        public BuyModel(IBookstoreRepository repo, Cart cartService)
        {
            repository = repo;
            //do i need a cart attribute here like in the book??
            Cart = cartService;
        }

        //properties
        public Cart Cart { get; set; }
        public string ReturnUrl { get; set; }

        //methods
        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
            //Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
        }

        public IActionResult OnPost(long bookId, string returnUrl)
        {
            Book book = repository.Books.FirstOrDefault(b => b.BookId == bookId);

            //Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();

            Cart.AddItem(book, 1);

            //HttpContext.Session.SetJson("cart", Cart);

            return RedirectToPage(new { returnUrl = returnUrl });
        }

        //new method for removing items from cart
        public IActionResult OnPostRemove(long bookId, string returnUrl)
        {
            //Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();

            Cart.RemoveLine(Cart.Lines.First(cl => cl.Book.BookId == bookId).Book); //this is the ERROR!!!! it says that instance of cart is null?

            //HttpContext.Session.SetJson("cart", Cart);

            return RedirectToPage(new { returnUrl = returnUrl }); //do i need to define this function??
        }
    }
}
