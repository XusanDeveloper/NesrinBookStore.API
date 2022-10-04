using Microsoft.AspNetCore.Mvc;
using NesrinBooks.API.DataAccess.Entities;
using NesrinBookStore.API.Models;
using NesrinStore.API.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NesrinBookStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IGenericCRUDServices<BooksModel> _bookSvc;
        public BookController(IGenericCRUDServices<BooksModel> bookSvc)
        {
            _bookSvc = bookSvc;                
        }

        // GET: api/<BookController>
        [HttpGet]
        public async  Task<IActionResult> Get()
        {
            return Ok(await _bookSvc.GetAll());
        }

        // GET api/<BookController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if (id == 0)
                return NotFound($"Employee with given id:{id} is not found.");
            else if (id < 0)
                return BadRequest("Wrong data!");

            return Ok(await _bookSvc.Get(id));
        }

        // POST api/<BookController>
        [HttpPost]
        public async Task<IActionResult> Post([FromForm] BooksModel book)
        {
            return Ok( await _bookSvc.Create(book));
        }

        // PUT api/<BookController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromForm] BooksModel book)
        {
            var updatedBook =  await _bookSvc.Update(id, book);
            return Ok(updatedBook);
        }

        // DELETE api/<BookController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deletedBook = await _bookSvc.Delete(id);
            if (deletedBook)
                return NoContent();
            return NotFound();
        }
    }
}
