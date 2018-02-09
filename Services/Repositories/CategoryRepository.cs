using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataClasses;
using Generic_Repository;
using BusinessLayer.Repositories.Interfaces;

namespace BusinessLayer.Repositories
{
    class CategoryRepository : GenericDataRepository<Category, NorthwindModel>, ICategoryRepository
    {
        private IGenericRepository<Category> _categoryRepository;

        public CategoryRepository(IGenericRepository<Category> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public void AddCategory(params Category[] categories)
        {
            _categoryRepository.Add(categories);
        }

        public IList<Category> GetAllCategories()
        {
            return _categoryRepository.GetAll(c => c.CategoryName);
        }

        public void RemoveCategory(params Category[] categories)
        {
            _categoryRepository.Remove(categories);
        }

        public void UpdateCategory(params Category[] categories)
        {
            _categoryRepository.Update(categories);
        }
    }
}
