using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleNetWebBusinessLayer.Models
{
    public class Author
    {
        [Required]
        public int Id { get; set; }
        
        [Required]
        [StringLength(100, MinimumLength = 1)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 1)]
        public string LastName { get; set; }

        public string FullName => $"{LastName}, {FirstName}";

        public virtual List<Book> Books { get; set; } = new List<Book>();
    }
}
