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
                .ToListAsync();
        }

        public async Task<Wine> GetFullDetails(int Id)
        {
            return await db.Set<Wine>()
                .Include(w => w.Producer)
                .Include(w => w.Type)
                .FirstOrDefaultAsync(w => w.Id == Id);
        }

        public override IQueryable<Wine> GetAll()
        {
            return db.Set<Wine>().AsNoTracking()
                .Include(w => w.Producer)
                .Include(w => w.Type);
        }

        public async Task<List<ListItem>> GetSimple()
        {
            return await db.Wines.Select(w => new ListItem
            {
                Name = w.Name,
                Detail = w.Year.ToString(),
                Id = w.Id
            }).ToListAsync();
        }
    }
}
