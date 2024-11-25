using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace QuitQ_Ecom.DTOs
{
    public class ProductDTO
    {
        [Range(0, int.MaxValue, ErrorMessage = "Product ID must be a positive integer if provided.")]
        public int? ProductId { get; set; }

        [Required(ErrorMessage = "Product name is required.")]
        [StringLength(100, ErrorMessage = "Product name must not exceed 100 characters.")]
        public string ProductName { get; set; } = string.Empty;

        [NotMapped]
        public IFormFile? ProductImageFile { get; set; }

        public string? ProductImage { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Store ID must be a positive integer if provided.")]
        public int? StoreId { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Product Status ID must be a positive integer if provided.")]
        public int? ProductStatusId { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Brand ID must be a positive integer if provided.")]
        public int? BrandId { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Category ID must be a positive integer if provided.")]
        public int? CategoryId { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "SubCategory ID must be a positive integer if provided.")]
        public int? SubCategoryId { get; set; }

        [Required(ErrorMessage = "Price is required.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than zero.")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Quantity is required.")]
        [Range(0, int.MaxValue, ErrorMessage = "Quantity must be a non-negative integer.")]
        public int Quantity { get; set; }

        [StringLength(100, ErrorMessage = "Seller name must not exceed 100 characters.")]
        [JsonIgnore]
        [NotMapped]
        public string? sellerName { get; set; }


        [JsonIgnore]
        [NotMapped]
        public string? BrandName { get; set; }
        [JsonIgnore]
        [NotMapped]
        public string? StoreName { get; set; }

        [JsonIgnore]
        [NotMapped]
        public string? CategoryName { get; set; }

        [JsonIgnore]
        [NotMapped]
        public string? SubCategoryName { get; set; }



        [JsonIgnore]
        public List<ProductDetailDTO>? ProductDetails { get; set; }

        [JsonIgnore]
        public List<ImageDTO>? Images { get; set; }

        //public List<ImageDTO>? Images { get; set; }

        //public static ProductDTO FromForm(IFormCollection form)
        //{
        //    return new ProductDTO
        //    {
        //        ProductName = form["ProductName"],
        //        StoreId = form.ContainsKey("StoreId") ? Convert.ToInt32(form["StoreId"]) : null,
        //        ProductStatusId = form.ContainsKey("ProductStatusId") ? Convert.ToInt32(form["ProductStatusId"]) : null,
        //        BrandId = form.ContainsKey("BrandId") ? Convert.ToInt32(form["BrandId"]) : null,
        //        CategoryId = form.ContainsKey("CategoryId") ? Convert.ToInt32(form["CategoryId"]) : null,
        //        SubCategoryId = form.ContainsKey("SubCategoryId") ? Convert.ToInt32(form["SubCategoryId"]) : null,
        //        Price = Convert.ToDecimal(form["Price"]),
        //        Quantity = Convert.ToInt32(form["Quantity"]),
        //        //ProductDetails = JsonConvert.DeserializeObject<List<ProductDetailDTO>>(form["ProductDetails"])
        //        ProductDetails = form["ProductDetails"];



        //    };

    }
}

