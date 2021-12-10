using Data;
using System.Net.Http.Json;
using WEB_API.Entities;

namespace FrontEnd.Services
{
    public class BookService : IBookService
    {
        private readonly HttpClient httpClient;
        public List<Book> Books { get; set; } = new List<Book>();
        public event Action BooksChanged;

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

        public async Task<Book?> GetBookById(int id)
        {
            HttpResponseMessage response = await httpClient.GetAsync($"/api/books/{id}");

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine(response.StatusCode.ToString());
                var book = response.Content.ReadFromJsonAsync<Book>().Result;
                return book;
            }
            else
            {
                // problems handling here
                Console.WriteLine(
                    "Error occurred, the status code is: {0}",
                    response.StatusCode
                );
                return null;
            }
        }

        public async Task<List<Book>> GetBooks()
        {
            return await httpClient.GetFromJsonAsync<List<Book>>("/api/books");
        }

        public async Task<Book> UpdateBook(Book updatedBook)
        {
            var result = await httpClient.PutAsJsonAsync("/api/books", updatedBook);
            var newBook = await result.Content.ReadFromJsonAsync<Book>();
            return newBook;
        }
    }
}
