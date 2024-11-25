using System.ComponentModel.DataAnnotations;

namespace QuitQ_Ecom.DTOs
{
    public class StateDTO
    {
        [Required(ErrorMessage = "State ID is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "State ID must be a positive integer.")]
        public int StateId { get; set; }

        [Required(ErrorMessage = "State name is required.")]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "State name must be between 1 and 100 characters.")]
        public string StateName { get; set; }
    }
}
