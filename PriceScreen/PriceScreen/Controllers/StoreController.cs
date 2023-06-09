using PriceScreen.Data;
using PriceScreen.Models;
using PriceScreen.StoreViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PriceScreen.Controllers
{
    public class StoreController : Controller
    {
        private readonly PriceScreenDbContext db;
        private readonly IWebHostEnvironment webHostEnvironment;

        public StoreController(PriceScreenDbContext context, IWebHostEnvironment hostEnvironment)
        {
            db = context;
            webHostEnvironment = hostEnvironment;
        }


        public async Task<IActionResult> Index()
        {
            return View(await db.Stores.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var store = await db.Stores
                .FirstOrDefaultAsync(m => m.Id == id);

            var speakerViewModel = new StoreViewModel()
            {
                Id = store.Id,
                StoreName = store.StoreName,               
                Image = store.StoreLogo
            };

            if (store == null)
            {
                return NotFound();
            }

            return View(store);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(StoreViewModel model)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = ProcessUploadedFile(model);
                Store store = new Store
                {
                    StoreName = model.StoreName,
                    StoreLocation = model.StoreLocation,                  
                    StoreLogo = uniqueFileName
                };

                db.Add(store);
                await db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var store = await db.Stores.FindAsync(id);
            var storeViewModel = new StoreViewModel()
            {
                Id = store.Id,
                StoreName = store.StoreName,        
                Image = store.StoreLogo
            };

            if (store == null)
            {
                return NotFound();
            }
            return View(storeViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, StoreViewModel model)
        {
            if (ModelState.IsValid)
            {
                var store = await db.Stores.FindAsync(model.Id);
                store.StoreName = model.StoreName;
                store.StoreLocation = model.StoreLocation;

                if (model.StorePicture != null)
                {
                    if (model.Image != null)
                    {
                        string filePath = Path.Combine(webHostEnvironment.WebRootPath, "Uploads", model.Image);
                        System.IO.File.Delete(filePath);
                    }

                    store.StoreLogo = ProcessUploadedFile(model);
                }
                db.Update(store);
                await db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var store = await db.Stores
                .FirstOrDefaultAsync(m => m.Id == id);

            var storeViewModel = new StoreViewModel()
            {
                Id = store.Id,
                StoreName = store.StoreName,
                StoreLocation = store.StoreLocation,            
                Image = store.StoreLogo
            };
            if (store == null)
            {
                return NotFound();
            }

            return View(storeViewModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var store = await db.Stores.FindAsync(id);
            var CurrentImage = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images", store.StoreLogo);
            db.Stores.Remove(store);
            if (await db.SaveChangesAsync() > 0)
            {
                if (System.IO.File.Exists(CurrentImage))
                {
                    System.IO.File.Delete(CurrentImage);
                }
            }
            return RedirectToAction(nameof(Index));
        }

        private bool StoresExists(int id)
        {
            return db.Stores.Any(e => e.Id == id);
        }

        private string ProcessUploadedFile(StoreViewModel model)
        {
            string uniqueFileName = null;

            if (model.StorePicture != null)
            {
                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "Uploads");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.StorePicture.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.StorePicture.CopyTo(fileStream);
                }
            }

            return uniqueFileName;
        }

    }
}
