using SearchEngine.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchEngine.Services.SearchService
{
    public interface ISearchService
    {
        Task<IEnumerable<SearchInfo>> GetHistory();

        Task<SearchInfo> Search(string targetSearch, string keyword);
    }
}
