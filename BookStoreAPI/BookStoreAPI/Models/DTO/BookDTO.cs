using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreAPI.Models.DTO
{
    public class BookDTO
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? PublicationDate { get; set; }
        public string CoverImageUrl { get; set; }
        public AuthorDTO Author { get; set; }
        public BookSizeDTO BookSize { get; set; }
    }
}
