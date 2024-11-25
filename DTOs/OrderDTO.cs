using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace QuitQ_Ecom.DTOs
{
    public class OrderDTO
    {
        [Required(ErrorMessage = "Order ID is required.")]
        [Range(0, int.MaxValue, ErrorMessage = "Order ID must be a positive integer.")]
        public int OrderId { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "User ID must be a positive integer.")]
        public int? UserId { get; set; }

        [Required(ErrorMessage = "Order date is required.")]
        public DateTime OrderDate { get; set; }

        [Required(ErrorMessage = "Total amount is required.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Total amount must be greater than zero.")]
        public decimal TotalAmount { get; set; }

        [Required(ErrorMessage = "Order status is required.")]
        [StringLength(50, ErrorMessage = "Order status must not exceed 50 characters.")]
        public string OrderStatus { get; set; }

        [Required(ErrorMessage = "Shipping address is required.")]
        [StringLength(200, ErrorMessage = "Shipping address must not exceed 200 characters.")]
        public string ShippingAddress { get; set; }

        [JsonIgnore]
        public List<OrderItemDTO>? orderItemListDTOs { get; set; }

        [JsonIgnore]
        public string? Shipper { get; set; }


    }
}
