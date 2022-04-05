namespace BabyGet.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using BabyGet.Data.Common.Models;

    public class Image : BaseDeletableModel<string>
    {
        public Image()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public int ItemId { get; set; }

        public Item Item { get; set; }

        public string RemoteUrl { get; set; }

        public string Extension { get; set; }

        [Required]
        public string AddedByUserId { get; set; }

        public ApplicationUser AddedByUser { get; set; }
    }
}
