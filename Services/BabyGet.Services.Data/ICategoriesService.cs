using System.Collections.Generic;

namespace BabyGet.Services.Data
{
    public interface ICategoriesService
    {
        IEnumerable<KeyValuePair<string, string>> GetAllCategories();
    }
}
