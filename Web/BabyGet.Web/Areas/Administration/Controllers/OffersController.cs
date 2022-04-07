namespace BabyGet.Web.Areas.Administration.Controllers
{
    using System.Threading.Tasks;

    using BabyGet.Common;
    using BabyGet.Services.Data.Offer;
    using BabyGet.Web.ViewModels.Offer;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    public class OffersController : Controller
    {
        private readonly IOffersService offersService;

        public OffersController(IOffersService offersService)
        {
            this.offersService = offersService;
        }

        [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
        public IActionResult Create(CreateOfferViewModel model)
        {
           if (!this.ModelState.IsValid)
            {
                return this.RedirectToAction("Create");
            }

           this.offersService.Create(model);
           return this.RedirectToAction("/");
        }
    }
}
