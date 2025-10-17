using Microsoft.EntityFrameworkCore;
using _8to10.Features.Books;

namespace _8to10.Persistence;

public class BookManagementContext(DbContextOptions<BookManagementContext> options) : DbContext(options)
{
    public DbSet<Book> Books { get; set; }
}