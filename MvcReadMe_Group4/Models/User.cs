using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MvcReadMe_Group4.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]       
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Role { get; set; } = "User";

        public virtual ICollection<BookAccess>? BookAccesses { get; set; }
    }
}
