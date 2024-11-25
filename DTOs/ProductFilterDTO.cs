namespace QuitQ_Ecom.DTOs
{
    public class ProductFilterDTO
    {
        public int? MinPrice { get; set; }
        public int? MaxPrice { get; set; }
        public int? BrandId { get; set; }
        public int? CategoryId { get; set; }
        public int? SubCategoryId { get; set; }
    }

}