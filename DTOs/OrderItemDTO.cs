using QuitQ_Ecom.Models;
using System.ComponentModel.DataAnnotations;

namespace QuitQ_Ecom.DTOs
{
    public class OrderItemDTO
    {
        [Required(ErrorMessage = "Order Item ID is required.")]
        [Range(0, int.MaxValue, ErrorMessage = "Order Item ID must be a positive integer.")]
        public int OrderItemId { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Order ID must be a positive integer if provided.")]
        public int? OrderId { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Product ID must be a positive integer if provided.")]
        public int? ProductId { get; set; }

        [Required(ErrorMessage = "Quantity is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be at least 1.")]
        public int Quantity { get; set; }

        public ProductDTO Product { get; set; }


    }
}
