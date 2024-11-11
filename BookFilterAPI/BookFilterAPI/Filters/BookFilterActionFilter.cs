using BookFilterAPI.Models.DTO;
using BookFilterAPI.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;

namespace BookFilterAPI.Filters
{
    public class BookFilterActionFilter : IActionFilter
    {
        private readonly ILogger<BookFilterActionFilter> _logger;
        private readonly IBookFilterRepository _bookFilterRepository;

        public BookFilterActionFilter(ILogger<BookFilterActionFilter> logger, IBookFilterRepository bookFilterRepository)
        {
            _logger = logger;
            _bookFilterRepository = bookFilterRepository;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            // Extract query parameter 'title'
            var queryParams = context.HttpContext.Request.Query;

            BookFilterDTO filter = new()
            {
                Title = queryParams.ContainsKey("title") ? queryParams["title"].ToString() : null
            };

            // Add the filter object to the Action Arguments
            context.ActionArguments["filter"] = filter;
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            // Optionally log or manipulate the result after action executes
        }
    }
}
