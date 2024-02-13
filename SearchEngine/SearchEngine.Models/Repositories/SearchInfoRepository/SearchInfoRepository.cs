using Microsoft.EntityFrameworkCore;
using SearchEngine.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchEngine.Models.Repositories
{
    public class SearchInfoRepository : Repository<SearchInfo>, ISearchInfoRepository
    {
        private readonly ApplicationDbContext _context;
        public SearchInfoRepository(ApplicationDbContext context) : base(context)
        {
          _context = context;
        }


        public async Task<IEnumerable<SearchInfo>> GetAllAsync()
        {
            return await _context.SearchInfo.Include(p=>p.Engine).OrderByDescending(p=>p.SearchDate).ToListAsync();
        }
    }
}
