using LibraryManager.Models;

namespace LibraryManager.Data
{
    public class SeedData
    {
        public static void Initialize(LibraryContext context)
        {
            if (context.Authors.Any()) return;

            var defaultUser = new User
            {
                Username = "foo",
                PasswordHash = BCrypt.Net.BCrypt.HashPassword("bar")
            };
            context.Users.Add(defaultUser);
            context.SaveChanges(); 

            var author = new Author { Name = "George Orwell", Bio = "English novelist" };
            context.Authors.Add(author);
            context.SaveChanges(); 

            context.Books.AddRange(
                new Book
                {
                    Title = "1984",
                    Author = author,
                    PubYear = "1949",
                    Genre = "Dystopian",
                    UserId = defaultUser.Id
                },
                new Book
                {
                    Title = "Animal Farm",
                    Author = author,
                    PubYear = "1945",
                    Genre = "Satire",
                    UserId = defaultUser.Id
                }
            );

            context.SaveChanges();
        }
    }
}