﻿using Cascading_DropDown_Using_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cascading_DropDown_Using_API.Service
{
    public interface IProdService
    {
        public Task<List<Product>> GetAllProductS();
        public Task<List<Product>> GetAllCategoryS();
        public Task<List<Product>> GetAllSubCategoryS(int catid);
        public Task<List<Product>> GetAllSubCategoryS();
        public Task<Product> GetProductByIdS(int pid);
        public Task<int> InsertS(Product pr);
        public Task<int> UpdateS(Product pr);
        public Task<int> DeleteS(int pid);
    }
}