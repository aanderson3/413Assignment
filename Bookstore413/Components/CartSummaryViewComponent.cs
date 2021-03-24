using Microsoft.AspNetCore.Mvc;
using Bookstore413.Models;

namespace Bookstore413.Components
{
    //view component to add widget for cart
    public class CartSummaryViewComponent : ViewComponent
    {
        private Cart cart;

        public CartSummaryViewComponent(Cart cartService)
        {
            cart = cartService;
        }

        public IViewComponentResult Invoke()
        {
            return View(cart);
        }
    }
}