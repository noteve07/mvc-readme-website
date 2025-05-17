namespace MvcReadMe_Group4.Models
{
    public class BookAccess
    {
        public int Id { get; set; }

        public int UserId { get; set; }
        public virtual User User { get; set; }

        public int BookId { get; set; }
        public virtual Book Book { get; set; }
    }
}
