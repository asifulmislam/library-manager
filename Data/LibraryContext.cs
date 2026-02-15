using Microsoft.EntityFrameworkCore;
using LibraryManager.Models;

namespace LibraryManager.Data;

public class LibraryContext : DbContext
{
    public LibraryContext(DbContextOptions<LibraryContext> options) : base(options) { }
    public DbSet<Book> Books => Set<Book>();
    public DbSet<Author> Authors => Set<Author>();
    public DbSet<User> Users => Set<User>();
}
