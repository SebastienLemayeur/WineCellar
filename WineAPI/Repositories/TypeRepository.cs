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
    public class TypeRepository : Repository<WineType>
    {
        public TypeRepository(WineServiceContext context) : base(context)
        {
        }

        public async Task<List<ListItem>> GetSimple()
        {
            return await db.Types.Select(t => new ListItem
            {
                Name = t.Type,
                Detail = String.Empty,
                Id = t.Id
            }).ToListAsync();
        }
    }
}
