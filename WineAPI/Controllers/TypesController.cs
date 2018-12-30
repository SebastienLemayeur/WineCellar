using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WineAPI.Controllers
{
    public class TypesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}