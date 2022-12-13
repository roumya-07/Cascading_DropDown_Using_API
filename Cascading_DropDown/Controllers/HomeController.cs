using Cascading_DropDown.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Cascading_DropDown.Controllers
{
    public class HomeController : Controller
    {
        Uri baseAdd = new Uri("http://localhost:44159/api");

        HttpClient client;
        public HomeController()
        {
            client = new HttpClient();
            client.BaseAddress = baseAdd;
        }
        public IActionResult Index()
        {
            List<Product> lst = new List<Product>();
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/Product/").Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                lst = JsonConvert.DeserializeObject<List<Product>>(data);
            }
            return View(lst);
        }

        //public async Task<List<Category>> GetCategory()
        //{
        //    List<Category> prods = new List<Category>();
        //    HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/Category").Result;

        //    if (response.IsSuccessStatusCode)
        //    {
        //        string data = response.Content.ReadAsStringAsync().Result;

        //        prods = JsonConvert.DeserializeObject<List<Category>>(data);
        //        prods.Insert(0, new Category { catid = 0, catname = "Select One" });
        //    }
        //    return prods;
        //}

        public int Delete(int pid)
        {
            Product productlist = new Product();
            HttpResponseMessage response = client.DeleteAsync(client.BaseAddress + "/Product/" + pid).Result;
            if (response.IsSuccessStatusCode)
            {
                return 1;

            }
            return 0;
        }
    }
}
