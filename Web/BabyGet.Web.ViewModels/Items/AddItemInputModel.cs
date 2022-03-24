namespace BabyGet.Web.ViewModels.Items
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class AddItemInputModel
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(1000)]
        public string Description { get; set; }

        [Range(0, 25)]
        public int ForWeight { get; set; }

        [Required]
        [MaxLength(20)]
        public string Model { get; set; }

        public string Dimensions { get; set; }

        // public string ImageUrl { get; set; }
        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        public IEnumerable<KeyValuePair<string, string>> CategoriesItems { get; set; }
    }
}
