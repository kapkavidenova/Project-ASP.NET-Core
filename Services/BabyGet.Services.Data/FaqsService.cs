namespace BabyGet.Services.Data.Models
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using BabyGet.Data.Common.Repositories;
    using BabyGet.Data.Models;
    using BabyGet.Web.ViewModels.Faq;

    public class FaqsService : IFaqsService
    {
        private readonly IRepository<Faq> faqsRepository;

        public FaqsService(IRepository<Faq> faqsRepository)
        {
            this.faqsRepository = faqsRepository;
        }

        public async Task AddAsync(FaqAddInputModel model)
        {
            var faq = new Faq
            {
                Question = model.Question,
                Answer = model.Answer,
            };

            await this.faqsRepository.AddAsync(faq);
            await this.faqsRepository.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var faq = this.faqsRepository.All().FirstOrDefault(i => i.Id == id);
            this.faqsRepository.Delete(faq);
            await this.faqsRepository.SaveChangesAsync();
        }

        public IEnumerable<T> GetAll<T>()
        {
            var faqs = this.faqsRepository.AllAsNoTracking()
          .OrderByDescending(i => i.Id)
          .Select(f => new FaqInListInputModel
          {
              Id = f.Id,
              Question = f.Question,
              Answer = f.Answer,
          })
           .ToList();

            return (IEnumerable<T>)faqs;
        }
    }
}
