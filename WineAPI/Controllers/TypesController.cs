using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WineLib.Models;
using WineAPI.Repositories;

namespace WineAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypesController : ControllerCrud<WineType, TypeRepository>
    {
        public TypesController(TypeRepository repo) : base(repo)
        {
        }

        [HttpGet]
        [Route("simple")]
        public async Task<IActionResult> GetSimple()
        {
            return Ok(await repository.GetSimple());
        }
    }
}