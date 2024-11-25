using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace QuitQ_Ecom.DTOs
{
    public class ProductDetailDTO
    {
        [Range(1, int.MaxValue, ErrorMessage = "Product Detail ID must be a positive integer if provided.")]
        public int? ProductDetailId { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Product ID must be a positive integer if provided.")]
        public int? ProductId { get; set; }

        [Required(ErrorMessage = "Attribute name is required.")]
        [StringLength(100, ErrorMessage = "Attribute name must not exceed 100 characters.")]
        [JsonProperty("Attribute")]
        public string Attribute { get; set; }

        [Required(ErrorMessage = "Attribute value is required.")]
        [StringLength(200, ErrorMessage = "Attribute value must not exceed 200 characters.")]
        [JsonProperty("Value")]
        public string Value { get; set; }
    }
}
