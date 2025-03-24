using Infrastructure.Application.DtosForProductManagaments;
using Infrastructure.Application.Services.ProductManagmentServices.ProductSer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Authorize]
    [Route("api/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly ILogger<ProductsController> _logger;

        public ProductsController(IProductService productService, ILogger<ProductsController> logger)
        {
            _productService = productService;
            _logger = logger;
        }

        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetAllProducts()
        {
            try
            {
                var products = await _productService.GetAllProducts();
                return Ok(products);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while fetching all products.");
                return StatusCode(500, "An error occurred while retrieving products.");
            }
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<ProductDto>> GetProductById(Guid id)
        {
            try
            {
                var product = await _productService.GetProductById(id);
                if (product == null)
                {
                    _logger.LogWarning("Product with ID {ProductId} not found.", id);
                    return NotFound("Product not found.");
                }
                return Ok(product);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while retrieving product with ID {ProductId}.", id);
                return StatusCode(500, "An error occurred while retrieving the product.");
            }
        }

        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<ProductDto>>> SearchProductsByName([FromQuery] string name)
        {
            try
            {
                var products = await _productService.SearchProductByName(name);
                return Ok(products);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while searching for products with name: {ProductName}", name);
                return StatusCode(500, "An error occurred while searching for products.");
            }
        }

        [HttpPost("create")]
        public async Task<ActionResult<ProductDto>> CreateProduct([FromBody] CreateProductDto dto)
        {
            try
            {
                await _productService.AddProduct(dto);
                _logger.LogInformation("Product created successfully.");
                return StatusCode(201);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while creating product.");
                return StatusCode(500, "An error occurred while creating the product.");
            }
        }

        [HttpPut("update/{id:guid}")]
        public async Task<ActionResult> UpdateProduct(Guid id, [FromBody] UpdateProductDto dto)
        {
            if (id != dto.ProductId)
            {
                _logger.LogWarning("Product ID mismatch. Provided ID: {ProvidedId}, DTO ID: {DtoId}", id, dto.ProductId);
                return BadRequest("Product ID mismatch.");
            }

            try
            {
                await _productService.UpdateProduct(dto);
                _logger.LogInformation("Product with ID {ProductId} updated successfully.", id);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while updating product with ID {ProductId}.", id);
                return StatusCode(500, "An error occurred while updating the product.");
            }
        }

        [HttpDelete("delete/{id:guid}")]
        public async Task<ActionResult> DeleteProduct(Guid id)
        {
            try
            {
                await _productService.DeleteProduct(id);
                _logger.LogInformation("Product with ID {ProductId} deleted successfully.", id);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while deleting product with ID {ProductId}.", id);
                return StatusCode(500, "An error occurred while deleting the product.");
            }
        }
    }
}
