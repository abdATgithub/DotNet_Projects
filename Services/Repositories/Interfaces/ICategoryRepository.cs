using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Generic_Repository;
using DataClasses;

namespace BusinessLayer.Repositories.Interfaces
{
    public interface ICategoryRepository: IGenericRepository<Category>
    {
        void AddCategory(params Category[] categories);
        void UpdateCategory(params Category[] categories);
        void RemoveCategory(params Category[] categories);
        IList<Category> GetAllCategories();
    }
}
