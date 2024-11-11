using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookFilterAPI.Data;
using BookFilterAPI.Middleware;
using BookFilterAPI.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BookFilterAPI.Repository
{
    public class BookFilterRepository : IBookFilterRepository
    {
        private readonly BookFilterDbContext _dbContext;
        private readonly ILogger _logger;

        //private readonly SieveProcessor _sieveProcessor;

        public BookFilterRepository(BookFilterDbContext dbContext)
        {
            _dbContext = dbContext;
            //_sieveProcessor = sieveProcessor;
        }

        // Get all books (including Author and BookSize)
        public async Task<IEnumerable<Book>> GetAllBooksAsync()
        {
            return await _dbContext.Books
                .Include(b => b.Author)     // Include Author details
                .Include(b => b.BookSize)   // Include BookSize details
                .ToListAsync();
        }

        // Get book by ID (including Author and BookSize)
        public async Task<Book> GetBookByIdAsync(Guid id)
        {
            var book = await _dbContext.Books
                .Include(b => b.Author)     // Include Author details
                .Include(b => b.BookSize)   // Include BookSize details
                .FirstOrDefaultAsync(b => b.Id == id);

            if (book == null)
            {
                // Throw custom exception if the book is not found (optional)
                throw new BookNotFoundException(id);
            }

            return book;
        }

        // Add a new book
        public async Task<Book> AddBookAsync(Book book)
        {
            book.Id = Guid.NewGuid();
            await _dbContext.Books.AddAsync(book);
            await _dbContext.SaveChangesAsync();
            return await _dbContext.Books
         .Include(b => b.Author)
         .Include(b => b.BookSize)
         .FirstOrDefaultAsync(b => b.Id == book.Id);
        }

        // Update an existing book
        public async Task<Book> UpdateBookAsync(Guid id, Book book)
        {
            var existingBook = await _dbContext.Books.FindAsync(id);
            if (existingBook == null)
            {
                // Throw custom exception if the book is not found (optional)
                throw new BookNotFoundException(id);
            }

            // Update book details
            existingBook.Title = book.Title;
            existingBook.Description = book.Description;
            existingBook.PublicationDate = book.PublicationDate;
            existingBook.AuthorId = book.AuthorId;
            existingBook.BookSizeId = book.BookSizeId;
            existingBook.CoverImageUrl = book.CoverImageUrl;

            await _dbContext.SaveChangesAsync();
            return await _dbContext.Books
       .Include(b => b.Author)
       .Include(b => b.BookSize)
       .FirstOrDefaultAsync(b => b.Id == id);
        }

        // Delete a book
        public async Task<bool> DeleteBookAsync(Guid id)
        {
            var book = await _dbContext.Books.FindAsync(id);
            if (book == null)
            {
                // Throw custom exception if the book is not found (optional)
                throw new BookNotFoundException(id);
            }

            _dbContext.Books.Remove(book);
            await _dbContext.SaveChangesAsync();
            return true;
        }
        /* public async Task<IEnumerable<Book>> GetBooksByTitleStartingWithAsync(string titleSubstring)
         {
             return await _dbContext.Books
                 .Where(b => b.Title.StartsWith(titleSubstring, StringComparison.OrdinalIgnoreCase))
                 .Include(b => b.Author)     // Include Author details if needed
                 .Include(b => b.BookSize)   // Include BookSize details if needed
                 .ToListAsync();
         }
 */

        /*public async Task<IEnumerable<Book>> GetBooksByTitleStartingWithAsync(string titleSubstring)
        {
            if (string.IsNullOrWhiteSpace(titleSubstring))
            {
                throw new ArgumentException("Title substring cannot be null or whitespace.", nameof(titleSubstring));
            }

            return await _dbContext.Books
                .Where(b => b.Title.StartsWith(titleSubstring, StringComparison.OrdinalIgnoreCase))
                .Include(b => b.Author)     // Include Author details if needed
                .Include(b => b.BookSize)   // Include BookSize details if needed
                .ToListAsync();
        }*/

        /* public async Task<IEnumerable<Book>> GetBooksByTitleStartingWithAsync(string titleSubstring)
         {
             // Only filter by title if the titleSubstring is not null or empty
             var query = _dbContext.Books.AsQueryable();

             if (!string.IsNullOrEmpty(titleSubstring))
             {
                 query = query.Where(b => b.Title.StartsWith(titleSubstring, StringComparison.OrdinalIgnoreCase));
             }

             return await query
                 .Include(b => b.Author)     // Include Author details if needed
                 .Include(b => b.BookSize)   // Include BookSize details if needed
                 .ToListAsync();
         }
 */



        /* public async Task<IEnumerable<Book>> GetBooksByTitleStartingWithAsync(string titleSubstring, bool sortTitleAscending)
         {
             if (string.IsNullOrWhiteSpace(titleSubstring))
             {
                 return new List<Book>();
             }

             var query = _dbContext.Books
                 .Where(b => b.Title.StartsWith(titleSubstring, StringComparison.OrdinalIgnoreCase))
                 .Include(b => b.Author)
                 .Include(b => b.BookSize);

             // Apply sorting based on the sortTitleAscending parameter
             if (sortTitleAscending)
             {
                 query = (Microsoft.EntityFrameworkCore.Query.IIncludableQueryable<Book, BookSize>)query.OrderBy(b => b.Title); // Ascending order
             }

             return await query.ToListAsync();
         }*/

        /* public async Task<IEnumerable<Book>> GetAllBooksSortedAsync(bool sortTitleAscending)
         {
             var query = _dbContext.Books.AsQueryable();

             if (sortTitleAscending)
             {
                 return await query
                     .OrderBy(b => b.Title)
                     .Include(b => b.Author)
                     .Include(b => b.BookSize)
                     .ToListAsync();
             }
             else
             {
                 return await query
                     .OrderByDescending(b => b.Title)
                     .Include(b => b.Author)
                     .Include(b => b.BookSize)
                     .ToListAsync();
             }
         }*/

        public async Task<IEnumerable<Book>> GetAllBooksSortedByDescriptionAsync(bool sortDescriptionAscending)
        {
            var query = _dbContext.Books.AsQueryable();

            if (sortDescriptionAscending)
            {
                return await query
                    .OrderBy(b => b.Description)
                    .Include(b => b.Author)
                    .Include(b => b.BookSize)
                    .ToListAsync();
            }
            else
            {
                return await query
                    .OrderByDescending(b => b.Description)
                    .Include(b => b.Author)
                    .Include(b => b.BookSize)
                    .ToListAsync();
            }
        }


        public async Task<(IEnumerable<Book>, int totalCount)> GetPaginatedBooksAsync(int pageNumber, int pageSize)
        {
            var totalCount = await _dbContext.Books.CountAsync();

            var books = await _dbContext.Books
                .Include(b => b.Author)
                .Include(b => b.BookSize)
                .Skip((pageNumber - 1) * pageSize) // Calculate the number of items to skip
                .Take(pageSize) // Take the specified page size
                .ToListAsync();

            return (books, totalCount);
        }


        public async Task<IEnumerable<Book>> GetAllBooksSortedByTitleAsync(bool sortTitleAscending)
        {
            var booksQuery = _dbContext.Books.Include(b => b.Author).Include(b => b.BookSize);

            return sortTitleAscending
                ? await booksQuery.OrderBy(b => b.Title).ToListAsync() // Ascending
                : await booksQuery.OrderByDescending(b => b.Title).ToListAsync(); // Descending
        }

        /* public async Task<IEnumerable<Book>> GetBooksByTitleStartingWithAsync(string titleSubstring)
         {
             if (string.IsNullOrWhiteSpace(titleSubstring))
             {
                 return await GetAllBooksAsync(); // Return all books if no filter is applied
             }

             return await _dbContext.Books
                 .Where(b => b.Title.StartsWith(titleSubstring, StringComparison.OrdinalIgnoreCase))
                 .Include(b => b.Author)     // Include Author details if needed
                 .Include(b => b.BookSize)   // Include BookSize details if needed
                 .ToListAsync();
         }*/




        /* public async Task<IEnumerable<Book>> GetBooksByDescriptionFilterAsync(string descriptionSubstring)
         {
             if (string.IsNullOrWhiteSpace(descriptionSubstring))
             {
                 return await GetAllBooksAsync();
             }

             return await _dbContext.Books
                 .Where(b => b.Description.StartsWith(descriptionSubstring, StringComparison.OrdinalIgnoreCase))
                 .Include(b => b.Author)
                 .Include(b => b.BookSize)
                 .ToListAsync();
         }*/

       


    }
}
