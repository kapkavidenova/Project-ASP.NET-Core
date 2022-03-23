namespace BabyGet.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;

    using BabyGet.Data.Common.Repositories;
    using BabyGet.Data.Models;

    public class CategoriesService : ICategoriesService
    {
        private IRepository<Category> categoriesRepository;

        public CategoriesService(IRepository<Category> categoriesRepository)
        {
            this.categoriesRepository = categoriesRepository;
        }

        public IEnumerable<KeyValuePair<string, string>> GetAllCategories()
        {
           return this.categoriesRepository.AllAsNoTracking().Select(c => new
            {
                c.Id, c.Name,
            })
                .OrderBy(c => c.Name)
                .ToList().Select(x => new KeyValuePair<string, string>(x.Id.ToString(), x.Name));
        }
    }
}
