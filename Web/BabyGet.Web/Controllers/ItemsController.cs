namespace BabyGet.Web.Controllers
{
    using System.Threading.Tasks;
    using BabyGet.Common;
    using BabyGet.Data.Models;
    using BabyGet.Services.Data;
    using BabyGet.Web.ViewModels.Items;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class ItemsController : Controller
    {
        private readonly ICategoriesService categoriesService;
        private readonly IItemsService itemsService;
        private readonly UserManager<ApplicationUser> userManager;

        public ItemsController(ICategoriesService categoriesService, IItemsService itemsService,UserManager<ApplicationUser> userManager)
        {
            this.categoriesService = categoriesService;
            this.itemsService = itemsService;
            this.userManager = userManager;
        }

        [Authorize]
        public IActionResult Add()
        {
            // var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var viewModel = new AddItemInputModel();
            viewModel.CategoriesItems = this.categoriesService.GetAllCategories();
            return this.View(viewModel);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Add(AddItemInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                input.CategoriesItems = this.categoriesService.GetAllCategories();
                return this.View(input);
            }

            // var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var user = await this.userManager.GetUserAsync(this.User);
            await this.itemsService.AddAsync(input, user.Id);
            return this.Redirect("/");
        }

        public IActionResult All(int id)
        {
            var viewModel = new ItemsListViewModel
            {
                PageNumber = id,
                Items = this.itemsService.GetAll(id, 9),
            };
            return this.View(viewModel);
        }
    }
}
