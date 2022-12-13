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
    public class SubCategoryController : Controller
    {
        private readonly IProdService _prodservice;
        public SubCategoryController(IProdService prodservice)
        {
            _prodservice = prodservice;
        }
        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetAllSubCategory()
        {
            return await _prodservice.GetAllSubCategoryS();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<List<Product>>> GetAllSubCategory(int id)
        {
            return await _prodservice.GetAllSubCategoryS(id);
        }
    }
    
}
