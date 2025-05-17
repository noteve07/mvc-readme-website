using System.ComponentModel.DataAnnotations;


namespace MvcReadMe_Group4.Models
{
    public class Book
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Author { get; set; }

        public string Category { get; set; }

        public string Description { get; set; }

        [Required]
        public string ISBN { get; set; }

        [Required]
        public string FilePath { get; set; }

        public string CoverImagePath { get; set; }

        public int NumberOfReads { get; set; }

        public virtual ICollection<BookAccess>? BookAccesses { get; set; }
    }
}
