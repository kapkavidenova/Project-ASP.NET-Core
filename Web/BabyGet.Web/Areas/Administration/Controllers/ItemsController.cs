namespace BabyGet.Web.Areas.Administration.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;

    using BabyGet.Data.Common.Repositories;
    using BabyGet.Data.Models;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;

    public class ItemsController : AdministrationController
    {
        private readonly IDeletableEntityRepository<Item> dataRepository;

        public ItemsController(IDeletableEntityRepository<Item> dataRepository)
        {
            // this.db = context;
            this.dataRepository = dataRepository;
        }

        public async Task<IActionResult> Index()
        {
            return this.View(await this.dataRepository.AllWithDeleted().ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var item = await this.dataRepository.All()
                .FirstOrDefaultAsync(m => m.Id == id);
            if (item == null)
            {
                return this.NotFound();
            }

            return this.View(item);
        }

        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,IsDeletedOn,Id,CreatedOn,ModifiedOn")] Item item)
        {
            if (this.ModelState.IsValid)
            {
                await this.dataRepository.AddAsync(item);
                await this.dataRepository.SaveChangesAsync();
                return this.RedirectToAction(nameof(this.Index));
            }

            return this.View(item);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var item = this.dataRepository.All().FirstOrDefault(x => x.Id == id);
            if (item == null)
            {
                return this.NotFound();
            }

            return this.View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name,IsDeleted,DeletedOn,Id,CreatedOn,ModifiedOn")] Item item)
        {
            if (id != item.Id)
            {
                return this.NotFound();
            }

            if (this.ModelState.IsValid)
            {
                try
                {
                    this.dataRepository.Update(item);
                    await this.dataRepository.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!this.ItemExists(item.Id))
                    {
                        return this.NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                return this.RedirectToAction(nameof(this.Index));
            }

            return this.View(item);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var item = await this.dataRepository.All()
                .FirstOrDefaultAsync(m => m.Id == id);
            if (item == null)
            {
                return this.NotFound();
            }

            return this.View(item);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var item = this.dataRepository.All().FirstOrDefault(x => x.Id == id);
            this.dataRepository.Delete(item);
            await this.dataRepository.SaveChangesAsync();
            return this.RedirectToAction(nameof(this.Index));
        }

        private bool ItemExists(int id)
        {
            return this.dataRepository.All().Any(e => e.Id == id);
        }
    }
}
