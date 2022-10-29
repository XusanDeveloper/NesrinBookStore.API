using NesrinBooks.API.DataAccess.Entities;

namespace NesrinBookStore.API.Models
{
    public class BookViewModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Author { get; set; }
        
        public string Price { get; set; }

        public string Rating { get; set; }

        public string Description { get; set; }

        public static explicit operator BookViewModel(Books v)
        {
            return new BookViewModel
            {
                Id = v.Id,
                Name = v.Name,
                Author = v.Author,
                Price = v.Price,
                Rating = v.Rating,
                Description = v.Description,
            };
        }
        public static explicit operator Books(BookViewModel v)
        {
            return new Books
            {
                Id = v.Id,
                Name = v.Name,
                Author = v.Author,
                Price = v.Price,
                Rating = v.Rating,
                Description = v.Description,
            };
        }
    }
}
