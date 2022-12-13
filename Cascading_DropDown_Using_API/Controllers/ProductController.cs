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
    public class ProductController : Controller
    {
        private readonly IProdService _prodservice;
        public ProductController(IProdService prodservice)
        {
            _prodservice = prodservice;
        }
        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetAllProduct()
        {
            return await _prodservice.GetAllProductS();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProductById(int id)
        {
            var prod = await _prodservice.GetProductByIdS(id);

            if (prod == null)
            {
                return NotFound();
            }
            return prod;
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<Product>> InsertUpdateProduct(int id, Product prod)
        {
            if (id != prod.pid)
            {
                return BadRequest();
            }
            try
            {
                await _prodservice.InsertS(prod);

                return CreatedAtAction("GetAllProduct", new { id = prod.pid }, prod);
            }

            catch (Exception ex)
            {
                if (GetProductById(id) == null)
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Product>> DeleteProduct(int id)
        {
            var prod = await _prodservice.GetProductByIdS(id);
            if (prod == null)
            {
                return NotFound();
            }
            await _prodservice.DeleteS(id);
            return prod;
        }
    }
}
