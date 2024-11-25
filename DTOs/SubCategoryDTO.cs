using System.ComponentModel.DataAnnotations;

namespace QuitQ_Ecom.DTOs
{
    public class SubCategoryDTO
    {
        public int? SubCategoryId { get; set; }

        [Required(ErrorMessage = "Sub-category name is required.")]
        [StringLength(100, ErrorMessage = "Sub-category name must not exceed 100 characters.")]
        public string SubCategoryName { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Category ID must be a positive integer.")]
        public int? CategoryId { get; set; }
    }
}
