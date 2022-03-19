using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ThucHanh_0306191060.Areas.Admin.Models;
using ThucHanh_0306191060.Data;

namespace ThucHanh_0306191060.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SlideShowsController : Controller
    {
        private readonly ThucHanh_0306191060Context _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public SlideShowsController(ThucHanh_0306191060Context context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: Admin/SlideShows
        public async Task<IActionResult> Index()
        {
            var thucHanh_0306191060Context = _context.SlideShow.Include(s => s.Product);
            return View(await thucHanh_0306191060Context.ToListAsync());
        }

        // GET: Admin/SlideShows/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var slideShow = await _context.SlideShow
                .Include(s => s.Product)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (slideShow == null)
            {
                return NotFound();
            }

            return View(slideShow);
        }

        // GET: Admin/SlideShows/Create
        public IActionResult Create()
        {
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Description");
            ViewData["ProductName"] = new SelectList(_context.Products, "Id", "Name");
            return View();
        }

        // POST: Admin/SlideShows/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int ProductId, string Title,string Content,string Image,IFormFile ImageFile)
        {
            SlideShow slideShow = new SlideShow();
            slideShow.ProductId = ProductId;
            slideShow.Title = Title;
            slideShow.Content = Content;
            slideShow.Image = "a.jpg";
            slideShow.ImageFile = ImageFile;
            if (ModelState.IsValid)
            {
                _context.Add(slideShow);
                await _context.SaveChangesAsync();
                if (slideShow.ImageFile != null)
                {
                    var fileName = slideShow.Id.ToString() + Path.GetExtension(slideShow.ImageFile.FileName);
                    var uploadPath = Path.Combine(_webHostEnvironment.WebRootPath, "images", "slideshow");
                    var filePath = Path.Combine(uploadPath, fileName);
                    using (FileStream fs = System.IO.File.Create(filePath))
                    {
                        slideShow.ImageFile.CopyTo(fs);
                        fs.Flush();
                    }
                    slideShow.Image = fileName;
                    _context.Update(slideShow);
                    await _context.SaveChangesAsync();
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Description", slideShow.ProductId);
            return View(slideShow);
        }

        // GET: Admin/SlideShows/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var slideShow = await _context.SlideShow.FindAsync(id);
            if (slideShow == null)
            {
                return NotFound();
            }
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Description", slideShow.ProductId);
            return View(slideShow);
        }

        // POST: Admin/SlideShows/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ProductId,Title,Content,Image")] SlideShow slideShow)
        {
            if (id != slideShow.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(slideShow);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SlideShowExists(slideShow.Id))
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
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Description", slideShow.ProductId);
            return View(slideShow);
        }

        // GET: Admin/SlideShows/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var slideShow = await _context.SlideShow
                .Include(s => s.Product)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (slideShow == null)
            {
                return NotFound();
            }

            return View(slideShow);
        }

        // POST: Admin/SlideShows/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var slideShow = await _context.SlideShow.FindAsync(id);
            _context.SlideShow.Remove(slideShow);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SlideShowExists(int id)
        {
            return _context.SlideShow.Any(e => e.Id == id);
        }
    }
}
