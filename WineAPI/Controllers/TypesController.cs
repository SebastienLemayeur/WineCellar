using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WineAPI.Models;
using WineAPI.Repositories;

namespace WineAPI.Controllers
{
    public class TypesController : ControllerCrud<WineType, TypeRepository>
    {
        public TypesController(TypeRepository repo) : base(repo)
        {
        }
    }
}