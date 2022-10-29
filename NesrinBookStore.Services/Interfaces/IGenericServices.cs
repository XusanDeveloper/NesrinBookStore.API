namespace NesrinBookStore.Services.Interfaces
{
    public interface IGenericServices<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> Create(T book);
        Task<T> Get(Guid id);
        Task<T> Update(Guid id, T book);
        Task<bool> Delete(Guid id);
    }
}
