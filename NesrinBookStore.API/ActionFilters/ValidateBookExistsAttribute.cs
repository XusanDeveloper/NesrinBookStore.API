using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using NesrinBookStore.Data.Contracts;
using NesrinBookStore.Services.Interfaces;

namespace NesrinBookStore.API.ActionFilters
{
    public class ValidateBookExistsAttribute : IAsyncActionFilter
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        public ValidateBookExistsAttribute(IRepositoryManager repository, ILoggerManager logger)
        {
            _repository = repository;
            _logger = logger;
        }
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var trackChanges = context.HttpContext.Request.Method.Equals("PUT");
            var id = (Guid)context.ActionArguments["id"];

            var book = await _repository.Book.GetBook(id, trackChanges);
            if (book == null)
            {
                _logger.LogInfo($"Book with id: {id} doesn't exist in the database.");
                context.Result = new NotFoundResult();
            }
            else
            {
                context.HttpContext.Items.Add("book", book);
                await next();
            }
        }
    }
}
