namespace BabyGet.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using BabyGet.Data.Common.Models;

    public class Item : BaseDeletableModel<int>
    {
        // public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(1000)]
        public string Description { get; set; }

        public int ForWeight { get; set; }

        [Required]
        [MaxLength(20)]
        public string Model { get; set; }

        public string Dimensions { get; set; }

        [MaxLength(100)]
        public string OriginalUrl { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }

        public int? OfferId { get; set; }

        public Offer Offer { get; set; }

        public string AddedByUserId { get; set; }

        public ApplicationUser AddedByUser { get; set; }

        public ICollection<Image> Images { get; set; } = new List<Image>();
    }
}
