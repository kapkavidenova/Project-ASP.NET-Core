namespace BabyGet.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using BabyGet.Data.Common.Repositories;
    using BabyGet.Data.Models;
    using BabyGet.Services.Mapping;
    using BabyGet.Web.ViewModels.Items;

    public class ItemsService : IItemsService
    {
        private readonly IDeletableEntityRepository<Item> itemsRepository;

        public ItemsService(IDeletableEntityRepository<Item> itemsRepository)
        {
            this.itemsRepository = itemsRepository;
        }

        public async Task AddAsync(AddItemInputModel input, string userId)
        {
            var item = new Item
            {
                CategoryId = input.CategoryId,
                Name = input.Name,
                Model = input.Model,
                Dimensions = input.Dimensions,
                Description = input.Description,
                ForWeight = input.ForWeight,
                AddedByUserId = userId,
            };

            await this.itemsRepository.AddAsync(item);
            await this.itemsRepository.SaveChangesAsync();
        }

        public IEnumerable<ItemInListViewModel> GetAll(int page, int itemsPerPage = 3)
        {
            var items = this.itemsRepository.AllAsNoTracking()
                .OrderByDescending(i => i.Id)
                .Skip((page - 1) * itemsPerPage)
                .Take(itemsPerPage)
               // .To<ItemInListViewModel>()
                 .Select(i => new ItemInListViewModel
                 {
                     Id = i.Id,
                     Name = i.Name,
                     CategoryName = i.Category.Name,
                     CategoryId = i.CategoryId,
                     ImageUrl = "images/items/" + i.Images.FirstOrDefault().Id + "." + i.Images.FirstOrDefault().Extension,
                 })
               .ToList();

            return items;
        }

        public int GetCount()
        {
            return this.itemsRepository.All().Count();
        }
    }
}
