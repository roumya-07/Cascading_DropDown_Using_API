using Cascading_DropDown_Using_API.Models;
using Cascading_DropDown_Using_API.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cascading_DropDown_Using_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : Controller
    {
        private readonly IProdService _prodservice;
    public CategoryController(IProdService prodservice)
    {
        _prodservice = prodservice;
    }
        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetAllCategory()
        {
            return await _prodservice.GetAllCategoryS();
        }
    }
}
