using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Generic_Repository;
using DataClasses;

namespace BusinessLayer.Repositories.Interfaces
{
    interface IProductRepository : IGenericRepository<Product>
    {
        Product GetProductByID(int ProductID);
        IList<Product> GetProductsBySupplierID(int SupplierID);
        IList<Product> GetProductsByCategoryID(int CategoryID);
        void AddProduct(params Product[] products);
        void UpdateProduct(params Product[] products);
        void RemoveProduct(params Product[] products);
    }
}
