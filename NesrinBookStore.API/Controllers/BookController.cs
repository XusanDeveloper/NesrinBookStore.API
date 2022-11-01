using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NesrinBooks.API.DataAccess.Entities;
using NesrinBookStore.API.ActionFilters;
using NesrinBookStore.API.Models;
using NesrinBookStore.Data.Contracts;
using NesrinBookStore.Services.ActionFilters;
using NesrinBookStore.Services.Interfaces;


namespace NesrinBookStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;
        private readonly ILoggerManager _logger;

        public BookController(IBookService bookService, ILoggerManager logger)
        {
            _bookService = bookService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _bookService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            return Ok(await _bookService.Get(id));
        }

        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> Post([FromForm] BookViewModel book)
        {
            return Ok( await _bookService.Create(book));
        }

        [HttpPut("{id}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [ServiceFilter(typeof(ValidateBookExistsAttribute))]
        public async Task<IActionResult> Update(Guid id, [FromForm] BookViewModel book)
        {
            var updatedBook = await _bookService.Update(id, book);
            if (updatedBook == null)
            {
                _logger.LogInfo($"Book with id: {id} doesn't exist in the database.");
                return NotFound();
            }
            return Ok(updatedBook);
        }

        [HttpDelete("{id}")]
        [ServiceFilter(typeof(ValidateBookExistsAttribute))]
        public async Task<IActionResult> Delete(Guid id)
        {
            var book = HttpContext.Items["book"] as Books;

            await _bookService.Delete(id);
            
            return NoContent();
        }
    }
}
