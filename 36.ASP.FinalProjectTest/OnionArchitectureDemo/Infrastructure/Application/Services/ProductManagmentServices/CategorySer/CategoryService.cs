using Domain.Models;
using Infrastructure.Application.DtosForProductManagaments;
using Infrastructure.Data.Repositories;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Application.Services.ProductManagmentServices.CategorySer
{
    public class CategoryService : ICategoryService
    {
        private readonly IRepository<Category> _categoryRepository;
        private readonly ILogger<CategoryService> _logger;

        public CategoryService(IRepository<Category> categoryRepository, ILogger<CategoryService> logger)
        {
            _categoryRepository = categoryRepository;
            _logger = logger;
        }

        public async Task<IEnumerable<CategoryDto>> GetAllCategories()
        {
            try
            {
                _logger.LogInformation("Fetching all categories.");

                IEnumerable<Category> categories = await _categoryRepository.GetAll();
                List<CategoryDto> categoryDtos = new List<CategoryDto>();

                foreach (var category in categories)
                {
                    var categoryDto = new CategoryDto
                    {
                        CategoryId = category.Id,
                        CategoryName = category.CategoryName
                    };
                    categoryDtos.Add(categoryDto);
                }

                return categoryDtos;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error fetching categories: {ex.Message}");
                throw;
            }
        }

        public async Task<CategoryDto> GetCategoryById(Guid id)
        {
            try
            {
                _logger.LogInformation($"Fetching category with ID: {id}");

                var category = await _categoryRepository.GetById(id);
                if (category == null)
                {
                    _logger.LogWarning($"Category with ID {id} not found.");
                    return null;
                }

                return new CategoryDto
                {
                    CategoryId = category.Id,
                    CategoryName = category.CategoryName
                };
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error fetching category by ID {id}: {ex.Message}");
                throw;
            }
        }

        public async Task AddCategory(CreateCategoryDto dto)
        {
            try
            {
                _logger.LogInformation($"Adding new category: {dto.CategoryName}");

                var category = new Category
                {
                    Id = Guid.NewGuid(),
                    CategoryName = dto.CategoryName
                };

                await _categoryRepository.Add(category);
                _logger.LogInformation("Category added successfully.");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error adding category: {ex.Message}");
                throw;
            }
        }

        public async Task UpdateCategory(UpdateCategoryDto dto)
        {
            try
            {
                _logger.LogInformation($"Updating category with ID: {dto.CategoryId}");

                var category = await _categoryRepository.GetById(dto.CategoryId);
                if (category == null)
                {
                    _logger.LogWarning($"Category with ID {dto.CategoryId} not found.");
                    return;
                }

                category.CategoryName = dto.CategoryName;
                await _categoryRepository.Update(category);
                _logger.LogInformation("Category updated successfully.");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error updating category with ID {dto.CategoryId}: {ex.Message}");
                throw;
            }
        }

        public async Task DeleteCategory(Guid id)
        {
            try
            {
                _logger.LogInformation($"Deleting category with ID: {id}");

                var category = await _categoryRepository.GetById(id);
                if (category == null)
                {
                    _logger.LogWarning($"Category with ID {id} not found.");
                    return;
                }

                await _categoryRepository.Delete(category);
                _logger.LogInformation("Category deleted successfully.");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error deleting category with ID {id}: {ex.Message}");
                throw;
            }
        }
    }
}
