namespace BabyGet.Web.ViewModels.Items
{
    using System.Collections.Generic;

    public class ItemsListViewModel
    {
        public IEnumerable<ItemInListViewModel> Items { get; set; }

        public int PageNumber { get; set; }
    }
}
