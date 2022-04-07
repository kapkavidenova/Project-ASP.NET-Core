namespace BabyGet.Web.ViewModels.Items
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public abstract class BaseItemInputModel
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(1000)]
        public string Description { get; set; }

        public int ForWeight { get; set; }

        public int CategoryId { get; set; }

        public int? OfferId { get; set; }

        public IEnumerable<KeyValuePair<string, string>> CategoriesItems { get; set; }
    }
}
