using NesrinBookStore.Data.Contexts;
using NesrinBookStore.Data.Contracts;
using NesrinBookStore.Data.Repositories;

namespace Repository
{
    public class RepositoryManager : IRepositoryManager
    {
        private NesrinDbContext _repositoryContext;
        private IBookRepository _companyRepository;

        public RepositoryManager(NesrinDbContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }

        public IBookRepository Book
        {
            get
            {
                if (_companyRepository == null)
                    _companyRepository = new BookRepository(_repositoryContext);

                return _companyRepository;
            }
        }
        public Task SaveAsync() => _repositoryContext.SaveChangesAsync();
    }
}