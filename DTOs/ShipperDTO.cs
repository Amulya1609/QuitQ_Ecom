using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace QuitQ_Ecom.DTOs
{
    public class ShipperDTO
    {
        [Required(ErrorMessage = "Shipper ID is required.")]
        [Range(0, int.MaxValue, ErrorMessage = "Shipper ID must be a positive integer.")]
        public int ShipperId { get; set; }

        [JsonPropertyName("OTP")]
        [StringLength(100, ErrorMessage = "Shipper name must not exceed 100 characters.")]
        public string? ShipperName { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Order ID must be a positive integer if provided.")]
        public int? OrderId { get; set; }

        
    }
}
