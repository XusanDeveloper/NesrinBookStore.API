using System.Threading.Tasks;

namespace NesrinBookStore.Data.Contracts
{
    public interface IRepositoryManager
    {
        IBookRepository Book { get; }
        Task SaveAsync();
    }
}
