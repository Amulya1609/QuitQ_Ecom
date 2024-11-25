using System.ComponentModel.DataAnnotations;

namespace QuitQ_Ecom.DTOs
{
    public class StatusDTO
    {
        [Required(ErrorMessage = "Status ID is required.")]
        [Range(0, int.MaxValue, ErrorMessage = "Status ID must be a positive integer.")]
        public int StatusId { get; set; }

        [Required(ErrorMessage = "Status name is required.")]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "Status name must be between 1 and 100 characters.")]
        public string StatusName { get; set; }
    }
}
