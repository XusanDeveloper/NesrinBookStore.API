﻿using Microsoft.EntityFrameworkCore;
using NesrinBooks.API.DataAccess.Entities;
using NesrinBookStore.Data.Contexts;
using NesrinBookStore.Data.Contracts;

namespace NesrinBookStore.Data.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly NesrinDbContext _dbContext;
        public BookRepository(NesrinDbContext dbContext)
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