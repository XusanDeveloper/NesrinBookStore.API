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
        public async Task<Books> CreateBook(Books book)
        {
            await _dbContext.AddAsync(book);
            await _dbContext.SaveChangesAsync();
            return book;
        }

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

        public async Task<Books> GetBook(Guid id)
        {
            return await _dbContext.books.FindAsync(id);
        }

        public async Task<IEnumerable<Books>> GetBooks(bool trackChanges) =>
            await FindAll(trackChanges).OrderBy(c => c.Name).ToListAsync();


        public async Task<Books> UpdateBook(Guid id, Books book)
        {
            var updatedBook = _dbContext.books.Attach(book);
            updatedBook.State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return book;
        }
    }
}
