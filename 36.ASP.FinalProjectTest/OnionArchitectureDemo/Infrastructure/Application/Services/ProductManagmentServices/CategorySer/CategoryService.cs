using Domain.Models;
using Infrastructure.Application.DtosForProductManagaments;
using Infrastructure.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Application.Services.ProductManagmentServices.CategorySer
{
    public class CategoryService : ICategoryService
    {
        private readonly IRepository<Category> _categoryRepository;

        public CategoryService(IRepository<Category> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<IEnumerable<CategoryDto>> GetAllCategories()
        {
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

        public async Task<CategoryDto> GetCategoryById(Guid id)
        {
            var category = await _categoryRepository.GetById(id);
            if (category == null)
            {
                return null;
            }

            return new CategoryDto
            {
                CategoryId = category.Id,
                CategoryName = category.CategoryName
            };
        }

        public async Task AddCategory(CreateCategoryDto dto)
        {
            var category = new Category
            {
                Id = Guid.NewGuid(),
                CategoryName = dto.CategoryName
            };

            await _categoryRepository.Add(category);
        }

        public async Task UpdateCategory(UpdateCategoryDto dto)
        {
            var category = await _categoryRepository.GetById(dto.CategoryId);
            if (category == null)
            {
                return;
            }

            category.CategoryName = dto.CategoryName;
            await _categoryRepository.Update(category);
        }

        public async Task DeleteCategory(Guid id)
        {
            var category = await _categoryRepository.GetById(id);
            if (category == null)
            {
                return;
            }

            await _categoryRepository.Delete(category);
        }
    }
}
