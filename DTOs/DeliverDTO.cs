using System.ComponentModel.DataAnnotations;

namespace QuitQ_Ecom.DTOs
{
    public class DeliverDTO
    {
        [Required(ErrorMessage = "Ship ID is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "Ship ID must be a positive integer.")]
        public int ShipId { get; set; }

        [Required(ErrorMessage = "Order ID is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "Order ID must be a positive integer.")]
        public int OrderId { get; set; }

        [Required(ErrorMessage = "Order status is required.")]
        //[ValidOrderStatus(ErrorMessage = "Provided order status is not valid.")]
        public string OrderStatus { get; set; }
    }
}
