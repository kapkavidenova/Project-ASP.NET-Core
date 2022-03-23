﻿namespace BabyGet.Services.Data
{
    using System.Threading.Tasks;

    using BabyGet.Web.ViewModels.Items;

    public interface IItemsService
    {
        Task AddAsync(AddItemInputModel input);
    }
}