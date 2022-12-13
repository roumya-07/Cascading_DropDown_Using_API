using CascadingMvcUsingCrudDapper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CascadingMvcUsingCrudDapper.Reprository
{
    public interface IProdReprository
    {
        public Task<List<Product>> GetAllProduct();
        public Task<List<Product>> GetAllCategory();
        public Task<List<Product>> GetAllSubCategory(int catid);
        public Task<List<Product>> GetAllSubCategory();
        public Task<Product> GetProductById(int pid);
        public Task<int> Insert(Product pr);
        public Task<int> Update(Product pr);
        public Task<int> Delete(int pid);
    }
}
