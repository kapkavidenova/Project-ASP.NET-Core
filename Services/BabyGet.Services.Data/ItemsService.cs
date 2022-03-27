namespace BabyGet.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;

    using BabyGet.Data.Common.Repositories;
    using BabyGet.Data.Models;
    using BabyGet.Web.ViewModels.Items;

    public class ItemsService : IItemsService
    {
        private readonly string[] allowedExtentions = new[] { "jpg", "png", "gif" };
        private readonly IDeletableEntityRepository<Item> itemsRepository;

        public ItemsService(
            IDeletableEntityRepository<Item> itemsRepository)
        {
            this.itemsRepository = itemsRepository;
        }

        public async Task AddAsync(AddItemInputModel input, string userId, string imagePath)
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
            Directory.CreateDirectory($"{imagePath}/items/");

            foreach (var image in input.Images)
            {
                var extension = Path.GetExtension(image.FileName).TrimStart('.');
                if (!this.allowedExtentions.Any(x => extension.EndsWith(x)))
                {
                    throw new Exception("Invalid image extension {extension}");
                }

                var dbImage = new Image
                {
                    AddedByUserId = userId,
                    Extension = extension,
                };

                item.Images.Add(dbImage);

                var physicalPath = $"{imagePath}/items/{dbImage.Id}.{extension}";

                using (var fileStream = new FileStream(physicalPath, FileMode.Create))
                {
                    await image.CopyToAsync(fileStream);
                }
            }

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
