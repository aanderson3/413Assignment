using System;
using System.Collections.Generic;
using System.Linq;
namespace Bookstore413.Models
{
    public class Cart
    {
        //list of lines of the cart
        public List<CartLine> Lines { get; set; } = new List<CartLine>();

        //ability to add line
        public virtual void AddItem (Book book, int qty)
        {
            CartLine line = Lines
                .Where(b => b.Book.BookId == book.BookId)
                .FirstOrDefault();

            if (line == null)
            {
                Lines.Add(new CartLine
                {
                    Book = book,
                    Quantity = qty
                });
            }
            else
            {
                line.Quantity += qty;
            }
        }

        //ability to remove line
        public virtual void RemoveLine(Book book) =>
            Lines.RemoveAll(x => x.Book.BookId == book.BookId); //error is somewhere in here? when returning to Buy.cshtml.cs Book is empty

        public virtual void Clear() => Lines.Clear();

        //i made this a double but i could have used decimal and converted the price
        public double ComputeTotalSum() =>
            Lines.Sum(e => e.Book.Price * e.Quantity);

        //class within the class
        public class CartLine
        {
            public int CartLineId { get; set; }
            public Book Book { get; set; }
            public int Quantity { get; set; }
        }
    }
}
