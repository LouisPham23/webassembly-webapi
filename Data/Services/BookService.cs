using Data;
using WEB_API.Entities;
using WEB_API.Repositories;

namespace WEB_API.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _repo;
        public BookService (IBookRepository bookRepository)
        {
            _repo = bookRepository;
        }

        public event Action BooksChanged;

        public async Task<Book> CreateBook(Book book)
        {
            var newBook = await _repo.CreateBook(book);
            return newBook;
        }

        public async Task DeleteBook(int id)
        {
            await _repo.DeleteBook(id);
        }

        public async Task<Book> GetBookById(int id)
        {
            return await _repo.GetBookById(id);
        }
        public async Task<List<Book>> GetBooks()
        {
            return await _repo.GetBooks();  
        }

        public async Task<Book> UpdateBook(Book book)
        {
            return await _repo.UpdateBook(book);
        }
    }


}
