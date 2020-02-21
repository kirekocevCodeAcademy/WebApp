using Core.Library;
using Microsoft.EntityFrameworkCore;

namespace DomainData.Library
{
    public class LibraryDbContext : DbContext
    {
        public LibraryDbContext(DbContextOptions<LibraryDbContext> options) : base(options)
        {
        }

        public DbSet<Person> Person { get; set; }
        public DbSet<Book> Book { get; set; }
    }
}
