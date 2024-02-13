using SearchEngine.Models.Models;

namespace SearchEngine.Models
{
    public class SearchViewModel
    {
        public string Url { get; set; }
        public string Keywords { get; set; }

        public IEnumerable<SearchInfo> searchInfoList { get; set; }
    }
}
