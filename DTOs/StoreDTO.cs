using System.ComponentModel.DataAnnotations;

namespace QuitQ_Ecom.DTOs
{
    public class StoreDTO
    {
        [Range(0, int.MaxValue, ErrorMessage = "Store ID must be a positive integer.")]
        public int? StoreId { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Seller ID must be a positive integer.")]
        public int? SellerId { get; set; }

        [StringLength(100, ErrorMessage = "Store name must not exceed 100 characters.")]
        public string? StoreName { get; set; }

        [StringLength(500, ErrorMessage = "Description must not exceed 500 characters.")]
        public string? Description { get; set; }

        [Required(ErrorMessage = "Store image file is required.")]
        public IFormFile StoreImageFile { get; set; }

        public string? StoreLogo { get; set; }

        [Required(ErrorMessage = "Store full address is required.")]
        [StringLength(200, ErrorMessage = "Store full address must not exceed 200 characters.")]
        public string StoreFullAddress { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "City ID must be a positive integer.")]
        public int? CityId { get; set; }

        [Required(ErrorMessage = "Contact number is required.")]
        [Phone(ErrorMessage = "Contact number is not valid.")]
        [StringLength(20, ErrorMessage = "Contact number must not exceed 20 characters.")]
        public string ContactNumber { get; set; }
    }
}
