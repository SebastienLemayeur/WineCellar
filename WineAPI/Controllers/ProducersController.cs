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
    public class ProducersController : ControllerCrud<Producer, ProducerRepository>
    {
        public ProducersController(ProducerRepository repo) : base(repo)
        {
        }
    }
}