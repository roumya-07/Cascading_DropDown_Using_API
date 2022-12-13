using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cascading_DropDown_Using_API.Controllers
{
    public class SubCategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
