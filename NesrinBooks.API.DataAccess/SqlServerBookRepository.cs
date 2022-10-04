using Microsoft.EntityFrameworkCore;
using NesrinBooks.API.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NesrinBooks.API.DataAccess
{
    public class SqlServerBookRepository : IBookRepository
    {
        private readonly AppDbContext _dbContext;
        public SqlServerBookRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Books> CreateBook(Books book)
        {
            await _dbContext.AddAsync(book);
            await _dbContext.SaveChangesAsync();
            return book;
        }

        public async Task<bool> DeleteBook(int id)
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

        public async Task<Books> GetBook(int id)
        {
            return await _dbContext.books.FindAsync(id);
        }

        public async Task<IEnumerable<Books>> GetBooks()
        {
            return await _dbContext.books.ToListAsync();
        }

        public async Task<Books> UpdateBook(int id, Books book)
        {
            var updatedBook = _dbContext.books.Attach(book);
            updatedBook.State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return book;
        }
    }
}
