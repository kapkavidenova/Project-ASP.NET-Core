namespace BabyGet.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using BabyGet.Web.ViewModels.Faq;

    public interface IFaqsService
    {
        IEnumerable<T> GetAll<T>();

        Task AddAsync(FaqAddInputModel model);

        Task DeleteAsync(int id);
    }
}
