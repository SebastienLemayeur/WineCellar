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
    public class WinesController : ControllerCrud<Wine, WineRepository>
    {
        public WinesController(WineRepository repo) : base(repo)
        {
        }

        [HttpGet]
        public override async Task<IActionResult> Get()
        {
            return Ok(await repository.GetFullDetails());
        }

        [HttpGet("{id}")]
        public override async Task<IActionResult> Get(int id)
        {
            return Ok(await repository.GetFullDetails(id));
        }

        [HttpGet]
        [Route("simple")]
        public async Task<IActionResult> GetSimple()
        {
            return Ok(await repository.GetSimple());
        }
    }
}