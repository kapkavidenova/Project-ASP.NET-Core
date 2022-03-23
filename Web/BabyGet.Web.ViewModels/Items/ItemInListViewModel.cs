namespace BabyGet.Web.ViewModels.Items
{
    using AutoMapper;
    using BabyGet.Data.Models;
    using BabyGet.Services.Mapping;

    public class ItemInListViewModel : IMapFrom<Item>
    {
        public int Id { get; set; }

        public string Name { get; set; }
 
        public int CategoryId { get; set; }
 
        public string CategoryName { get; set; }

        public string ImageUrl { get; set; }
    }
}
