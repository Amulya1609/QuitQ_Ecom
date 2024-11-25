using System.ComponentModel.DataAnnotations;

namespace QuitQ_Ecom.DTOs
{
    public class GenderDTO
    {
        [Required(ErrorMessage = "Gender ID is required.")]
        [Range(0, int.MaxValue, ErrorMessage = "Gender ID must be a positive integer.")]
        public int GenderId { get; set; }

        [Required(ErrorMessage = "Gender name is required.")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Gender name must be between 1 and 50 characters.")]
        public string GenderName { get; set; }
    }
}
