using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WineAPI.Models;
using WineAPI.Repositories;

namespace WineAPI.Controllers
{
    public class ProducersController : ControllerCrud<Producer, ProducerRepository>
    {
        public ProducersController(ProducerRepository repo) : base(repo)
        {
        }
    }
}