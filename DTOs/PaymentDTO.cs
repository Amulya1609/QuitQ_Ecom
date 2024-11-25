using System.ComponentModel.DataAnnotations;

namespace QuitQ_Ecom.DTOs
{
    public class PaymentDTO
    {
        [Required(ErrorMessage = "Payment ID is required.")]
        [Range(0, int.MaxValue, ErrorMessage = "Payment ID must be a positive integer.")]
        public int PaymentId { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Order ID must be a positive integer if provided.")]
        public int? OrderId { get; set; }

        //[Required(ErrorMessage = "Payment date is required.")]
        public DateTime PaymentDate { get; set; }

        [Required(ErrorMessage = "Amount is required.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Amount must be greater than zero.")]
        public decimal Amount { get; set; }

        [Required(ErrorMessage = "Payment method is required.")]
        [StringLength(50, ErrorMessage = "Payment method must not exceed 50 characters.")]
        public string PaymentMethod { get; set; }

        [StringLength(100, ErrorMessage = "Transaction ID must not exceed 100 characters.")]
        public string? TransactionId { get; set; }

        [StringLength(50, ErrorMessage = "Payment status must not exceed 50 characters.")]
        public string? PaymentStatus { get; set; }
    }
}
