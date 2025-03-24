using Domain.Models;
using Infrastructure.Application.DtosForProductManagaments;
using Infrastructure.Application.Services.ProductManagmentServices.CategorySer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Authorize]
    [Route("api/categories")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly ILogger<CategoriesController> _logger;

        public CategoriesController(ICategoryService categoryService, ILogger<CategoriesController> logger)
        {
            _categoryService = categoryService;
            _logger = logger;
        }

        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<CategoryDto>>> GetAllCategories()
        {
            try
            {
                var categories = await _categoryService.GetAllCategories();
                return Ok(categories);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while getting all categories.");
                return StatusCode(500, "An error occurred while fetching categories.");
            }
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<CategoryDto>> GetCategoryById(Guid id)
        {
            try
            {
                var category = await _categoryService.GetCategoryById(id);
                if (category == null)
                {
                    _logger.LogWarning("Category with ID {CategoryId} not found.", id);
                    return NotFound("Category not found.");
                }
                return Ok(category);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while getting category with ID {CategoryId}.", id);
                return StatusCode(500, "An error occurred while fetching the category.");
            }
        }

        [HttpPost("create")]
        public async Task<ActionResult> CreateCategory([FromBody] CreateCategoryDto dto)
        {
            try
            {
                await _categoryService.AddCategory(dto);
                _logger.LogInformation("Category created successfully.");

                return StatusCode(201);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while creating category.");
                return StatusCode(500, "An error occurred while creating the category.");
            }
        }


        [HttpPut("update/{id:guid}")]
        public async Task<ActionResult> UpdateCategory(Guid id, [FromBody] UpdateCategoryDto dto)
        {
            if (id != dto.CategoryId)
            {
                return BadRequest("Category ID mismatch.");
            }

            try
            {
                await _categoryService.UpdateCategory(dto);
                _logger.LogInformation("Category with ID {CategoryId} updated successfully.", id);

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while updating category with ID {CategoryId}.", id);
                return StatusCode(500, "An error occurred while updating the category.");
            }
        }

        [HttpDelete("delete/{id:guid}")]
        public async Task<ActionResult> DeleteCategory(Guid id)
        {
            try
            {
                await _categoryService.DeleteCategory(id);
                _logger.LogInformation("Category with ID {CategoryId} deleted successfully.", id);

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while deleting category with ID {CategoryId}.", id);
                return StatusCode(500, "An error occurred while deleting the category.");
            }
        }
    }
}
