using Microsoft.EntityFrameworkCore;
using NesrinBooks.API.DataAccess.Entities;
using NesrinBookStore.Data.Contexts;
using NesrinBookStore.Data.Contracts;
using Repository;

namespace NesrinBookStore.Data.Repositories
{
    public class BookRepository : RepositoryBase<Books>, IBookRepository
    {
        private readonly NesrinDbContext _dbContext;
        public BookRepository(NesrinDbContext dbContext)
            : base(dbContext)
        {
            _dbContext = dbContext;
        }
        public void CreateBook(Books book) => Create(book);

        public async Task<bool> DeleteBook(Guid id)
        {
            var book = await _dbContext.books.FindAsync(id);
            if (book != null)
            {
                _dbContext.books.Remove(book);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<Books> GetBook(Guid id, bool trackChanges) =>
            await FindByCondition(c => c.Id.Equals(id), trackChanges).SingleOrDefaultAsync();

        public async Task<IEnumerable<Books>> GetBooks(bool trackChanges) =>
            await FindAll(trackChanges).ToListAsync();


        public async Task<Books> UpdateBook(Guid id, Books book)
        {
            var updatedBook = _dbContext.books.Attach(book);
            
            updatedBook.State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return book;
        }
    }
}
