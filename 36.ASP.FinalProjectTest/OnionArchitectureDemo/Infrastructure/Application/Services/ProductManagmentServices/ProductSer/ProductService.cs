using Domain.Models;
using Infrastructure.Application.DtosForProductManagaments;
using Infrastructure.Data.Repositories;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Application.Services.ProductManagmentServices.ProductSer
{
    public class ProductService : IProductService
    {
        private readonly IRepository<Product> _productRepository;
        private readonly IRepository<Category> _categoryRepository;
        private readonly ILogger<ProductService> _logger;

        public ProductService(
            IRepository<Product> productRepository,
            IRepository<Category> categoryRepository,
            ILogger<ProductService> logger)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
            _logger = logger;
        }

        public async Task<IEnumerable<ProductDto>> GetAllProducts()
        {
            try
            {
                _logger.LogInformation("Fetching all products...");
                IEnumerable<Product> products = await _productRepository.GetAll();

                List<ProductDto> productDtos = new List<ProductDto>();

                foreach (Product product in products)
                {
                    var category = await _categoryRepository.GetById(product.CategoryId);

                    var productDto = new ProductDto
                    {
                        ProductId = product.Id,
                        ProductName = product.ProductName,
                        Price = product.Price,
                        StockQuantity = product.StockQuantity,
                        Category = category != null ? new CategoryDto
                        {
                            CategoryId = category.Id,
                            CategoryName = category.CategoryName
                        } : null
                    };

                    productDtos.Add(productDto);
                }

                return productDtos;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while fetching all products.");
                throw;
            }
        }

        public async Task<ProductDto> GetProductById(Guid id)
        {
            try
            {
                _logger.LogInformation($"Fetching product with ID: {id}");
                var product = await _productRepository.GetById(id);

                if (product == null)
                {
                    _logger.LogWarning($"Product with ID {id} not found.");
                    return null;
                }

                var category = await _categoryRepository.GetById(product.CategoryId);

                return new ProductDto
                {
                    ProductId = product.Id,
                    ProductName = product.ProductName,
                    Price = product.Price,
                    StockQuantity = product.StockQuantity,
                    Category = category != null ? new CategoryDto
                    {
                        CategoryId = category.Id,
                        CategoryName = category.CategoryName
                    } : null
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while fetching product with ID: {id}");
                throw;
            }
        }


        public async Task AddProduct(CreateProductDto dto)
        {
            try
            {
                if (dto == null)
                {
                    _logger.LogWarning("Invalid product data received.");
                    throw new ArgumentNullException(nameof(dto), "Product data cannot be null.");
                }

                var product = new Product
                {
                    Id = Guid.NewGuid(),
                    ProductName = dto.ProductName,
                    Price = dto.Price,
                    StockQuantity = dto.StockQuantity,
                    CategoryId = dto.CategoryId
                };

                await _productRepository.Add(product);
                _logger.LogInformation($"Product {product.ProductName} added successfully.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while adding a new product.");
                throw;
            }
        }

        public async Task UpdateProduct(UpdateProductDto dto)
        {
            try
            {
                if (dto == null)
                {
                    _logger.LogWarning("Invalid product update data received.");
                    throw new ArgumentNullException(nameof(dto), "Product update data cannot be null.");
                }

                var product = await _productRepository.GetById(dto.ProductId);

                if (product == null)
                {
                    _logger.LogWarning($"Product with ID {dto.ProductId} not found for update.");
                    return;
                }

                product.ProductName = dto.ProductName;
                product.Price = dto.Price;
                product.StockQuantity = dto.StockQuantity;
                product.CategoryId = dto.CategoryId;

                await _productRepository.Update(product);
                _logger.LogInformation($"Product with ID {dto.ProductId} updated successfully.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while updating product with ID: {dto.ProductId}");
                throw;
            }
        }

        public async Task DeleteProduct(Guid id)
        {
            try
            {
                _logger.LogInformation($"Attempting to delete product with ID: {id}");
                var product = await _productRepository.GetById(id);

                if (product == null)
                {
                    _logger.LogWarning($"Product with ID {id} not found for deletion.");
                    return;
                }

                await _productRepository.Delete(product);
                _logger.LogInformation($"Product with ID {id} deleted successfully.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while deleting product with ID: {id}");
                throw;
            }
        }
    }
}
