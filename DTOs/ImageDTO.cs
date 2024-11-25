using System.ComponentModel.DataAnnotations;

namespace QuitQ_Ecom.DTOs
{
    public class ImageDTO
    {
        [Range(0, int.MaxValue, ErrorMessage = "Image ID must be a positive integer.")]
        public int? ImageId { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Product ID must be a positive integer.")]
        public int? ProductId { get; set; }

        [Required(ErrorMessage = "Image file is required.")]
        public IFormFile ImageFile { get; set; }

        
        public string? ImageName { get; set; }

        //[StringLength(255, ErrorMessage = "Stored image path cannot exceed 255 characters.")]
        public string? StoredImage { get; set; }
    }
}
