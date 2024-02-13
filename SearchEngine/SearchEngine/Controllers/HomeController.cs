using Microsoft.AspNetCore.Mvc;
using SearchEngine.Models;
using SearchEngine.Models.Repositories;
using SearchEngine.Services.SearchService;
using System.Diagnostics;

namespace SearchEngine.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ISearchService _searchService;
        private readonly IEngineRepository _engineRepository;
        public HomeController(ILogger<HomeController> logger, ISearchService serviceService, IEngineRepository engineRepository)
        {
            _logger = logger;
            _searchService = serviceService;
            _engineRepository = engineRepository;
        }

        public async Task<IActionResult> Index(SearchViewModel model)
        {
            if (model == null)
                model = new SearchViewModel();

            await Search(model);
          //  var k = _searchService.Search("www.infotrack.co.uk", "land registry search").Result;
            return View(model);
        }
        [HttpPost]
        public IActionResult Submit(SearchViewModel model)
        {
           return RedirectToAction("Index", model);
        }
        
            

        private async  Task<SearchViewModel> Search(SearchViewModel model)
        {  
            if (model != null &&  !string.IsNullOrEmpty(model.Url) && ! string.IsNullOrEmpty(model.Keywords))
            await _searchService.Search(model.Url, model.Keywords);

            var result = await _searchService.GetHistory();
                model.searchInfoList = result;

            return model;
        }

        public async Task<IActionResult> EnginePage()
        {
            var result = await _engineRepository.GetAllAsync();

            var model = new EngineViewModel
            {
                EngineList = result
            };


            return View(model);
        }

        public async Task<IActionResult> AddNewEngine(EngineViewModel model)
        {
            if (model != null)
            {
                model.Engine.EngineSearchParameter = "search?num={num}&q={keywords}";
                await _engineRepository.AddAsync(model.Engine);
            }

            return RedirectToAction("EnginePage");
        }
        public async Task<IActionResult> ChangeEngineActive(EngineViewModel model)
        {
            if (model != null)
            {
                await _engineRepository.SetEngineToActive(model.Engine.Id);
            }



            return RedirectToAction("EnginePage");


        }
    }
}
