namespace BabyGet.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using BabyGet.Web.ViewModels.Items;

    public interface IItemsService
    {
        Task AddAsync(AddItemInputModel input,string userId);

        IEnumerable<ItemInListViewModel> GetAll(int page, int itemsPerPage = 3);

        int GetCount();

    }
}
