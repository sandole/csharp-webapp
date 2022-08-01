using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleNetWebBusinessLayer.Models
{
    public class Book
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [StringLength(255, MinimumLength =1)]
        public string Title { get; set; }

        public virtual int AuthorId { get; set; }
        public virtual Author Author { get; set; }
    }
}
