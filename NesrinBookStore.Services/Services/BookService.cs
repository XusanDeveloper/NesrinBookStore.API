using AutoMapper;
using NesrinBooks.API.DataAccess.Entities;
using NesrinBookStore.API.Models;
using NesrinBookStore.Data.Contracts;
using NesrinBookStore.Domain.RequestFeatures;
using NesrinBookStore.Services.Interfaces;

namespace NesrinBookStore.API.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper mapper;
        private readonly IRepositoryManager repositoryManager;

        public BookService(IBookRepository bookRepository, IMapper mapper, IRepositoryManager repositoryManager)
        {
            _bookRepository = bookRepository;
            this.mapper = mapper;
            this.repositoryManager = repositoryManager;
        }

        public async Task<BookViewModel> Create(BookViewModel model)
        {
            

            _bookRepository.CreateBook((Books)model);
            await repositoryManager.SaveAsync();

            return model;
        }

        public async Task<bool> Delete(Guid id)
        {
            return await _bookRepository.DeleteBook(id);
        }

        public async Task<BookViewModel> Get(Guid id)
        {
            var book = await _bookRepository.GetBook(id, trackChanges: false);
            
            var model = mapper.Map<BookViewModel>(book);
            
            return model;
        }

        public async Task<IEnumerable<BookViewModel>> GetAll()
        {
            var books = await _bookRepository.GetBooks(trackChanges: false);

            var domainResult = mapper.Map<List<BookViewModel>>(books);

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
