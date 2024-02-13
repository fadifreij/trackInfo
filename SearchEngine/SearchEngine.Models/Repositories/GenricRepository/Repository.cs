using Microsoft.EntityFrameworkCore;
using SearchEngine.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchEngine.Models.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : Base
    {
        private readonly ApplicationDbContext _context;
        public Repository(ApplicationDbContext context)
        {

            _context = context;

        }
        public async Task AddAsync(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);
            _context.SaveChanges();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _context.Set<TEntity>().ToListAsync();
        }
    }
}
