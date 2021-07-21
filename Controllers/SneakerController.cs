using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SneakerAIO.Models;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SneakerAIO.Controllers
{
    [Authorize]
    public class SneakerController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public SneakerController(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: Sneaker
        public async Task<IActionResult> Index()
        {
            return View(await _context.Sneaker.ToListAsync());
        }

        [HttpGet]
        public async Task<IActionResult> Index(string searchTerm)
        {
            ViewData["SearchTerm"] = searchTerm;

            var temp = from s in _context.Sneaker select s;

            if (!String.IsNullOrEmpty(searchTerm))
            {
                temp = temp.Where(s => (s.Style + "-" + s.Color).Contains(searchTerm) || s.Shoe.Contains(searchTerm));
            }

            return View(await temp.AsNoTracking().ToListAsync());
        }

        // GET: Sneaker/AddOrEdit
        // GET: Sneaker/AddOrEdit/5
        public async Task<IActionResult> AddOrEdit(int id = 0)
        {
            if (id == 0)
            {
                return View(new SneakerModel());
            }
            else
            {
                var sneakerModel = await _context.Sneaker.FindAsync(id);
                if (sneakerModel == null)
                {
                    return NotFound();
                }
                return View(sneakerModel);
            }
        }

        // POST: Sneaker/AddOrEdit
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit(int id, [Bind("ShoeId,Shoe,Style,Color,Size,Condition,ReleaseDate,ImagePath")] SneakerModel sneakerModel)
        {
            if (ModelState.IsValid)
            {
                // Insert new record.
                if (id == 0)
                {
                    _context.Add(sneakerModel);
                    await _context.SaveChangesAsync();

                    // Get sneaker id from database.
                    var sneakerId = sneakerModel.ShoeId;

                    // Get wwwrootpath to save the file on server.
                    string wwwRootPath = _webHostEnvironment.WebRootPath;

                    // Get the upload file.
                    var files = HttpContext.Request.Form.Files;

                    // Get the reference of Dbset
                    var SavedSneaker = _context.Sneaker.Find(sneakerId);

                    // Upload the file on server and save the path in database if user have submitted file.
                    if (files.Count != 0)
                    {
                        var date = DateTime.Now.ToString("MM-dd-yyyy");
                        var ImagePath = @"Images\";
                        var Extension = Path.GetExtension(files[0].FileName);
                        var RelativeImagePath = ImagePath + sneakerId + "-" + date + Extension;
                        var AbsImagePath = Path.Combine(wwwRootPath, RelativeImagePath);

                        // Upload the file to server.
                        using (var fileStream = new FileStream(AbsImagePath, FileMode.Create))
                        {
                            files[0].CopyTo(fileStream);
                        }

                        // Save the image file path to database
                        SavedSneaker.ImagePath = RelativeImagePath;
                        await _context.SaveChangesAsync();
                    }
                    else // Set default image
                    {
                        // Set default path to default image.
                        var DefaultImagePath = @"Images\no-image-available.jpg";

                        // Save the image file path to database
                        SavedSneaker.ImagePath = DefaultImagePath;
                        await _context.SaveChangesAsync();
                    }
                }
                // Update current record
                else
                {
                    try // Update file option. (Delete old file and replace)
                    {
                        _context.Update(sneakerModel);
                        await _context.SaveChangesAsync();

                        // Get sneaker id from database.
                        var sneakerId = sneakerModel.ShoeId;

                        // Get wwwrootpath to save the file on server.
                        string wwwRootPath = _webHostEnvironment.WebRootPath;

                        // Get the upload file.
                        var files = HttpContext.Request.Form.Files;

                        // Get the reference of Dbset
                        var SavedSneaker = _context.Sneaker.Find(sneakerId);

                        // Upload the file on server and save the path in database if user have submitted file.
                        if (files.Count != 0)
                        {
                            // Get old file path.
                            var OldImagePath = wwwRootPath + sneakerModel.ImagePath;

                            // Delete old file.
                            if (System.IO.File.Exists(OldImagePath))
                            {
                                if (OldImagePath != @"Images\no-image-available.jpg")
                                {
                                    System.IO.File.Delete(OldImagePath);
                                }
                            }

                            var date = DateTime.Now.ToString("MM-dd-yyyy");
                            var ImagePath = @"Images\";
                            var Extension = Path.GetExtension(files[0].FileName);
                            var RelativeImagePath = ImagePath + sneakerId + "-" + date + Extension;
                            var AbsImagePath = Path.Combine(wwwRootPath, RelativeImagePath);

                            // Upload the file to server.
                            using (var fileStream = new FileStream(AbsImagePath, FileMode.Create))
                            {
                                files[0].CopyTo(fileStream);
                            }

                            // Save the image file path to database
                            _context.Update(sneakerModel);
                            SavedSneaker.ImagePath = RelativeImagePath;

                            await _context.SaveChangesAsync();
                        }
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!SneakerModelExists(sneakerModel.ShoeId))
                        {
                            return NotFound();
                        }
                        else
                        {
                            throw;
                        }
                    }
                }

                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", _context.Sneaker.ToList()) });
            }
            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "AddOrEdit", sneakerModel) });
        }

        // POST: Sneaker/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sneakerModel = await _context.Sneaker.FindAsync(id);
            _context.Sneaker.Remove(sneakerModel);

            // Get wwwrootpath to save the file on server.
            string wwwRootPath = _webHostEnvironment.WebRootPath;

            // Get file path.
            var ImagePath = wwwRootPath + @"\" + sneakerModel.ImagePath;

            // Delete old file.
            if (System.IO.File.Exists(ImagePath))
            {
                if (ImagePath != @"Images\no-image-available.jpg")
                {
                    System.IO.File.Delete(ImagePath);
                }
            }

            await _context.SaveChangesAsync();

            return Json(new { html = Helper.RenderRazorViewToString(this, "_ViewAll", _context.Sneaker.ToList()) });
        }

        private bool SneakerModelExists(int id)
        {
            return _context.Sneaker.Any(e => e.ShoeId == id);
        }

    }
}