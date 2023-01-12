using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bookstore.Interface;
using Bookstore.Model;

namespace Bookstore.Repositories
{
    public class BookServices : IBookServices
    {
        public readonly List<Book> books = new()
        {
            new Book { Id = Guid.NewGuid(), Name = "Test", Price = 12.09}
        };

        public async Task CreateBookAsync(Book book)
        {
            books.Add(book);
            await Task.CompletedTask;
        }

        public async Task DeleteBookAsync(Guid id)
        {
            var index = books.FindIndex(existingBook => existingBook.Id == id);
            books.RemoveAt(index);
            await Task.CompletedTask;
        }

        public async Task<Book> GetBookAsync(Guid id)
        {
            var book = books.Where(book => book.Id == id).SingleOrDefault();
            return await Task.FromResult(book);
        }

        public async Task<IEnumerable<Book>> GetBooksAsync()
        {
            return await Task.FromResult(books);
        }

        public async Task UpdateBookAsync(Book book)
        {
            var index = books.FindIndex(existingBook => existingBook.Id == book.Id);
            books[index] = book;
            await Task.CompletedTask;
        }
    }
}