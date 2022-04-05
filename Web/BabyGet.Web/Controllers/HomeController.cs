namespace BabyGet.Web.Controllers
{
    using System.Diagnostics;

    using BabyGet.Services.Data;
    using BabyGet.Web.ViewModels;
    using BabyGet.Web.ViewModels.Home;
    using Microsoft.AspNetCore.Mvc;

    public class HomeController : BaseController
    {
        private readonly IGetCountsService countsService;
        private readonly IItemsService itemsService;

        public HomeController(IGetCountsService countsService, IItemsService itemsService)
        {
            this.countsService = countsService;
            this.itemsService = itemsService;
        }

        public IActionResult Index()
        {
            var countsDto = this.countsService.GetCounts();

            // var viewModel = this.countsService.GetCounts();

            // return this.View(viewModel);
            var viewModel = new IndexViewModel
            {
                CategoriesCount = countsDto.CategoriesCount,
                ItemsCount = countsDto.ItemsCount,
                RandomItems = this.itemsService.GetRandom<RandomItemViewModel>(5),
            };

            return this.View(viewModel);
        }

        public IActionResult Privacy()
        {
            return this.View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(
                new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }
    }
}
