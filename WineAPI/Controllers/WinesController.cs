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
    }
}