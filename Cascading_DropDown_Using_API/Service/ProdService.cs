using Cascading_DropDown_Using_API.Models;
using Cascading_DropDown_Using_API.Reprository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cascading_DropDown_Using_API.Service
{
    public class ProdService : IProdService
    {
        private readonly IProdReprository _prodrepo;
        public ProdService(IProdReprository prodrepo)
        {
            _prodrepo = prodrepo;
        }
        public async Task<int> DeleteS(int pid)
        {
            return await _prodrepo.Delete(pid);
        }

        public async Task<List<Category>> GetAllCategoryS()
        {
            return await _prodrepo.GetAllCategory();
        }

        public async Task<List<Product>> GetAllProductS()
        {
            return await _prodrepo.GetAllProduct();
        }

        public async Task<List<SubCategory>> GetAllSubCategoryS(int catid)
        {
            return await _prodrepo.GetAllSubCategory(catid);
        }
        public async Task<List<SubCategory>> GetAllSubCategoryS()
        {
            return await _prodrepo.GetAllSubCategory();
        }

        public async Task<Product> GetProductByIdS(int pid)
        {
            return await _prodrepo.GetProductById(pid);
        }

        public async Task<int> InsertS(Product pr)
        {
            return await _prodrepo.Insert(pr);
        }

        public async Task<int> UpdateS(Product pr)
        {
            return await _prodrepo.Update(pr);
        }
    }
}
