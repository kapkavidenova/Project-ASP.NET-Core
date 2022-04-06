namespace BabyGet.Web.Controllers
{
    using BabyGet.Services.Data;
    using BabyGet.Web.ViewModels.Faq;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc;

    public class FaqsController : Controller
    {
        private readonly IFaqsService faqsService;
        private readonly IWebHostEnvironment environment;

        public FaqsController(IFaqsService faqsService, IWebHostEnvironment environment)
        {
            this.faqsService = faqsService;
            this.environment = environment;
        }

        public IActionResult GetAll()
        {
            var viewModel = new FaqListInputModel
            {
                ListQuestions = this.faqsService.GetAll<FaqInListInputModel>(),
            };
            return this.View(viewModel);
        }
    }
}
