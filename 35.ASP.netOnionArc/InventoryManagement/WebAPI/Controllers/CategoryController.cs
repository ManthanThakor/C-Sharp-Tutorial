using Domain.ViewModels;
using InfrastructureLayer.Service.CustomServices.CategoryServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/categories")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<CategoryViewModel>>> GetAllCategories()
        {
            try
            {
                var categories = await _categoryService.GetAll();
                return Ok(categories);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<CategoryViewModel>> GetCategoryById(Guid id)
        {
            try
            {
                var category = await _categoryService.Get(id);
                if (category == null)
                    return NotFound("Category not found.");

                return Ok(category);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpPost("create")]
        public async Task<ActionResult> CreateCategory([FromBody] CategoryInsertModel model)
        {
            try
            {
                var result = await _categoryService.Insert(model);
                if (!result)
                    return BadRequest("Failed to create category.");

                return Ok("Category created successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpPut("update")]
        public async Task<ActionResult> UpdateCategory([FromBody] CategoryUpdateModel model)
        {
            try
            {
                var result = await _categoryService.Update(model);
                if (!result)
                    return BadRequest("Failed to update category.");

                return Ok("Category updated successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpDelete("delete/{id:guid}")]
        public async Task<ActionResult> DeleteCategory(Guid id)
        {
            try
            {
                var result = await _categoryService.Delete(id);
                if (!result)
                    return NotFound("Category not found or deletion failed.");

                return Ok("Category deleted successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }
    }
}
