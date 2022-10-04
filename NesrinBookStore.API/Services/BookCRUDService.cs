using NesrinBooks.API.DataAccess;
using NesrinBooks.API.DataAccess.Entities;
using NesrinBookStore.API.Models;
using NesrinStore.API.Services;

namespace NesrinBookStore.API.Services
{
    public class BookCRUDService : IGenericCRUDServices<BooksModel>
    {
        private readonly IBookRepository _bookRepository;
        public BookCRUDService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<BooksModel> Create(BooksModel model)
        {
            var book = new Books
            {
                Name = model.Name,
                Author = model.Author,
                Price = model.Price,
                Rating = model.Rating,
                Description = model.Description
            };
            var createdBook = await _bookRepository.CreateBook(book);
            var result = new BooksModel
            {
                Name = createdBook.Name,
                Author = createdBook.Author,
                Price = createdBook.Price,
                Rating = createdBook.Rating,
                Description = createdBook.Description,
                Id = createdBook.Id
            };
            return result;
        }

        public async Task<bool> Delete(int id)
        {
            return await _bookRepository.DeleteBook(id);
        }

        public async Task<BooksModel> Get(int id)
        {
            var book = await _bookRepository.GetBook(id);
            var model = new BooksModel
            {
                Id = book.Id,
                Name = book.Name,
                Author = book.Author,
                Price = book.Price,
                Rating = book.Rating,
                Description = book.Description
            };
            return model;
        }

        public async Task<IEnumerable<BooksModel>> GetAll()
        {
            var result = new List<BooksModel>();
            var books = await _bookRepository.GetBooks();
            foreach (var book in books)
            {
                var model = new BooksModel
                {
                    Id = book.Id,
                    Name = book.Name,
                    Author = book.Author,
                    Price = book.Price,
                    Rating = book.Rating,
                    Description = book.Description
                };
                result.Add(model);
            }
            return result;
        }

        public async Task<BooksModel> Update(int id, BooksModel model)
        {
            var book = new Books
            {
                Name = model.Name,
                Author = model.Author,
                Price = model.Price,
                Rating = model.Rating,
                Description = model.Description,
                Id = model.Id
            };
            var updatedBook = await _bookRepository.UpdateBook(id, book);
            var result = new BooksModel
            {
                Name = updatedBook.Name,
                Author = updatedBook.Author,
                Price = updatedBook.Price,
                Rating = updatedBook.Rating,
                Description = updatedBook.Description,
                Id = updatedBook.Id
            };
            return result;
        }
    }
}
