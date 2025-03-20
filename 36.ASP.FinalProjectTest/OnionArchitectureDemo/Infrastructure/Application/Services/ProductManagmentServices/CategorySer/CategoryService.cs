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

                IEnumerable<Category> categories = await _categoryRepository.GetAllAsync();
                List<CategoryDto> categoryDtos = new List<CategoryDto>();

                foreach (var category in categories)
                {
                    categoryDtos.Add(new CategoryDto
                    {
                        CategoryId = category.Id,
                        CategoryName = category.CategoryName
                    });
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
                if (id == Guid.Empty)
                    throw new ArgumentException("Invalid category ID.");

                _logger.LogInformation($"Fetching category with ID: {id}");

                var category = await _categoryRepository.GetByIdAsync(id);
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
                if (string.IsNullOrWhiteSpace(dto.CategoryName))
                    throw new ArgumentException("Category name cannot be empty.");

                _logger.LogInformation($"Adding new category: {dto.CategoryName}");

                var category = new Category
                {
                    Id = Guid.NewGuid(),
                    CategoryName = dto.CategoryName
                };

                await _categoryRepository.AddAsync(category);
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
                if (dto.CategoryId == Guid.Empty)
                    throw new ArgumentException("Invalid category ID.");

                if (string.IsNullOrWhiteSpace(dto.CategoryName))
                    throw new ArgumentException("Category name cannot be empty.");

                _logger.LogInformation($"Updating category with ID: {dto.CategoryId}");

                var category = await _categoryRepository.GetByIdAsync(dto.CategoryId);
                if (category == null)
                {
                    _logger.LogWarning($"Category with ID {dto.CategoryId} not found.");
                    return;
                }

                category.CategoryName = dto.CategoryName;
                await _categoryRepository.UpdateAsync(category);
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
                if (id == Guid.Empty)
                    throw new ArgumentException("Invalid category ID.");

                _logger.LogInformation($"Deleting category with ID: {id}");

                var category = await _categoryRepository.GetByIdAsync(id);
                if (category == null)
                {
                    _logger.LogWarning($"Category with ID {id} not found.");
                    return;
                }

                await _categoryRepository.DeleteAsync(category);
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
