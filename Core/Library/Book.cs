using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core.Library
{
    public class Book
    {
        public int Id { get; set; }
        [Required, MaxLength(50), Display(Name = "Book Title")]
        public string Title { get; set; }
        [Required, Display(Name = "Author")]
        public int? PersonId { get; set; }
        public Person Author { get; set; }        
    }
}
