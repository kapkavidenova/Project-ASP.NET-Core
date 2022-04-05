namespace BabyGet.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using BabyGet.Web.ViewModels.Items;

    public interface IItemsService
    {
        Task AddAsync(AddItemInputModel input, string userId, string imagePath);

        IEnumerable<T> GetAll<T>(int page, int itemsPerPage = 6);

        IEnumerable<T> GetRandom<T>(int count);

        int GetCount();

        T GetById<T>(int id);

        Task UpdateAsync(int id, EditItemInputModel input);

        Task DeleteAsync(int id);
    }
}
