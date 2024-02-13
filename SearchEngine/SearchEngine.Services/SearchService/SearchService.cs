using Microsoft.Identity.Client;
using SearchEngine.Models.Models;
using SearchEngine.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SearchEngine.Services.SearchService
{
    public class SearchService : ISearchService
    {  
        private readonly IEngineRepository _engineRepository;
        private readonly ISearchInfoRepository _searchService;
        private const int numOfResult = 100;
        private string EngineUrl = "";
        private string EngineParameter = "";
        public SearchService(IEngineRepository engineRepository, ISearchInfoRepository searchInfoRepository)
        {
            _engineRepository = engineRepository;
            _searchService = searchInfoRepository;
        }

        public async Task<IEnumerable<SearchInfo>> GetHistory()
        {
            return await _searchService.GetAllAsync();
        }

        public async Task<SearchInfo> Search(string targetSearch, string keywords)
        {
            if (keywords.Length == 0)
                throw new ArgumentException("Invalid keywords");

            if (string.IsNullOrEmpty(targetSearch))
                throw new ArgumentOutOfRangeException("Invalid target search");

            var activeEngine = await GetActiveEngine(keywords);

            var httpResponse = await SendRequest(EngineParameter);
            var results = GetMatchedResult(httpResponse, targetSearch);

            var searchInfoResult = new SearchInfo
            {
                Url = EngineUrl,
                Keywords = keywords,
                Rank = string.Join(", ", results),
                Occurance = results.Count(),
                SearchDate = DateTime.Now,
                EngineId = activeEngine.Id

            };

           await _searchService.AddAsync(searchInfoResult);
            return searchInfoResult;
        }


        private async Task<Engine> GetActiveEngine(string keywords)
        {
           var result =  await _engineRepository.GetActiveEngine();
            EngineUrl = result.EngineUrl;
            EngineParameter = result.EngineSearchParameter.Replace("{num}", numOfResult.ToString()).Replace("{keywords}", string.Join('+', keywords.Split(' ')));
            return result;
        }

        private async Task<string> SendRequest(string keywords)
        {

            var client = new HttpClient();
            
            // client.DefaultRequestHeaders.TryAddWithoutValidation("User-Agent",
            //    "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_14_0) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/70.0.3538.102 Safari/537.36");
          
            client.DefaultRequestHeaders.UserAgent.ParseAdd("Mozilla/5.0 (Windows NT  10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/121.0.6167.161 Safari/537");

            var response = await client.GetAsync($"{EngineUrl}{keywords}");
                 response.EnsureSuccessStatusCode();

            client.Dispose();
            return await response.Content.ReadAsStringAsync();
        }


        private List<int> GetMatchedResult(string result, string targetSearch)
        {
           

            // Create a Regex object with the pattern
            Regex regex = new Regex(targetSearch, RegexOptions.IgnoreCase);

            // Find matches
            MatchCollection matches = regex.Matches(result);
            return matches.Select(p=>p.Index).ToList();
            

            
        }
    }
}
