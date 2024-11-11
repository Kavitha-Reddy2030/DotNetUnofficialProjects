using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BookFilterAPI.Data;
using BookFilterAPI.Filters;
using BookFilterAPI.Middleware;
using BookFilterAPI.Models.Domain;
using BookFilterAPI.Models.DTO;
using BookFilterAPI.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BookFilterAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookFilterController : ControllerBase
    {
        private readonly IBookFilterRepository _bookFilterRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<BookFilterController> _logger;
        private readonly BookFilterDbContext _dbContext;


        public BookFilterController(IBookFilterRepository bookFilterRepository, IMapper mapper, ILogger<BookFilterController> logger, BookFilterDbContext dbContext)
        {
            _bookFilterRepository = bookFilterRepository;
            _mapper = mapper;
            _logger = logger;
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBooks()
        {
            try
            {
                var books = await _bookFilterRepository.GetAllBooksAsync();
                var bookDTOs = _mapper.Map<IEnumerable<BookDTO>>(books);
                return Ok(bookDTOs);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while fetching books.");
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request.");
            }
        }

        [HttpGet("{id:Guid}")]
        public async Task<IActionResult> GetBookById(Guid id)
        {
            try
            {
                var book = await _bookFilterRepository.GetBookByIdAsync(id);
                var bookDTO = _mapper.Map<BookDTO>(book);
                return Ok(bookDTO);
            }
            catch (BookNotFoundException ex)
            {
                _logger.LogWarning(ex.Message);
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while fetching the book.");
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request.");
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddBook(CreateBookDTO addBookDTO)
        {
            try
            {
                var book = _mapper.Map<Book>(addBookDTO);
                var newBook = await _bookFilterRepository.AddBookAsync(book);
                var bookDTO = _mapper.Map<BookDTO>(newBook);
                return CreatedAtAction(nameof(GetBookById), new { id = newBook.Id }, bookDTO);
            }
            catch (BookAlreadyExistsException ex)
            {
                _logger.LogWarning(ex.Message);
                return Conflict(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while adding the book.");
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request.");
            }
        }

        [HttpPut("{id:Guid}")]
        public async Task<IActionResult> UpdateBook(Guid id, UpdateBookDTO updateBookDTO)
        {
            try
            {
                var existingBook = await _bookFilterRepository.GetBookByIdAsync(id);
                if (existingBook == null)
                {
                    return NotFound($"Book with ID {id} not found.");
                }

                existingBook.Title = updateBookDTO.Title;
                existingBook.Description = updateBookDTO.Description;
                existingBook.PublicationDate = updateBookDTO.PublicationDate;
                existingBook.CoverImageUrl = updateBookDTO.CoverImageUrl;
                existingBook.AuthorId = updateBookDTO.AuthorId;
                existingBook.BookSizeId = updateBookDTO.BookSizeId;

                await _bookFilterRepository.UpdateBookAsync(id, existingBook);
                return Ok(existingBook);
            }
            catch (BookNotFoundException ex)
            {
                _logger.LogWarning(ex.Message);
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while updating the book.");
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request.");
            }
        }

        [HttpDelete("{id:Guid}")]
        public async Task<IActionResult> DeleteBook(Guid id)
        {
            try
            {
                await _bookFilterRepository.DeleteBookAsync(id);
                return NoContent();
            }
            catch (BookNotFoundException ex)
            {
                _logger.LogWarning(ex.Message);
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while deleting the book.");
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request.");
            }
        }

        [HttpGet("filter/description")]
        public async Task<IActionResult> FilterBooksByDescription(string substring)
        {
            try
            {
                var books = await _bookFilterRepository.GetAllBooksAsync();

                // If no substring is provided, return all books
                if (string.IsNullOrWhiteSpace(substring))
                {
                    var bookDTOs = _mapper.Map<IEnumerable<BookDTO>>(books);
                    return Ok(bookDTOs);
                }

                // Filtering logic
                var filteredBooks = books
                    .Where(b => b.Description != null && b.Description.Contains(substring, StringComparison.OrdinalIgnoreCase))
                    .ToList();

                if (!filteredBooks.Any())
                {
                    return NotFound("No books found with the specified description substring.");
                }

                var bookDTOsFiltered = _mapper.Map<IEnumerable<BookDTO>>(filteredBooks);
                return Ok(bookDTOsFiltered);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while filtering books by description.");
                return StatusCode(StatusCodes.Status500InternalServerError, "An unexpected error occurred.");
            }
        }

        [HttpGet("sorted/Description")]
        public async Task<IActionResult> GetAllBooksSortedByDescription([FromQuery] bool sortDescriptionAscending)
        {
            try
            {
                var books = await _bookFilterRepository.GetAllBooksSortedByDescriptionAsync(sortDescriptionAscending);
                var bookDTOs = _mapper.Map<IEnumerable<BookDTO>>(books);
                return Ok(bookDTOs);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while fetching sorted books by description.");
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request.");
            }
        }

        [HttpGet("sorted/title")]
        public async Task<IActionResult> GetSortedBooksByTitle([FromQuery] bool sortTitleAscending = true)
        {
            try
            {
                var books = await _bookFilterRepository.GetAllBooksSortedByTitleAsync(sortTitleAscending);
                var bookDTOs = _mapper.Map<IEnumerable<BookDTO>>(books);
                return Ok(bookDTOs);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while fetching sorted books by title.");
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request.");
            }
        }

        [HttpGet("paginated")]
        public async Task<IActionResult> GetPaginatedBooks([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            try
            {
                var (books, totalCount) = await _bookFilterRepository.GetPaginatedBooksAsync(pageNumber, pageSize);
                var bookDTOs = _mapper.Map<IEnumerable<BookDTO>>(books);

                var response = new
                {
                    TotalCount = totalCount,
                    PageNumber = pageNumber,
                    PageSize = pageSize,
                    Books = bookDTOs
                };

                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while fetching paginated books.");
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request.");
            }
        }        
    }
}
