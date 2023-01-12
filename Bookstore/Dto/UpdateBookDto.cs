using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore.Dto
{
    public class UpdateBookDto
    {
        [Required]
        public string Name { get; init; }
        [Required]
        [Range(1, 10000)]
        public double Price { get; init; }
    }
}