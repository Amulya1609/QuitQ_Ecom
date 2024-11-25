using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace QuitQ_Ecom.DTOs
{
    public class UserDTO
    {
        public int? UserId { get; set; }

        [Required(ErrorMessage = "User type ID is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "User type ID must be a positive integer.")]
        public int UserTypeId { get; set; }

        [Required(ErrorMessage = "Username is required.")]
        [StringLength(50, ErrorMessage = "Username must not exceed 50 characters.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [PasswordPropertyText]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Email must be a valid email address.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "First name is required.")]
        [StringLength(50, ErrorMessage = "First name must not exceed 50 characters.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required.")]
        [StringLength(50, ErrorMessage = "Last name must not exceed 50 characters.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Date of birth is required.")]
        [DataType(DataType.Date)]
        public DateTime Dob { get; set; }

        [Required(ErrorMessage = "Contact number is required.")]
        [Phone(ErrorMessage = "Contact number must be a valid phone number.")]
        public string ContactNumber { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Gender ID must be a positive integer.")]
        public int? GenderId { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "User status ID must be a positive integer.")]
        public int? UserStatusId { get; set; }
    }
}
