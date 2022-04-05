namespace BabyGet.Web.ViewModels.Home
{
    using System.Linq;

    using AutoMapper;
    using BabyGet.Data.Models;
    using BabyGet.Services.Mapping;
    using BabyGet.Web.ViewModels.Items;

    public class RandomItemViewModel : IMapFrom<Item>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string CategoryName { get; set; }

        public string ImageUrl { get; set; }

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
