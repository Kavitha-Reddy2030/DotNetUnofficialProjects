using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BookStoreAPI.Middleware;
using BookStoreAPI.Models.Domain;
using BookStoreAPI.Models.DTO;
using BookStoreAPI.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Sieve.Models;

namespace BookStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BookStoreController : ControllerBase
    {
        private readonly IBookStoreRepository _bookStoreRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<BookStoreController> _logger;

        public BookStoreController(IBookStoreRepository bookStoreRepository, IMapper mapper, ILogger<BookStoreController> logger)
        {
            _bookStoreRepository = bookStoreRepository;
            _mapper = mapper;
            _logger = logger;
        }

        [Authorize(Policy = "UserOrAdmin")]
        [HttpGet]
        public async Task<IActionResult> GetAllBooks()
        {
            try
            {
                var books = await _bookStoreRepository.GetAllBooksAsync();
                var bookDTOs = _mapper.Map<IEnumerable<BookDTO>>(books);
                return Ok(bookDTOs);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while fetching books.");
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request.");
            }
        }

        [Authorize(Policy = "UserOrAdmin")]
        [HttpGet("{id:Guid}")]
        public async Task<IActionResult> GetBookById(Guid id)
        {
            try
            {
                var book = await _bookStoreRepository.GetBookByIdAsync(id);
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


        [Authorize(Policy = "AdminOnly")]
        [HttpPost]
        public async Task<IActionResult> AddBook(CreateBookDTO addBookDTO)
        {
            try
            {
                var book = _mapper.Map<Book>(addBookDTO);
                var newBook = await _bookStoreRepository.AddBookAsync(book);
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

        [Authorize(Policy = "AdminOnly")]
        [HttpPut("{id:Guid}")]
        public async Task<IActionResult> UpdateBook(Guid id, UpdateBookDTO updateBookDTO)
        {
            try
            {
                var existingBook = await _bookStoreRepository.GetBookByIdAsync(id);
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

                await _bookStoreRepository.UpdateBookAsync(id, existingBook);
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

        [Authorize(Policy = "AdminOnly")]
        [HttpDelete("{id:Guid}")]
        public async Task<IActionResult> DeleteBook(Guid id)
        {
            try
            {
                await _bookStoreRepository.DeleteBookAsync(id);
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

        [HttpGet("filtered-sorted-paged")]
        public async Task<IActionResult> GetFilteredSortedPagedBooks(
            string filterField = null,
            string filterValue = null,
            string sortField = null,
            bool sortAscending = true,
            int pageNumber = 1,
            int pageSize = 10)
        {
            var (books, totalCount) = await _bookStoreRepository.GetFilteredSortedPagedBooksAsync(
                filterField,
                filterValue,
                sortField,
                sortAscending,
                pageNumber,
                pageSize);

            return Ok(new
            {
                TotalCount = totalCount,
                Books = books
            });
        }
    }
}

