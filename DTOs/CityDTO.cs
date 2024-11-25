using System.ComponentModel.DataAnnotations;

namespace QuitQ_Ecom.DTOs
{
    public class CityDTO
    {
        [Required(ErrorMessage = "City ID is required.")]
        [Range(0, int.MaxValue, ErrorMessage = "City ID must be a positive integer.")]
        public int CityId { get; set; }

        [Required(ErrorMessage = "City name is required.")]
        [StringLength(100, ErrorMessage = "City name must not exceed 100 characters.")]
        public string CityName { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "State ID must be a positive integer if provided.")]
        public int? StateId { get; set; }
    }
}
