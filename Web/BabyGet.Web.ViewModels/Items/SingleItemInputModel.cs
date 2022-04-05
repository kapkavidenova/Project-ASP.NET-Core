namespace BabyGet.Web.ViewModels.Items
{
    using System.Linq;

    using AutoMapper;
    using BabyGet.Data.Models;
    using BabyGet.Services.Mapping;

    public class SingleItemInputModel : IMapFrom<Item>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string CategoryName { get; set; }

        public string Description { get; set; }

        public int ForWeight { get; set; }

        public string Model { get; set; }

        public string Dimensions { get; set; }

        public string OriginalUrl { get; set; }

        public int CategoryId { get; set; }

        public int? OfferId { get; set; }

        public Offer Offer { get; set; }

        public void CreateMappings(IProfileExpression configuration)
            {
                configuration.CreateMap<Item, ItemInListViewModel>()
                     .ForMember(i => i.ImageUrl, opt =>
                     opt.MapFrom(
                         i => i.Images.FirstOrDefault().RemoteUrl != null ?
                                     i.Images.FirstOrDefault().RemoteUrl :
                                     "/images/items/" + i.Images.FirstOrDefault().Id + "." + i.Images.FirstOrDefault().Extension));
            }
    }
}
