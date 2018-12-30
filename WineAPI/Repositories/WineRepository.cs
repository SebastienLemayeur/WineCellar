using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WineAPI.Models;
using WineLib.Models;

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
    }
}
