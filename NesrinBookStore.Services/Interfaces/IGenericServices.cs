namespace NesrinBookStore.Services.Interfaces
{
    public interface IGenericServices<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> Create(T book);
        Task<T> Get(int id);
        Task<T> Update(int id, T book);
        Task<bool> Delete(int id);
    }
}
