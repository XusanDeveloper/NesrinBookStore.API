namespace NesrinStore.API.Services
{
    public interface IGenericCRUDServices<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> Create(T book);
        Task<T> Get(int id);
        Task<T> Update(int id, T book);
        Task<bool> Delete(int id);
    }
}
