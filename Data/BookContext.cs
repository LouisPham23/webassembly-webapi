using Microsoft.EntityFrameworkCore;
using WEB_API.Entities;

namespace WEB_API
{
    public class BookContext : DbContext
    {
        public BookContext(DbContextOptions<BookContext> options) : base(options)
        {

        }
        public DbSet<Book> Books { get; set; }
    }
}
