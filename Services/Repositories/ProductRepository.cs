using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Repositories.Interfaces;
using Generic_Repository;
using DataClasses;
using System.Data.Entity;

namespace BusinessLayer.Repositories
{
    class ProductRepository : GenericDataRepository<Product, NorthwindModel>, IProductRepository
    {
        private IGenericRepository<Product> _productRepository;

        public ProductRepository(IGenericRepository<Product> ProductRepository)
        {
            _productRepository = ProductRepository;
        }

        public void AddProduct(params Product[] products)
        {
            _productRepository.Add(products);
        }

        public IList<Product> GetProductsByCategoryID(int CategoryID)
        {
            IList<Product> _productList;
            _productList = _productRepository.GetList(p => p.CategoryID == CategoryID, p => p.Category);
            return _productList;
        }

        public Product GetProductByID(int ProductID)
        {
            Product _product;
            _product = _productRepository.GetSingle(p => p.ProductID == ProductID, null);
            return _product;
        }

        public IList<Product> GetProductsBySupplierID(int SupplierID)
        {
            IList<Product> _productList;
            _productList = _productRepository.GetList(p => p.SupplierID == SupplierID, p => p.Category);
            return _productList;
        }

        public void RemoveProduct(params Product[] products)
        {
            _productRepository.Remove(products);
        }

        public void UpdateProduct(params Product[] products)
        {
            _productRepository.Update(products);
        }
    }
}