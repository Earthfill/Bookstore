using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bookstore.Model;

namespace Bookstore.Interface
{
    public interface IBookServices
    {
        Task<Book> GetBookAsync(Guid id);
        Task<IEnumerable<Book>> GetBooksAsync();
        Task CreateBookAsync(Book book);
        Task UpdateBookAsync(Book book);
        Task DeleteBookAsync(Guid id);
    }
}