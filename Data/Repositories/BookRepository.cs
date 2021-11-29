using Microsoft.EntityFrameworkCore;
using WEB_API.Entities;

namespace WEB_API.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly BookContext _bookContext;

        public BookRepository(BookContext dbContext)
        {
            _bookContext = dbContext;
        }

        public async Task<Book> CreateBook(Book book)
        {
            _bookContext.Books.Add(book);
            await _bookContext.SaveChangesAsync();
            return book;
        }

        public async Task DeleteBook(int id)
        {
            var bookToDelete = await _bookContext.Books.FindAsync(id);
            if (bookToDelete != null)
            {
                _bookContext.Books.Remove(bookToDelete);
                await _bookContext.SaveChangesAsync();
            }
        }

        public async Task<Book> GetBookById(int id)
        {
            return await _bookContext.Books.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Book>> GetBooks()
        {
            return await _bookContext.Books.ToListAsync();
        }

        public async Task<Book> UpdateBook(Book book)
        {
            _bookContext.Entry<Book>(book).State = EntityState.Modified;
            await _bookContext.SaveChangesAsync();
            return book;
        }
    }
}
