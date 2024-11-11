using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookFilterAPI.Models.Domain;

namespace BookFilterAPI.Repository
{
     public interface IBookFilterRepository
    {
        Task<IEnumerable<Book>> GetAllBooksAsync();
        Task<Book> GetBookByIdAsync(Guid id);
        Task<Book> AddBookAsync(Book book);
        Task<Book> UpdateBookAsync(Guid id, Book book);
        Task<bool> DeleteBookAsync(Guid id);
        //Task<IEnumerable<Book>> GetBooksByTitleStartingWithAsync(string titleSubstring);
        // Task<IEnumerable<Book>> GetBooksByTitleStartingWithAsync(string titleSubstring, bool sortTitleAscending);
        //Task<IEnumerable<Book>> GetAllBooksSortedAsync(bool sortTitleAscending);
        Task<IEnumerable<Book>> GetAllBooksSortedByTitleAsync(bool sortTitleAscending);
        Task<IEnumerable<Book>> GetAllBooksSortedByDescriptionAsync(bool sortDescriptionAscending);
        Task<(IEnumerable<Book>, int totalCount)> GetPaginatedBooksAsync(int pageNumber, int pageSize);
        // Task<IEnumerable<Book>> GetBooksByTitleStartingWithAsync(string titleSubstring);
        //Task<IEnumerable<Book>> GetBooksByDescriptionFilterAsync(string descriptionSubstring);
       // Task<IEnumerable<Book>> GetBooksByDescriptionFilterAsync(string descriptionSubstring);
    }
}
