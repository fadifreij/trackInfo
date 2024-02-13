using Microsoft.EntityFrameworkCore;
using SearchEngine.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchEngine.Models.Repositories
{
    public class EngineRepository :Repository<Engine>, IEngineRepository
    {
        private ApplicationDbContext _context;
        public EngineRepository(ApplicationDbContext context) : base(context)
        {
                _context = context;
        }

        public async Task<Engine> GetActiveEngine()
        {
            return await _context.Engine.Where(p => p.IsActive == true).FirstOrDefaultAsync();
        }

        public async Task SetEngineToActive(int engineId)
        {
            var engines =await _context.Engine.ToListAsync();
            foreach(var engine in engines)
            {
                if (engine.Id == engineId)
                    engine.IsActive = true;
                else
                    engine.IsActive = false;
            }
            
          

          
            await _context.SaveChangesAsync();
            
        }
    }
}
