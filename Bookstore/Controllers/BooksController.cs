using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bookstore.Dto;
using Bookstore.Interface;
using Bookstore.Model;
using Microsoft.AspNetCore.Mvc;

namespace Bookstore.Controllers
{
    [ApiController]
    [Route("books")]
    public class BooksController : ControllerBase
    {
        private readonly IBookServices bookServices;
        public BooksController(IBookServices bookServices)
        {
            this.bookServices = bookServices;
        }

        [HttpGet]
        public async Task<IEnumerable<BookDto>> GetBooksAsync()
        {
            var books = (await bookServices.GetBooksAsync()).Select( book => book.AsDto());
            return books;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BookDto>> GetBookAsync(Guid id)
        {
            var book = await bookServices.GetBookAsync(id);
            if (book is null)
            {
                return NotFound();
            }
            return book.AsDto();
        }

        [HttpPost]
        public async Task<ActionResult<BookDto>> CreateBookAsync(CreateBookDto bookDto)
        {
            Book book = new(){
                Id = Guid.NewGuid(),
                Name = bookDto.Name,
                Price = bookDto.Price
            };
            await bookServices.CreateBookAsync(book);
            return CreatedAtAction(nameof(GetBooksAsync), new { id = book.Id }, book.AsDto());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteBookAsync(Guid id)
        {
            var existingBook = await bookServices.GetBookAsync(id);
            if (existingBook is null)
            {
                return NotFound();
            }
            await bookServices.DeleteBookAsync(id);
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateBookAsync(Guid id, UpdateBookDto bookDto)
        {
            var existingBook = await bookServices.GetBookAsync(id);
            if (existingBook is null)
            {
                return NotFound();
            }
            Book updatedBook = existingBook with
            {
                Name = bookDto.Name,
                Price = bookDto.Price
            };
            await bookServices.UpdateBookAsync(updatedBook);
            return NoContent();
        }
    }
}