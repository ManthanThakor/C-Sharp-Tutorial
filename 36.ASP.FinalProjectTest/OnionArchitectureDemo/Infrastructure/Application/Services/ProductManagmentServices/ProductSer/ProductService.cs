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
            var products = await _productRepository.GetAll();
            List<ProductDto> productDtos = new List<ProductDto>();

            foreach (var product in products)
            {
                var category = await _categoryRepository.GetById(product.CategoryId);
                var categoryDto = new CategoryDto();

                if (category != null)
                {
                    categoryDto.CategoryId = category.Id;
                    categoryDto.CategoryName = category.CategoryName;
                }
                else
                {
                    categoryDto = null;
                }

                var productDto = new ProductDto
                {
                    ProductId = product.Id,
                    ProductName = product.ProductName,
                    Price = product.Price,
                    StockQuantity = product.StockQuantity,
                    Category = categoryDto
                };

                productDtos.Add(productDto);
            }

            return productDtos;
        }

        public async Task<ProductDto> GetProductById(Guid id)
        {
            var product = await _productRepository.GetById(id);
            if (product == null)
            {
                return null;
            }

            var category = await _categoryRepository.GetById(product.CategoryId);

            CategoryDto categoryDto = null;

            if (category != null)
            {
                categoryDto = new CategoryDto
                {
                    CategoryId = category.Id,
                    CategoryName = category.CategoryName
                };
            }

            var productDto = new ProductDto
            {
                ProductId = product.Id,
                ProductName = product.ProductName,
                Price = product.Price,
                StockQuantity = product.StockQuantity,
                Category = categoryDto
            };

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
        public async Task<IEnumerable<ProductDto>> SearchProductByName(string productName)
        {
            if (string.IsNullOrWhiteSpace(productName))
            {
                return new List<ProductDto>();
            }

            var products = await _productRepository.GetAll();
            List<ProductDto> filteredProducts = new List<ProductDto>();

            foreach (var product in products)
            {
                if (product.ProductName.ToLower().Contains(productName.ToLower()))
                {
                    var category = await _categoryRepository.GetById(product.CategoryId);

                    CategoryDto categoryDto = null;

                    if (category != null)
                    {
                        categoryDto = new CategoryDto
                        {
                            CategoryId = category.Id,
                            CategoryName = category.CategoryName
                        };
                    }

                    var productDto = new ProductDto
                    {
                        ProductId = product.Id,
                        ProductName = product.ProductName,
                        Price = product.Price,
                        StockQuantity = product.StockQuantity,
                        Category = categoryDto
                    };

                    filteredProducts.Add(productDto);
                }
            }
            return filteredProducts;
        }

    }
}
