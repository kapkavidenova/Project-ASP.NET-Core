namespace BabyGet.Services.Data
{
    using System.Linq;

    using BabyGet.Data.Common.Repositories;
    using BabyGet.Data.Models;
    using BabyGet.Web.ViewModels.Home;

    public class GetCountsService : IGetCountsService
    {
        private readonly IRepository<Category> categoriesRepository;
        private readonly IDeletableEntityRepository<Item> itemsRepository;

        public GetCountsService(
            IRepository<Category> categoriesRepository,
            IDeletableEntityRepository<Item> itemsRepository)
        {
            this.categoriesRepository = categoriesRepository;
            this.itemsRepository = itemsRepository;
        }

        public IndexViewModel GetCounts()
        {
            var data = new IndexViewModel
            {
                CategoriesCount = this.categoriesRepository.All().Count(),
                ItemsCount = this.itemsRepository.All().Count(),
            };

            return data;
        }
    }
}
