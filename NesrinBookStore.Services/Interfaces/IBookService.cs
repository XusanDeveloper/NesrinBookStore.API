using NesrinBooks.API.DataAccess.Entities;
using NesrinBookStore.API.Models;

namespace NesrinBookStore.Services.Interfaces
{
    public interface IBookService
    {
        Task<IEnumerable<BookViewModel>> GetAll();
        Task<BookViewModel> Create(BookViewModel book);
        Task<BookViewModel> Get(Guid id);
        Task<BookViewModel> Update(Guid id, BookViewModel book);
        Task<bool> Delete(Guid id);
    }
}
