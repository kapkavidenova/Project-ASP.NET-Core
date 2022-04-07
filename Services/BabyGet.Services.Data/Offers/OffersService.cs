namespace BabyGet.Services.Data.Offers
{
    using System.Threading.Tasks;
    using BabyGet.Data;
    using BabyGet.Data.Common.Repositories;
    using BabyGet.Services.Data.Offer;
    using BabyGet.Web.ViewModels.Offer;

    public class OffersService : IOffersService
    {

        private readonly ApplicationDbContext data;

        public OffersService(ApplicationDbContext data)
        {
            this.data = data;
        }

        public void Create(CreateOfferViewModel model)
        {
            var offer = new BabyGet.Data.Models.Offer
            {
                Id = model.OfferId,
                Price = model.Price,
                StartDate = model.StartDate,
                EndDate = model.EndDate,
                RentalPeriod = model.RentalPeriod,
                Location = model.Location,
                IsActive = model.IsActive,
            };

            this.data.Offers.Add(offer);
            this.data.SaveChanges();
        }
    }
}
