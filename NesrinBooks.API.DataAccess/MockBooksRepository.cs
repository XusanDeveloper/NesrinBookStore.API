using NesrinBooks.API.DataAccess.Entities;
using System.Collections.Concurrent;

namespace NesrinBooks.API.DataAccess
{
    public class MockBooksRepository : IBookRepository
    {
        private static ConcurrentDictionary<int, Books> _books = new ConcurrentDictionary<int, Books>();
        private static object locker = new();

        public MockBooksRepository()
        {
            Init();
        }
        public void Init()
        {
            _books.TryAdd(1, new Books { Id = 1, Name = "Meni qalbimdan tinngla", Author = "Abdurrahman Uzun", Rating = "4", Price = "34 000", Description = "So'zlarim yarim qoldi." });
            _books.TryAdd(2, new Books { Id = 2, Name = "Murosayu Madora", Author = "Sema Marashli", Rating = "3", Price = "30 000", Description = "Qaynona kelin munosabatlarida." });
            _books.TryAdd(3, new Books { Id = 3, Name = "Xalol luqma", Author = "Rauf Jillasun", Rating = "5", Price = "40 000", Description = "Haloli shirinroq." });
            _books.TryAdd(4, new Books { Id = 4, Name = "Muslimlar xulqi", Author = "Muxammad Al-G'azzoliy", Rating = "5", Price = "50 000", Description = "Xulqli muslim." });
        }


        public async Task<IEnumerable<Books>> GetBooks()
        {
            return await Task.FromResult(_books.Values);
        }

        public Task<Books> CreateBook(Books book)
        {
            int newId = 0;
            lock(locker)
            {
                newId = _books.Keys.Max() + 1;
            }
            book.Id = newId;
            _books.TryAdd(newId, book);
            return Task.FromResult(book);
        }

        public async Task<Books> GetBook(int id)
        {
            return await Task.FromResult(_books[id]);
        }

        public async Task<Books> UpdateBook(int id, Books book)
        {
            await Task.FromResult(_books[id] = book);
            return book;
            
        }

        public Task<bool> DeleteBook(int id)
        {
            if (_books.ContainsKey(id))
            {
                _books.TryRemove(id, out _);
                return Task.FromResult(true);
            }
            else
            {
                return Task.FromResult(false);
            }
        }
    }
}
