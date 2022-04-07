namespace BabyGet.Web.ViewModels.Offer
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class BaseOfferViewModel
    {
        public int OfferId { get; set; }

        public double Price { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        public string Location { get; set; }

        public string UserId { get; set; }

        public TimeSpan RentalPeriod => this.EndDate - this.StartDate;

        // public string Supplier { get; set; }
        // public bool IsActive { get; set; }
    }
}
