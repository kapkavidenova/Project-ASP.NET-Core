namespace BabyGet.Services.Data
{
    using BabyGet.Web.ViewModels.Items;
    using System.Threading.Tasks;

    public interface IItemsService
    {
        Task Add(AddItemInputModel input);
    }
}
