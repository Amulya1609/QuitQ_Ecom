using System.ComponentModel.DataAnnotations;

namespace QuitQ_Ecom.DTOs
{
     public class CategoryDTO
    {
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Category name is required.")]
        [StringLength(100, ErrorMessage = "Category name must not exceed 100 characters.")]
        public string CategoryName { get; set; }
    }
}
