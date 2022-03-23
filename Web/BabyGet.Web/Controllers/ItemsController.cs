namespace BabyGet.Web.Controllers
{
    using System.Threading.Tasks;

    using BabyGet.Services.Data;
    using BabyGet.Web.ViewModels.Items;
    using Microsoft.AspNetCore.Mvc;

    public class ItemsController : Controller
    {
        private readonly ICategoriesService categoriesService;
        private readonly IItemsService itemsService;


        public ItemsController(ICategoriesService categoriesService, IItemsService itemsService)
        {
            this.categoriesService = categoriesService;
            this.itemsService = itemsService;
        }

        public IActionResult Add()
        {
            var viewModel = new AddItemInputModel();
            viewModel.CategoriesItems = this.categoriesService.GetAllCategories();
            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddItemInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                input.CategoriesItems = this.categoriesService.GetAllCategories();
                return this.View(input);
            }

            await this.itemsService.AddAsync(input);
            return this.Redirect("/");
        }
    }
}
