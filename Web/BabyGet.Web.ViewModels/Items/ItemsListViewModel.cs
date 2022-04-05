namespace BabyGet.Web.ViewModels.Items
{
    using System;
    using System.Collections.Generic;

    public class ItemsListViewModel : PagingViewModel
    {
        public IEnumerable<ItemInListViewModel> Items { get; set; }
    }
}
