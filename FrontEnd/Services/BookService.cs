using Data;
using System.Net.Http.Json;
using WEB_API.Entities;

namespace FrontEnd.Services
{
    public class BookService : IBookService
    {
        private readonly HttpClient httpClient;

        public BookService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        public async Task<Book> CreateBook(Book book)
        {
            await httpClient.PostAsJsonAsync("/api/books", book);
            return book;
        }

        public async Task DeleteBook(int id)
        {
            await httpClient.DeleteAsync($"/api/books/{id}");
        }

        public async Task<Book> GetBookById(int id)
        {
            return await httpClient.GetFromJsonAsync<Book>($"/api/books/{id}");
        }

        public async Task<List<Book>> GetBooks()
        {
            return await httpClient.GetFromJsonAsync<List<Book>>("/api/books");
        }

        public async Task<Book> UpdateBook(Book updatedBook)
        {
            var result = await httpClient.PutAsJsonAsync("/api/books", updatedBook);
            var newBook = await result.Content.ReadFromJsonAsync<Book>();
            //Onchange.Invoke();
            return newBook;
        }
    }
}
