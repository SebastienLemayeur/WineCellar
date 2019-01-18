using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WineAPI.Models;
using WineLib.DTO;
using WineLib.Models;

namespace WineAPI.Repositories
{
    public class ProducerRepository : Repository<Producer>
    {
        public ProducerRepository(WineServiceContext context) : base(context)
        {

        }

        public async Task<List<ListItem>> GetSimple()
        {
            return await db.Producers.Select(p => new ListItem
            {
                Name = p.Name,
                Detail = p.Country,
                Id = p.Id
            }).ToListAsync();
        }
    }
}
