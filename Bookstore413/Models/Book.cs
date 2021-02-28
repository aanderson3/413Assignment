using System;
using System.ComponentModel.DataAnnotations;

namespace Bookstore413.Models
{
    //creating the Book class with attributes
    public class Book
    {
        [Key]
        public int BookId { get; set; }

        //all fields required
        [Required]
        public string Title { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]
        public string Publisher { get; set; }
        //validate format of isbn using regex
        [Required]
        [RegularExpression(@"^[0-9]{3}-[0-9]{10}$", ErrorMessage ="Invalid ISBN Formate (XXX-XXXXXXX)")]
        public string ISBN { get; set; }
        [Required]
        public string Classification { get; set; }
        [Required]
        public string Category { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public int Pages { get; set; }
    }
}
