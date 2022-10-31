using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NesrinBooks.API.DataAccess.Entities
{
    public class Books
    {
        [Column("BookId")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Book name is a required field.")]
        [MaxLength(100, ErrorMessage = "Maximum length for the Name is 60 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Book author is a required field.")]
        [MaxLength(60, ErrorMessage = "Maximum length for the Name is 60 characters.")]
        public string Author { get; set; }

        [Required(ErrorMessage = "Book price is a required field.")]
        [MaxLength(20, ErrorMessage = "Maximum length for the price is 20 characters.")]
        public string Price { get; set; }

        [Required(ErrorMessage = "Book author is a required field.")]
        [MaxLength(5, ErrorMessage = "Maximum length for the Name is 5 characters.")]
        public string Rating { get; set; }

        [Required(ErrorMessage = "Book description is a required field.")]
        [MaxLength(500, ErrorMessage = "Maximum length for the description is 500 characters.")]
        public string Description { get; set; }
    }
}
