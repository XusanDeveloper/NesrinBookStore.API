using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NesrinBookStore.API.Models;
using NesrinBookStore.Services.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NesrinBookStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IGenericServices<BookViewModel> _bookService;
        public BookController(IGenericServices<BookViewModel> bookService)
        {
            _bookService = bookService;                
        }

        // GET: api/<BookController>
        [HttpGet]
        public async  Task<IActionResult> Get()
        {
            return Ok(await _bookService.GetAll());
        }

        // GET api/<BookController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            return Ok(await _bookService.Get(id));
        }

        // POST api/<BookController>
        [HttpPost]
        public async Task<IActionResult> Post([FromForm] BookViewModel book)
        {
            return Ok( await _bookService.Create(book));
        }

        // PUT api/<BookController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromForm] BookViewModel book)
        {
            var updatedBook =  await _bookService.Update(id, book);
            return Ok(updatedBook);
        }

        // DELETE api/<BookController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var deletedBook = await _bookService.Delete(id);
            if (deletedBook)
                return NoContent();
            return NotFound();
        }
    }
}
