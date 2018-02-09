using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Generic_Repository;
using DataClasses;

namespace BusinessLayer.Repositories.Interfaces
{
    public interface ISupplierRepository : IGenericRepository<Supplier>
    {
        void AddSupplier(params Supplier[] suppliers);
        void UpdateSupplier(params Supplier[] suppliers);
        void RemoveSupplier(params Supplier[] suppliers);
        Supplier GetSupplierByID(int ID);
        IList<Supplier> GetSuppliersByCountryName(string countryName);
        IList<Supplier> GetAllSuppliers();
    }
}
