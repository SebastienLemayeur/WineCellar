using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WineAPI.Models;

namespace WineAPI.Repositories
{
    public class TypeRepository : Repository<WineType>
    {
        public TypeRepository(WineServiceContext context) : base(context)
        {
        }
    }
}
