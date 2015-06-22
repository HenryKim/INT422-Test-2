using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace int422TestTwo.ViewModels
{
    public class BookList
    {
        public int Id { get; set; }
        [Display(Name = "Book's Title")]
        public string Title { get; set; }
        [Display(Name = "Book's Author")]
        public string Author { get; set; }
        [Display(Name = "Book's Total Page")]
        public int Pages { get; set; }
        [Display(Name = "Book's ISBN code")]
        public string ISBN { get; set; }
    }
    public class AddBook
    {
        [Required]
        [Display(Name = "Book's Title")]
        public string Title { get; set; }
        [Required]
        [Display(Name = "Book's Author")]
        public string Author { get; set; }
        [Required]
        [Display(Name = "Book's Total Page")]
        public int Pages { get; set; }
        [Required]
        [Display(Name = "Book's ISBN code")]
        public string ISBN { get; set; }
    }
    public class BookBase : AddBook
    {
        public int Id { get; set; }
    }
}