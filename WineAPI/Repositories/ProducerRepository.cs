using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WineAPI.Models;
using WineLib.Models;

namespace WineAPI.Repositories
{
    public class ProducerRepository : Repository<Producer>
    {
        public ProducerRepository(WineServiceContext context) : base(context)
        {
        }
    }
}
