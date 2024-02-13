using SearchEngine.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchEngine.Models.Repositories
{
    public interface IEngineRepository : IRepository<Engine>
    {
        Task<Engine> GetActiveEngine();

        Task SetEngineToActive(int  engineId);
    }
}
