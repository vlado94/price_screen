using Microsoft.AspNetCore.Mvc;
using PriceScreen.Data;
using PriceScreen.Models;

namespace PriceScreen.Controllers
{
    public class StoreController : Controller
    {
        private readonly PriceScreenDbContext pscontext;
        public StoreController(PriceScreenDbContext pscontext)
        {
            this.pscontext = pscontext;
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        public async Task<IActionResult> Add(AddStoreViewModel addStoreRequest)
        {
            var store = new Store()
            {
                //Id = Guid.NewGuid(),
                StoreName = addStoreRequest.StoreName,
                StoreLocation = addStoreRequest.StoreLocation
            };

            await pscontext.Stores.AddAsync(store);
            await pscontext.SaveChangesAsync();
            return RedirectToAction("Add");
        }

    }
}

