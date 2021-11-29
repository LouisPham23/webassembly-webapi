using Data;
using Microsoft.AspNetCore.Mvc;
using WEB_API.Entities;
using WEB_API.Services;

namespace WEB_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;
        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public async Task<IActionResult> GetBooks()
        {
            return Ok(await _bookService.GetBooks());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookById(int id)
        {
            return Ok(await _bookService.GetBookById(id));
        }

        [HttpPost]
        public async Task<ActionResult<Book>> CreateBook([FromBody] Book book)
        {
            return await _bookService.CreateBook(book);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateBook([FromBody] Book book)
        {
            var bookToUpdate = await _bookService.GetBookById(book.Id);

            if(bookToUpdate == null)
            {
                return NotFound($"Book with Id = {book.Id} not found");
            }

            await _bookService.UpdateBook(book);
            return Ok(book);
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteBook(int id)
        {
            await _bookService.DeleteBook(id);
            return Ok();
        }
    }
}
