using Cascading_DropDown_Using_API.Models;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Cascading_DropDown_Using_API.Reprository
{
    public class ProdReprository: BaseReprository, IProdReprository
    {
        public ProdReprository(IConfiguration configuration) : base(configuration)
        {
        }
        public async Task<List<Product>> GetAllProduct()
        {
            var cn = CreateConnection();
            if (cn.State == ConnectionState.Closed) cn.Open();
            DynamicParameters param = new DynamicParameters();
            param.Add("@action", "FillTable");
            var lstprod = cn.Query<Product>("sp_psc", param, commandType: CommandType.StoredProcedure).ToList();
            return lstprod;
        }
        public async Task<Product> GetProductById(int pid)
        {
            var cn = CreateConnection();
            if (cn.State == ConnectionState.Closed) cn.Open();
            DynamicParameters param = new DynamicParameters();
            param.Add("@pid", pid);
            param.Add("@action", "SelectOne");
            var lstprod = cn.Query<Product>("sp_psc", param, commandType: CommandType.StoredProcedure).FirstOrDefault();
            cn.Close();
            return lstprod;
        }
        public async Task<int> Insert(Product pr)
        {
            var cn = CreateConnection();
            if (cn.State == ConnectionState.Closed) cn.Open();
            DynamicParameters param = new DynamicParameters();
            param.Add("@pname", pr.pname);
            param.Add("@catid", pr.catid);
            param.Add("@subcatid", pr.subcatid);
            param.Add("@price", pr.price);
            param.Add("@pqty", pr.pqty);
            param.Add("@action", "Insert");
            int x = cn.Execute("sp_psc", param, commandType: CommandType.StoredProcedure);
            cn.Close();
            return x;
        }
        public async Task<int> Update(Product pr)
        {
            var cn = CreateConnection();
            if (cn.State == ConnectionState.Closed) cn.Open();
            DynamicParameters param = new DynamicParameters();
            param.Add("@pid", pr.pid);
            param.Add("@pname", pr.pname);
            param.Add("@catid", pr.catid);
            param.Add("@subcatid", pr.subcatid);
            param.Add("@price", pr.price);
            param.Add("@pqty", pr.pqty);
            param.Add("@action", "Update");
            int x = cn.Execute("sp_psc", param, commandType: CommandType.StoredProcedure);
            cn.Close();
            return x;
        }
        public async Task<int> Delete(int pid)
        {
            var cn = CreateConnection();
            if (cn.State == ConnectionState.Closed) cn.Open();
            DynamicParameters param = new DynamicParameters();
            param.Add("@pid", pid);
            param.Add("@action", "Delete");
            int x = cn.Execute("sp_psc", param, commandType: CommandType.StoredProcedure);
            cn.Close();
            return x;
        }

        public async Task<List<Category>> GetAllCategory()
        {
            var cn = CreateConnection();
            if (cn.State == ConnectionState.Closed) cn.Open();
            DynamicParameters param = new DynamicParameters();
            param.Add("@action", "Fillcat");
            var lstprod = cn.Query<Category>("sp_psc", param, commandType: CommandType.StoredProcedure).ToList();
            return lstprod;
        }

        public async Task<List<SubCategory>> GetAllSubCategory(int catid)
        {
            var cn = CreateConnection();
            if (cn.State == ConnectionState.Closed) cn.Open();
            DynamicParameters param = new DynamicParameters();
            param.Add("@catid", catid);
            param.Add("@action", "Fillsubcat");
            var lstprod = cn.Query<SubCategory>("sp_psc", param, commandType: CommandType.StoredProcedure).ToList();
            return lstprod;
        }
        public async Task<List<SubCategory>> GetAllSubCategory()
        {
            var cn = CreateConnection();
            if (cn.State == ConnectionState.Closed) cn.Open();
            DynamicParameters param = new DynamicParameters();
            param.Add("@action", "Fillsubcatall");
            var lstprod = cn.Query<SubCategory>("sp_psc", param, commandType: CommandType.StoredProcedure).ToList();
            return lstprod;
        }
    }
}
