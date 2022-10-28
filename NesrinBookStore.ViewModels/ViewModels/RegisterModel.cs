using System.ComponentModel.DataAnnotations;

namespace NesrinBookStore.API.Models
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "Username is required!")]
        public string Username { get; set; }
        
        [Required(ErrorMessage = "Password is required!")]
        public string Password { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "Email is required!")]
        public string Email { get; set; }
    }
}
