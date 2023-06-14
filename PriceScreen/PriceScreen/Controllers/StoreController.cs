using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PriceScreen.Data;
using PriceScreen.Models;
using Microsoft.AspNetCore.Hosting;

namespace PriceScreen.Controllers
{
    public class StoreController : Controller
    {
        private readonly PriceScreenDbContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;
        public Store store1 { get; set; }

        public StoreController(PriceScreenDbContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            this._hostEnvironment = hostEnvironment;
        }

        // GET: Store
        public async Task<IActionResult> Index()
        {
              return _context.Stores != null ? 
                          View(await _context.Stores.ToListAsync()) :
                          Problem("Entity set 'PriceScreenDbContext.Stores'  is null.");
        }

        // GET: Store/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Stores == null)
            {
                return NotFound();
            }

            var store = await _context.Stores
                .FirstOrDefaultAsync(m => m.StoreId == id);
            if (store == null)
            {
                return NotFound();
            }

            return View(store);
        }

        // GET: Store/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Store/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Store store)
        {
            
           
            if (ModelState.IsValid)
            {
                byte[] imageBytes = null;
                //store.ImageName = store.ImageFile.FileName;
                //Saving image to wwwroot/Image
                // string wwwRootPath = _hostEnvironment.WebRootPath;
                // string fileName = Path.GetFileNameWithoutExtension(store.ImageFile.FileName);
                // string extension = Path.GetExtension(store.ImageFile.FileName);
                //// store.ImageName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                // string path = Path.Combine(wwwRootPath + "/image/", fileName);
                // using (var fileStream = new FileStream(path, FileMode.Create))
                // {
                //     await store.ImageFile.CopyToAsync(fileStream);
                // }

                //Napraviti niz bajtova koji ce sluziti sa cuvanje slike u bazi
                // Niz bajtova(koji cine sliku) koji ce biti u stringu treba proslediti u bajt i sacuvati 
                //napisati logiku za konvertovanje ImageFile u byte[]

                //store.ImageData = Convert.ToBase64String(bytes);

                if(store1.ImageFile != null)
                {
                    using (Stream stream1 = store1.ImageFile.OpenReadStream())
                    {
                        //mozda treba dodati using ispred ovoga
                        using (BinaryReader reader = new BinaryReader(stream1))
                        {
                            imageBytes = reader.ReadBytes((Int32)stream1.Length);
                        }
                    }
                    store1.ImageData = Convert.ToBase64String(imageBytes, 0, imageBytes.Length);
                }



                 
                _context.Stores.Add(store);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(store);
        }

        // GET: Store/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Stores == null)
            {
                return NotFound();
            }

            var store = await _context.Stores.FindAsync(id);
            if (store == null)
            {
                return NotFound();
            }
            return View(store);
        }

        // POST: Store/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StoreId,StoreName,StoreLocation,ImageName")] Store store)
        {
            if (id != store.StoreId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(store);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StoreExists(store.StoreId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(store);
        }

        // GET: Store/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Stores == null)
            {
                return NotFound();
            }

            var store = await _context.Stores
                .FirstOrDefaultAsync(m => m.StoreId == id);
            if (store == null)
            {
                return NotFound();
            }

            return View(store);
        }

        // POST: Store/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Stores == null)
            {
                return Problem("Entity set 'PriceScreenDbContext.Stores'  is null.");
            }
            var store = await _context.Stores.FindAsync(id);

            //if (store != null)
            //{
            //    _context.Stores.Remove(store);
            //}
            var imagePath = Path.Combine(_hostEnvironment.WebRootPath,"image", store.ImageName);
            if (System.IO.File.Exists(imagePath))
                System.IO.File.Delete(imagePath);

            //delete detele image wwwroot/image
            _context.Stores.Remove(store);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StoreExists(int id)
        {
          return (_context.Stores?.Any(e => e.StoreId == id)).GetValueOrDefault();
        }
    }
}
