using AutoMapper;
using Microsoft.EntityFrameworkCore;
using QuitQ_Ecom.DTOs;
using QuitQ_Ecom.Models;
using Microsoft.Extensions.Logging; // Add this namespace for ILogger
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QuitQ_Ecom.Repository.Exceptions; // Add this namespace for custom exceptions

namespace QuitQ_Ecom.Repository
{
    public class ProductRepositoryImpl : IProduct
    {
        private readonly QuitQEcomContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<ProductRepositoryImpl> _logger; // Add ILogger

        public ProductRepositoryImpl(QuitQEcomContext quitQEcomContext, IMapper mapper, ILogger<ProductRepositoryImpl> logger) // Add ILogger to constructor
        {
            _context = quitQEcomContext;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<List<ProductDTO>> GetProductsBySubCategory(int SubcategoryId)
        {
            try
            {
                var productsOfSubcategory = await _context.Products
                    .Include(p => p.ProductDetails) // Eager loading ProductDetails
                    .Where(x => x.SubCategoryId == SubcategoryId)
                    .ToListAsync();

                if (productsOfSubcategory != null)
                {
                    return _mapper.Map<List<ProductDTO>>(productsOfSubcategory);
                }
                return new List<ProductDTO>();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error retrieving products by subcategory ID {SubcategoryId}: {ex.Message}");
                throw new GetProductsBySubCategoryException($"Error retrieving products by subcategory ID {SubcategoryId}: {ex.Message}");
            }
        }

        public async Task<ProductDTO> AddNewProduct(ProductDTO productDTO, List<ImageDTO> imagesDTOs)
        {
            try
            {
                if (productDTO.Quantity == 0)
                {
                    productDTO.ProductStatusId = 2;
                }
                var storeobj = await _context.Stores.FindAsync(productDTO.StoreId);
                var sellerObj = await _context.Users.FindAsync(storeobj.SellerId);
                var product = _mapper.Map<Models.Product>(productDTO);

                await _context.Products.AddAsync(product);
                await _context.SaveChangesAsync();

                foreach (var imagesDTO in imagesDTOs)
                {
                    var imageobj = new Image()
                    {
                        ImageName = imagesDTO.ImageName,
                        StoredImage = imagesDTO.StoredImage
                    };

                    product.Images.Add(imageobj);
                }

                await _context.SaveChangesAsync();

                var productDtoMapped = _mapper.Map<ProductDTO>(product);
                productDtoMapped.sellerName = sellerObj.FirstName + " " + sellerObj.LastName;
                return productDtoMapped;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error adding new product: {ex.Message}");
                throw new AddProductException($"Error adding new product: {ex.Message}");
            }
        }

        public async Task<ProductDTO> GetProductById(int productId)
        {
            try
            {
                var product = await _context.Products
                    .Include(p => p.ProductDetails) // Eager loading ProductDetails
                    .Include(p => p.Images) // Eager loading Images
                    .FirstOrDefaultAsync(p => p.ProductId == productId);

                if (product == null)
                {
                    return null;
                }

                var storeObj = await _context.Stores.FindAsync(product.StoreId);
                var sellerObj = await _context.Users.FindAsync(storeObj.SellerId);
                var brandobj = await _context.Brands.FindAsync(product.BrandId);
                var CategoryObj = await _context.Categories.FindAsync(product.CategoryId);
                var SubCategoryObj = await _context.SubCategories.FindAsync(product.SubCategoryId);

                var productDtoMapped = _mapper.Map<ProductDTO>(product);
                productDtoMapped.sellerName = sellerObj.FirstName + " " + sellerObj.LastName;
                productDtoMapped.StoreName = storeObj.StoreName;
                productDtoMapped.BrandName = brandobj.BrandName;
                productDtoMapped.CategoryName = CategoryObj.CategoryName;
                productDtoMapped.SubCategoryName = SubCategoryObj.SubCategoryName;

                // Map images
                if (product.Images != null)
                {
                    productDtoMapped.Images = product.Images.Select(img => new ImageDTO
                    {
                        ImageId = img.ImageId,
                        ProductId = img.ProductId,
                        StoredImage = img.StoredImage, // Assume you store the path as StoredImagePath in the DB
                        ImageName = img.ImageName
                    }).ToList();
                }

                return productDtoMapped;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error retrieving product by ID {productId}: {ex.Message}");
                throw new GetProductByIdException($"Error retrieving product by ID {productId}: {ex.Message}");
            }
        }

        public async Task<ProductDTO> UpdateProduct(int productId, ProductDTO formData, List<ProductDetailDTO> listproductdetaildtos)
        {
            try
            {
                var existingProduct = await _context.Products.FindAsync(productId);

                if (existingProduct == null)
                {
                    throw new InvalidOperationException("Product not found");
                }

                _mapper.Map(formData, existingProduct);
                existingProduct.ProductDetails = _mapper.Map<List<ProductDetail>>(listproductdetaildtos);
                _context.Update(existingProduct);
                await _context.SaveChangesAsync();

                return _mapper.Map<ProductDTO>(existingProduct);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error updating product with ID {productId}: {ex.Message}");
                throw new UpdateProductException($"Error updating product with ID {productId}: {ex.Message}");
            }
        }

        public async Task<bool> DeleteProductByID(int id)
        {
            try
            {
                var product = await _context.Products.FindAsync(id);

                if (product != null)
                {
                    _context.Products.Remove(product);
                    await _context.SaveChangesAsync();
                    return true; // Product deleted successfully
                }
                else
                {
                    return false; // Product not found or deletion unsuccessful
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error deleting product with ID {id}: {ex.Message}");
                throw new DeleteProductException($"Error deleting product with ID {id}: {ex.Message}");
            }
        }

        public async Task<List<ProductDTO>> CheckQuantityOfProducts(List<CartDTO> cartItems)
        {
            try
            {
                List<Models.Product> productsQuantityNotSatistfied = new List<Models.Product>();

                foreach (var cartItem in cartItems)
                {
                    var productobj = await _context.Products.FindAsync(cartItem.ProductId);

                    if (productobj != null && productobj.Quantity < cartItem.Quantity)
                    {
                        productsQuantityNotSatistfied.Add(productobj);
                    }
                }

                return _mapper.Map<List<ProductDTO>>(productsQuantityNotSatistfied);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error checking quantity of products: {ex.Message}");
                throw new CheckProductQuantityException($"Error checking quantity of products: {ex.Message}");
            }
        }

        public async Task<bool> UpdateQuantitiesOfProducts(List<CartDTO> cartItems)
        {
            try
            {
                var cartItemObj = _mapper.Map<List<Cart>>(cartItems);

                foreach (var item in cartItemObj)
                {
                    var productobj = await _context.Products.FindAsync(item.ProductId);

                    if (productobj != null)
                    {
                        productobj.Quantity -= item.Quantity;

                        if (productobj.Quantity <= 0)
                        {
                            productobj.ProductStatusId = 2; // Mark product status as false
                        }

                        _context.Update(productobj);
                    }
                }

                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error updating quantities of products: {ex.Message}");
                throw new UpdateProductQuantityException($"Error updating quantities of products: {ex.Message}");
            }
        }

        public async Task<List<ProductDTO>> SearchProducts(string query)
        {
            try
            {
                var products = await _context.Products
                    .Where(p => EF.Functions.Like(p.ProductName, $"%{query}%"))
                    .ToListAsync();

                return _mapper.Map<List<ProductDTO>>(products);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error searching products with query '{query}': {ex.Message}");
                throw new SearchProductException($"Error searching products with query '{query}': {ex.Message}");
            }
        }

        public async Task<List<ProductDTO>> GetAllProducts()
        {
            try
            {
                var products = await _context.Products.ToListAsync();

                return _mapper.Map<List<ProductDTO>>(products);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error retrieving all products: {ex.Message}");
                throw new GetAllProductsException($"Error retrieving all products: {ex.Message}");
            }
        }

        public async Task<List<ProductDTO>> GetAllProductsByStoreId(int storeId)
        {
            try
            {
                var products = await _context.Products.Where(x => x.StoreId == storeId).ToListAsync();

                List<ProductDTO> result = _mapper.Map<List<ProductDTO>>(products);

                foreach (var product in result)
                {
                    var brandobj = await _context.Brands.FindAsync(product.BrandId);
                    var CategoryObj = await _context.Categories.FindAsync(product.CategoryId);
                    var SubCategoryObj = await _context.SubCategories.FindAsync(product.SubCategoryId);
                    product.BrandName = brandobj.BrandName;
                    product.CategoryName = CategoryObj.CategoryName;
                    product.SubCategoryName = SubCategoryObj.SubCategoryName;
                }

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error retrieving all products from the store: {ex.Message}");
                throw new GetAllProductsByStoreIdException($"Error retrieving all products from the store: {ex.Message}");
            }
        }

        public async Task<List<ProductDTO>> FilterProducts(ProductFilterDTO filterDTO)
        {
            try
            {
                var query = _context.Products.AsQueryable();

                // Apply filter criteria
                if (filterDTO.MinPrice.HasValue)
                {
                    query = query.Where(p => p.Price >= filterDTO.MinPrice);
                }

                if (filterDTO.MaxPrice.HasValue)
                {
                    query = query.Where(p => p.Price <= filterDTO.MaxPrice);
                }

                if (filterDTO.BrandId.HasValue)
                {
                    query = query.Where(p => p.BrandId == filterDTO.BrandId);
                }

                if (filterDTO.CategoryId.HasValue)
                {
                    query = query.Where(p => p.CategoryId == filterDTO.CategoryId);
                }

                if (filterDTO.SubCategoryId.HasValue)
                {
                    query = query.Where(p => p.SubCategoryId == filterDTO.SubCategoryId);
                }

                var products = await query.ToListAsync();
                return _mapper.Map<List<ProductDTO>>(products);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error filtering products: {ex.Message}");
                throw new FilterProductsException($"Error filtering products: {ex.Message}");
            }
        }
    }
}
