namespace BabyGet.Web.ViewModels.Home
{
    using System;
    using System.Collections.Generic;

    public class IndexViewModel
    {
        public IEnumerable<RandomItemViewModel> RandomItems { get; set; }

        public int ItemsCount { get; set; }

        public int CategoriesCount { get; set; }
    }
}
