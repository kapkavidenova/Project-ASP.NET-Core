namespace BabyGet.Web.ViewModels.Faq
{
    using System.Collections.Generic;

    public class FaqListInputModel
    {
        public IEnumerable<FaqInListInputModel> ListQuestions { get; set; }
    }
}
