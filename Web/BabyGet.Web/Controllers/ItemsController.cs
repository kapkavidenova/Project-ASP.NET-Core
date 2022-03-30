namespace BabyGet.Web.Controllers
{
    using System;
    using System.Threading.Tasks;

    using BabyGet.Data.Models;
    using BabyGet.Services.Data;
    using BabyGet.Web.ViewModels.Items;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class ItemsController : Controller
    {
        private readonly ICategoriesService categoriesService;
        private readonly IItemsService itemsService;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IWebHostEnvironment environment;

        public ItemsController(ICategoriesService categoriesService, IItemsService itemsService, UserManager<ApplicationUser> userManager,
             IWebHostEnvironment environment)
        {
            this.categoriesService = categoriesService;
            this.itemsService = itemsService;
            this.userManager = userManager;
            this.environment = environment;
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

            try
            {
                await this.itemsService.AddAsync(input, user.Id, $"{this.environment.WebRootPath}/images");
            }
            catch (Exception ex)
            {
                this.ModelState.AddModelError(string.Empty, ex.Message);
                input.CategoriesItems = this.categoriesService.GetAllCategories();
                return this.View(input);
            }

            return this.Redirect("/");
        }

        public IActionResult All(int id = 1)
        {
            if (id <= 0)
            {
                return this.NotFound();
            }

            const int ItemsPerPage = 3;
            var viewModel = new ItemsListViewModel
            {
                ItemsPerPage = ItemsPerPage,
                PageNumber = id,
                ItemsCount = this.itemsService.GetCount(),
                Items = this.itemsService.GetAll(id, ItemsPerPage),
            };
            return this.View(viewModel);
        }
    }
}
