namespace BabyGet.Web.ViewModels.Faq
{
    using System.ComponentModel.DataAnnotations;

    public class FaqAddInputModel
    {
        [Required]
        public string Question { get; set; }

        [Required]
        public string Answer { get; set; }
    }
}
