using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.NetCore.BookStore.Models
{
    public class Book
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        [MaxLength(50)]
        public string Author { get; set; }
        public int CopiesNumber { get; set; }
        [Display(Name = "Borrowed Copies")]
        public int BorrowedCopies { get; set; }
        [Display(Name = "Existing Copies")]
        public int CopiesLeft { get; set; }

        public float? Rate { get; set; }
    }
}
