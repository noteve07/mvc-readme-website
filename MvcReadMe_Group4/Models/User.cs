using System.ComponentModel.DataAnnotations;

namespace MvcReadMe_Group4.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]       
        public string UserName { get; set; }

        [Required]
        private string _password;
        public string Password 
        { 
            get { return _password; }
            set { _password = value; }
        }

        [Required]
        private string _role = "User";
        public string Role 
        { 
            get { return _role; }
            set { _role = value; }
        }
    }
}
