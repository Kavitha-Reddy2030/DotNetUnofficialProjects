using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreAPI.Middleware
{
    public class GlobalExceptionHandler : Exception
    {
        // You might not need to extend Exception if you aren't adding extra functionality
    }

    public class BookNotFoundException : Exception
    {
        public BookNotFoundException() : base("Book not found.") { }

        public BookNotFoundException(Guid id)
            : base($"Book with ID '{id}' was not found.") { }
    }

    public class BookAlreadyExistsException : Exception
    {
        public BookAlreadyExistsException(string title)
            : base($"Book with Title '{title}' already exists.") { }
    }

}
