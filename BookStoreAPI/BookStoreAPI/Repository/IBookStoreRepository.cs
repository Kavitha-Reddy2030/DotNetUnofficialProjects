using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStoreAPI.Models.Domain;
using Sieve.Models;

namespace BookStoreAPI.Repository
{
    public interface IBookStoreRepository
    {
        Task<IEnumerable<Book>> GetAllBooksAsync();
        Task<Book> GetBookByIdAsync(Guid id);
        Task<Book> AddBookAsync(Book book);
        Task<Book> UpdateBookAsync(Guid id, Book book);
        Task<bool> DeleteBookAsync(Guid id);
        /* Task<IEnumerable<Book>> GetAllBooksSortedByTitleAsync(bool sortTitleAscending);
         Task<IEnumerable<Book>> GetAllBooksSortedByDescriptionAsync(bool sortDescriptionAscending);
         Task<(IEnumerable<Book>, int totalCount)> GetPaginatedBooksAsync(int pageNumber, int pageSize);*/

        Task<(IEnumerable<Book>, int totalCount)> GetFilteredSortedPagedBooksAsync(
           string filterField = null,
           string filterValue = null,
           string sortField = null,
           bool sortAscending = true,
           int pageNumber = 1,
           int pageSize = 10);

    }
}
