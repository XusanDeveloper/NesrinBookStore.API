using NesrinBooks.API.DataAccess.Entities;
using System.ComponentModel.DataAnnotations;

namespace NesrinBookStore.API.Models
{
    public class BookViewModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Book name is a required field.")]
        [MaxLength(30, ErrorMessage = "Maximum length for the Name is 30 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Book author is a required field.")]
        [MaxLength(30, ErrorMessage = "Maximum length for the author is 30 characters.")]
        public string Author { get; set; }

        [Required(ErrorMessage = "Book price is a required field.")]
        [MaxLength(20, ErrorMessage = "Maximum length for the price is 20 characters.")]
        public string Price { get; set; }

        [Required(ErrorMessage = "Book rating is a required field.")]
        [MaxLength(5, ErrorMessage = "Maximum length for the rating is 5 characters.")]
        public string Rating { get; set; }

        [Required(ErrorMessage = "Book description is a required field.")]
        [MaxLength(500, ErrorMessage = "Maximum length for the description is 500 characters.")]
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
