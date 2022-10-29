using NesrinBooks.API.DataAccess.Entities;

namespace NesrinBookStore.Data.Contracts
{
    public interface IBookRepository
    {
        Task<IEnumerable<Books>> GetBooks(bool trackChanges);
        Task<Books> CreateBook(Books book);
        Task<Books> GetBook(Guid id);
        Task<Books> UpdateBook(Guid id, Books book);
        Task<bool> DeleteBook(Guid id);
    }
}