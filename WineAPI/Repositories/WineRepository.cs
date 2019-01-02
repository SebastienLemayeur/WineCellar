using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WineAPI.Models;
using WineLib.Models;
using WineLib.DTO;

namespace WineAPI.Repositories
{
    public class WineRepository :Repository<Wine>
    {
        public WineRepository(WineServiceContext context) : base(context)
        {
        }

        public async Task<List<Wine>> GetFullDetails()
        {
            return await GetAll()
                .Include(w => w.Producer)
                .Include(w => w.Type)
                .ToListAsync();
        }

        public async Task<List<WineSimple>> GetSimple()
        {
            return await db.Wines.Select(w => new WineSimple
            {
                Name = w.Name,
                Year = w.Year,
                Id = w.Id
            }).ToListAsync();
        }
    }
}
