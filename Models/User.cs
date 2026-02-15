using System.ComponentModel.DataAnnotations;

namespace LibraryManager.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        public string Username { get; set; } = "";
        [Required]
        public string PasswordHash { get; set; } = "";
        public ICollection<Book> Books { get; set; } = new List<Book>();
    }
}
