using Domain.Models;
using Infrastructure.Application.DtosForProductManagaments;
using Infrastructure.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Application.Services.ProductManagmentServices.ProductSer
{
    public class ProductService : IProductService
    {
        private readonly IRepository<Product> _productRepository;
        private readonly IRepository<Category> _categoryRepository;

        public ProductService(IRepository<Product> productRepository, IRepository<Category> categoryRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }

        public async Task<IEnumerable<ProductDto>> GetAllProducts()
        {
            IEnumerable<Product> products = await _productRepository.GetAll();
            List<ProductDto> productDtos = new List<ProductDto>();

            foreach (var product in products)
            {
                var category = await _categoryRepository.GetById(product.CategoryId);
                var productDto = new ProductDto
                {
                    ProductId = product.Id,
                    ProductName = product.ProductName,
                    Price = product.Price,
                    StockQuantity = product.StockQuantity
                };

                if (category != null)
                {
                    var categoryDto = new CategoryDto
                    {
                        CategoryId = category.Id,
                        CategoryName = category.CategoryName
                    };
                    productDto.Category = categoryDto;
                }

                productDtos.Add(productDto);
            }

            return productDtos;
        }

        public async Task<ProductDto> GetProductById(Guid id)
        {
            Product product = await _productRepository.GetById(id);
            if (product == null)
            {
                return null;
            }

            Category category = await _categoryRepository.GetById(product.CategoryId);
            ProductDto productDto = new ProductDto
            {
                ProductId = product.Id,
                ProductName = product.ProductName,
                Price = product.Price,
                StockQuantity = product.StockQuantity
            };

            if (category != null)
            {
                var categoryDto = new CategoryDto
                {
                    CategoryId = category.Id,
                    CategoryName = category.CategoryName
                };
                productDto.Category = categoryDto;
            }

            return productDto;
        }

        public async Task AddProduct(CreateProductDto dto)
        {
            Product product = new Product
            {
                Id = Guid.NewGuid(),
                ProductName = dto.ProductName,
                Price = dto.Price,
                StockQuantity = dto.StockQuantity,
                CategoryId = dto.CategoryId
            };

            await _productRepository.Add(product);
        }

        public async Task UpdateProduct(UpdateProductDto dto)
        {
            Product product = await _productRepository.GetById(dto.ProductId);
            if (product == null)
            {
                return;
            }

            product.ProductName = dto.ProductName;
            product.Price = dto.Price;
            product.StockQuantity = dto.StockQuantity;
            product.CategoryId = dto.CategoryId;

            await _productRepository.Update(product);
        }

        public async Task DeleteProduct(Guid id)
        {
            Product product = await _productRepository.GetById(id);
            if (product == null)
            {
                return;
            }

            await _productRepository.Delete(product);
        }
    }
}
