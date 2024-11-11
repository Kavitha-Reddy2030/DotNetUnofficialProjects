using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStoreAPI.Data;
using BookStoreAPI.Middleware;
using BookStoreAPI.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Sieve.Models;
using Sieve.Services;

namespace BookStoreAPI.Repository
{
    public class BookStoreRepository : IBookStoreRepository
    {
        private readonly BookStoreDbContext _dbContext;

        public BookStoreRepository(BookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // Get all books (including Author and BookSize)
        /* public async Task<IEnumerable<Book>> GetAllBooksAsync()
         {
             return await _dbContext.Books
                 .Include(b => b.Author)     // Include Author details
                 .Include(b => b.BookSize)   // Include BookSize details
                 .ToListAsync();
         }*/

        // Get all books with Author and BookSize using projection
        public async Task<IEnumerable<Book>> GetAllBooksAsync()
        {
            return await _dbContext.Books
                .Select(b => new Book
                {
                    Id = b.Id,
                    Title = b.Title,
                    Description = b.Description,
                    PublicationDate = b.PublicationDate,
                    CoverImageUrl = b.CoverImageUrl,
                    AuthorId = b.AuthorId,
                    BookSizeId = b.BookSizeId,
                    Author = new Author
                    {
                        Id = b.Author.Id,
                        Name = b.Author.Name,
                        Bio = b.Author.Bio,
                        Birthdate = b.Author.Birthdate,
                        ProfileImageUrl = b.Author.ProfileImageUrl
                    },
                    BookSize = new BookSize
                    {
                        Id = b.BookSize.Id,
                        Size = b.BookSize.Size
                    }
                })
                .ToListAsync();
        }


        // Get book by ID (including Author and BookSize)
        /* public async Task<Book> GetBookByIdAsync(Guid id)
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
         }*/

        // Get book by ID with Author and BookSize using projection
        public async Task<Book> GetBookByIdAsync(Guid id)
        {
            var book = await _dbContext.Books
                .Where(b => b.Id == id)
                .Select(b => new Book
                {
                    Id = b.Id,
                    Title = b.Title,
                    Description = b.Description,
                    PublicationDate = b.PublicationDate,
                    CoverImageUrl = b.CoverImageUrl,
                    AuthorId = b.AuthorId,
                    BookSizeId = b.BookSizeId,
                    Author = new Author
                    {
                        Id = b.Author.Id,
                        Name = b.Author.Name,
                        Bio = b.Author.Bio,
                        Birthdate = b.Author.Birthdate,
                        ProfileImageUrl = b.Author.ProfileImageUrl
                    },
                    BookSize = new BookSize
                    {
                        Id = b.BookSize.Id,
                        Size = b.BookSize.Size
                    }
                })
                .FirstOrDefaultAsync();

            if (book == null)
            {
                throw new BookNotFoundException(id);
            }

            return book;
        }


        // Add a new book
        /* public async Task<Book> AddBookAsync(Book book)
         {
             book.Id = Guid.NewGuid();
             await _dbContext.Books.AddAsync(book);
             await _dbContext.SaveChangesAsync();
             return await _dbContext.Books
          .Include(b => b.Author)
          .Include(b => b.BookSize)
          .FirstOrDefaultAsync(b => b.Id == book.Id);
         }*/

        public async Task<Book> AddBookAsync(Book book)
        {
            book.Id = Guid.NewGuid();
            await _dbContext.Books.AddAsync(book);
            await _dbContext.SaveChangesAsync();

            return await _dbContext.Books
                .Where(b => b.Id == book.Id)
                .Select(b => new Book
                {
                    Id = b.Id,
                    Title = b.Title,
                    Description = b.Description,
                    PublicationDate = b.PublicationDate,
                    CoverImageUrl = b.CoverImageUrl,
                    AuthorId = b.AuthorId,
                    BookSizeId = b.BookSizeId,
                    Author = new Author
                    {
                        Id = b.Author.Id,
                        Name = b.Author.Name,
                        Bio = b.Author.Bio,
                        Birthdate = b.Author.Birthdate,
                        ProfileImageUrl = b.Author.ProfileImageUrl
                    },
                    BookSize = new BookSize
                    {
                        Id = b.BookSize.Id,
                        Size = b.BookSize.Size
                    }
                })
                .FirstOrDefaultAsync();
        }


        // Update an existing book
        /*public async Task<Book> UpdateBookAsync(Guid id, Book book)
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
        }*/

        public async Task<Book> UpdateBookAsync(Guid id, Book book)
        {
            var existingBook = await _dbContext.Books.FindAsync(id);
            if (existingBook == null)
            {
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
                .Where(b => b.Id == id)
                .Select(b => new Book
                {
                    Id = b.Id,
                    Title = b.Title,
                    Description = b.Description,
                    PublicationDate = b.PublicationDate,
                    CoverImageUrl = b.CoverImageUrl,
                    AuthorId = b.AuthorId,
                    BookSizeId = b.BookSizeId,
                    Author = new Author
                    {
                        Id = b.Author.Id,
                        Name = b.Author.Name,
                        Bio = b.Author.Bio,
                        Birthdate = b.Author.Birthdate,
                        ProfileImageUrl = b.Author.ProfileImageUrl
                    },
                    BookSize = new BookSize
                    {
                        Id = b.BookSize.Id,
                        Size = b.BookSize.Size
                    }
                })
                .FirstOrDefaultAsync();
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

        /*public async Task<IEnumerable<Book>> GetAllBooksSortedByDescriptionAsync(bool sortDescriptionAscending)
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
        public async Task<IEnumerable<Book>> GetAllBooksSortedByTitleAsync(bool sortTitleAscending)
        {
            var booksQuery = _dbContext.Books.Include(b => b.Author).Include(b => b.BookSize);

            return sortTitleAscending
                ? await booksQuery.OrderBy(b => b.Title).ToListAsync() // Ascending
                : await booksQuery.OrderByDescending(b => b.Title).ToListAsync(); // Descending
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
        }*/

        public async Task<(IEnumerable<Book>, int totalCount)> GetFilteredSortedPagedBooksAsync(
            string filterField = null,
            string filterValue = null,
            string sortField = null,
            bool sortAscending = true,
            int pageNumber = 1,
            int pageSize = 10)
        {
            var query = _dbContext.Books.AsQueryable();

            // 1. Filtering
            if (!string.IsNullOrEmpty(filterField) && !string.IsNullOrEmpty(filterValue))
            {
                switch (filterField.ToLower())
                {
                    case "title":
                        query = query.Where(b => b.Title.Contains(filterValue));
                        break;
                    case "description":
                        query = query.Where(b => b.Description.Contains(filterValue));
                        break;
                    case "author":
                        query = query.Where(b => _dbContext.Authors
                                            .Any(a => a.Id == b.AuthorId && a.Name.Contains(filterValue)));
                        break;
                    case "booksize":
                        query = query.Where(b => _dbContext.BookSizes
                                            .Any(bs => bs.Id == b.BookSizeId && bs.Size.Contains(filterValue)));
                        break;
                }
            }

            // 2. Sorting
            if (!string.IsNullOrEmpty(sortField))
            {
                query = sortField.ToLower() switch
                {
                    "title" => sortAscending ? query.OrderBy(b => b.Title) : query.OrderByDescending(b => b.Title),
                    "description" => sortAscending ? query.OrderBy(b => b.Description) : query.OrderByDescending(b => b.Description),
                    _ => query
                };
            }

            // 3. Pagination
            var totalCount = await query.CountAsync();
            var books = await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .Select(b => new Book
                {
                    Id = b.Id,
                    Title = b.Title,
                    Description = b.Description,
                    PublicationDate = b.PublicationDate,
                    CoverImageUrl = b.CoverImageUrl,
                    Author = _dbContext.Authors.FirstOrDefault(a => a.Id == b.AuthorId),
                    BookSize = _dbContext.BookSizes.FirstOrDefault(bs => bs.Id == b.BookSizeId)
                })
                .ToListAsync();

            return (books, totalCount);
        }

    }
}
