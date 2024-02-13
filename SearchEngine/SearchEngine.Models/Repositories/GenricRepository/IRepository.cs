using SearchEngine.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchEngine.Models.Repositories
{
    public interface IRepository<TEntity> where TEntity : Base 
    {
        Task AddAsync(TEntity entity);
        Task<IEnumerable<TEntity>> GetAllAsync();
    }
}
