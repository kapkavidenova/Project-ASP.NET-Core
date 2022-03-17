namespace BabyGet.Web.Controllers
{
    using BabyGet.Services.Data;
    using BabyGet.Web.ViewModels.Items;
    using Microsoft.AspNetCore.Mvc;

    public class ItemsController : Controller
    {
        private ICategoriesService categoriesService;

        public ItemsController(ICategoriesService categoriesService)
        {
            this.categoriesService = categoriesService;
        }

        public IActionResult Add()
        {
            var viewModel = new AddItemInputModel();
            viewModel.CategoriesItems = this.categoriesService.GetAllCategories();
            return this.View(viewModel);
        }

        [HttpPost]
        public IActionResult Add(AddItemInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                input.CategoriesItems = this.categoriesService.GetAllCategories();
                return this.View(input);
            }

            return this.Redirect("/");
        }
    }
}
