using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bookstore.Dto;
using Bookstore.Model;

namespace Bookstore
{
    public static class Extension
    {
        public static BookDto AsDto(this Book book)
        {
            return new BookDto
            {
                Id = book.Id,
                Name = book.Name,
                Price = book.Price,
                Category = book.Category,
                Author = book.Author
            };
        }
    }
}