namespace BabyGet.Web.ViewModels.Items
{
    using BabyGet.Data.Models;
    using BabyGet.Services.Mapping;

    public class EditItemInputModel : BaseItemInputModel, IMapFrom<Item>
    {
        public int Id { get; set; }

    }
}
