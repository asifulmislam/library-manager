using LibraryManager.Models;

namespace LibraryManager.Data
{
    public class SeedData
    {
        public static void Initialize(LibraryContext context)
        {
            if (context.Authors.Any()) return;

            var author = new Author { Name = "George Orwell", Bio = "English novelist." };
            context.Authors.Add(author);

            context.Books.AddRange(
                new Book
                {
                    Title = "1984",
                    Author = author,
                    PubYear = "1949",
                    Genre = "Dystopian",
                    UserId = 1
                },
                new Book
                {
                    Title = "Animal Farm",
                    Author = author,
                    PubYear = "1945",
                    Genre = "Satire",
                    UserId = 1
                }
            );
            context.SaveChanges();
        }
    }
}