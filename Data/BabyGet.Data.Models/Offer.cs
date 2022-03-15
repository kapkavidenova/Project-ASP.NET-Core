namespace BabyGet.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Offer
    {
        public int Id { get; set; }

        public double Price { get; set; }

        public TimeSpan RentalPeriod { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        public string Supplier { get; set; }

        public string Location { get; set; }
    }
}
