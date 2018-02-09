using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Repositories.Interfaces;
using Generic_Repository;
using DataClasses;

namespace BusinessLayer.Repositories
{
    public class SupplierRepository : GenericDataRepository<Supplier, NorthwindModel>, ISupplierRepository
    {
        private IGenericRepository<Supplier> _supplierRepository;

        public SupplierRepository(IGenericRepository<Supplier> SupplierRepository)
        {
            _supplierRepository = SupplierRepository;
        }
        public void AddSupplier(params Supplier[] suppliers)
        {
            _supplierRepository.Add(suppliers);
        }

        public IList<Supplier> GetAllSuppliers()
        {
            return _supplierRepository.GetAll(s => s.Country);
        }

        public Supplier GetSupplierByID(int ID)
        {
            return _supplierRepository.GetSingle(s => s.SupplierID == ID, s => s.Country);
        }

        public IList<Supplier> GetSuppliersByCountryName(string countryName)
        {
            return _supplierRepository.GetList(s => s.Country.Equals(countryName), s => s.City);
        }

        public void RemoveSupplier(params Supplier[] suppliers)
        {
            _supplierRepository.Remove(suppliers);
        }

        public void UpdateSupplier(params Supplier[] suppliers)
        {
            _supplierRepository.Update(suppliers);
        }
    }
}
