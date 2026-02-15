using System.ComponentModel.DataAnnotations;

namespace LibraryManager.Models
{
    public class Book
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; } = "";
        [Required, StringLength(4)]
        public String PubYear { get; set; } = "";
        [Required]
        public String Genre { get; set; } = "";

        [Required]
        public int AuthorId { get; set; }
        public Author? Author { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; }
    }
}
