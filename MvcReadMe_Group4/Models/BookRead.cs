using System;
using System.ComponentModel.DataAnnotations;

namespace MvcReadMe_Group4.Models
{
    public class BookRead
    {
        public int Id { get; set; }
        
        [Required]
        public DateTime ReadDate { get; set; }
        
        [Required]
        public int ReadCount { get; set; }
    }
} 