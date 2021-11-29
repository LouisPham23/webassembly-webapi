using WEB_API.Entities;

namespace WEB_API.Repositories
{
    public interface IBookRepository
    {
        Task<List<Book>> GetBooks();
        Task<Book> GetBookById(int id);
        Task<Book> CreateBook(Book book);
        Task<Book> UpdateBook(Book book);   
        Task DeleteBook(int id);    
    }
}
