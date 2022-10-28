
using NesrinBooks.API.DataAccess.Entities;

namespace NesrinBooks.API.DataAccess
{
    public interface IBookRepository
    {
        Task<IEnumerable<Books>> GetBooks();
        Task<Books> CreateBook(Books book);
        Task<Books> GetBook(int id);
        Task<Books> UpdateBook(int id, Books book);
        Task<bool> DeleteBook(int id);
    }
}