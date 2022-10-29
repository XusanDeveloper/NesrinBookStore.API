using AutoMapper;
using NesrinBooks.API.DataAccess.Entities;
using NesrinBookStore.API.Models;
using NesrinBookStore.Data.Contracts;
using NesrinBookStore.Services.Interfaces;

namespace NesrinBookStore.API.Services
{
    public class BookService : IGenericServices<BookViewModel>
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper mapper;

        public BookService(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            this.mapper = mapper;
        }

        public async Task<BookViewModel> Create(BookViewModel model)
        {
            
            var book = mapper.Map<Books>(model);
            var createdBook = await _bookRepository.CreateBook(book);
            
            var result = mapper.Map<BookViewModel>(createdBook);
            return result;
        }

        public async Task<bool> Delete(Guid id)
        {
            return await _bookRepository.DeleteBook(id);
        }

        public async Task<BookViewModel> Get(Guid id)
        {
            var book = await _bookRepository.GetBook(id);
            
            var model = mapper.Map<BookViewModel>(book);
            
            return model;
        }

        public async Task<IEnumerable<BookViewModel>> GetAll()
        {
            var books = await _bookRepository.GetBooks(trackChanges: false);

            var domainResult = mapper.Map<IQueryable<BookViewModel>>(books);
            
            return domainResult;
        }

        public async Task<BookViewModel> Update(Guid id, BookViewModel model)
        {
            
            var book = mapper.Map<Books>(model);

            var updatedBook = await _bookRepository.UpdateBook(id, book);

            var result = mapper.Map<BookViewModel>(updatedBook);
            
            return result;
        }
    }
}
