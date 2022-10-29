using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NesrinBooks.API.DataAccess.Entities;
using NesrinBookStore.API.Models;
using NesrinBookStore.Data.Contracts;
using NesrinBookStore.Services.Interfaces;


namespace NesrinBookStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;
        private readonly IBookRepository bookRepository;
        private readonly IMapper mapper;
        private readonly IRepositoryManager repositoryManager;

        public BookController(IBookService bookService, IBookRepository bookRepository, IMapper mapper, IRepositoryManager repositoryManager)
        {
            _bookService = bookService;
            this.bookRepository = bookRepository;
            this.mapper = mapper;
            this.repositoryManager = repositoryManager;
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
        public async Task<IActionResult> Post([FromForm] BookViewModel book)
        {
            return Ok( await _bookService.Create(book));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromForm] BookViewModel book)
        {
            var updatedBook = await _bookService.Update(id, book);
            return Ok(updatedBook);

            //var bookEntity = HttpContext.Items["books"] as Books;

            //mapper.Map(book, bookEntity);
            //await repositoryManager.SaveAsync();
            //return NoContent();
        }

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
