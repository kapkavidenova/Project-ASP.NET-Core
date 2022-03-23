namespace BabyGet.Services.Data
{
    using System.Threading.Tasks;

    using BabyGet.Data.Common.Repositories;
    using BabyGet.Data.Models;
    using BabyGet.Web.ViewModels.Items;

    public class ItemsService : IItemsService
    {
        private readonly IDeletableEntityRepository<Item> itemsRepository;

        public ItemsService(IDeletableEntityRepository<Item> itemsRepository)
        {
            this.itemsRepository = itemsRepository;
        }

        public async Task AddAsync(AddItemInputModel input)
        {
            var item = new Item
            {
                CategoryId = input.CategoryId,
                Name = input.Name,
                Model = input.Model,
                Dimensions = input.Dimensions,
                Description = input.Description,
                ForWeight = input.ForWeight,
            };

            await this.itemsRepository.AddAsync(item);
            await this.itemsRepository.SaveChangesAsync();
        }
    }
}
