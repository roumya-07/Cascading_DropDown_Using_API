using Cascading_DropDown.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
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
    }
}
