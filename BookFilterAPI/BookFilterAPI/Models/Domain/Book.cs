using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookFilterAPI.Models.Domain
{
    public class Book
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? PublicationDate { get; set; }
        public string CoverImageUrl { get; set; }
        public Guid AuthorId { get; set; }
        public Author Author { get; set; }
        public Guid BookSizeId { get; set; }
        public BookSize BookSize { get; set; }
    }
}
