namespace BabyGet.Services.Data.Offer
{
    using BabyGet.Web.ViewModels.Offer;

    public interface IOffersService
    {
        void Create(CreateOfferViewModel model);
    }
}