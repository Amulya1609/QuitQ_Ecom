using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuitQ_Ecom.DTOs
{
    public class CartDTO
    {
        public int CartId { get; set; }

        [Required(ErrorMessage = "User ID is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "User ID must be a positive integer.")]
        public int UserId { get; set; }

        [Required(ErrorMessage = "Product ID is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "Product ID must be a positive integer.")]
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Quantity is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be at least 1.")]
        public int Quantity { get; set; }

        [JsonIgnore]
        [NotMapped]
        public string? ProductName { get; set; }
        [JsonIgnore]
        [NotMapped]

        public decimal? ProductPrice { get; set; }
        [JsonIgnore]
        [NotMapped]
        public string? ProductImage { get; set; }
    }
}
