using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CarBlog2.Models;
using PagedList.Core;
using System.IO;
using CarBlog2.Helpers;
namespace CarBlog2.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoriesController : Controller
    {
        private readonly blogDBContext _context;

        public CategoriesController(blogDBContext context)
        {
            _context = context;
        }

        // GET: Admin/Categories
        public IActionResult Index(int? page)
        {
            var pageNumber = page == null || page <= 0 ? 1 : page.Value;
            var pageSize = 1;
            var lsCategories = _context.Categories
               .OrderByDescending(x => x.CastId);
            PagedList<Category> models = new PagedList<Category>(lsCategories, pageNumber, pageSize);
            ViewBag.CurrentPage = pageNumber;
            return View(models);
        }

        // GET: Admin/Categories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await _context.Categories
                .FirstOrDefaultAsync(m => m.CastId == id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // GET: Admin/Categories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Categories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CastId,CastName,Title,Alias,MetaDesc,MetaKey,Thumb,Published,Ordering,Parent,Levels,Icon,Cover,Description")] Category category, Microsoft.AspNetCore.Http.IFormFile fThumb)
        {
            category.Alias = Utilities.SEOurl(category.CastName);
            if (ModelState.IsValid)
            {
                if (fThumb != null)
                {
                    string extension = Path.GetExtension(fThumb.FileName);
                    string NewName = Utilities.SEOurl(category.CastName) + "preview_" + extension;
                    category.Thumb = await Utilities.UploadFile(fThumb, @"categories\", NewName.ToLower());
                }
                _context.Add(category);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

        // GET: Admin/Categories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var category = await _context.Categories.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        // POST: Admin/Categories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CastId,CastName,Title,Alias,MetaDesc,MetaKey,Thumb,Published,Ordering,Parent,Levels,Icon,Cover,Description")] Category category, Microsoft.AspNetCore.Http.IFormFile fThumb)
        {
            {
                if (id != category.CastId)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    try
                    {
                        if (fThumb != null)
                        {
                            string extension = Path.GetExtension(fThumb.FileName);
                            string NewName = Utilities.SEOurl(category.CastName) + "preview_" + extension;
                            category.Thumb = await Utilities.UploadFile(fThumb, @"categories\", NewName.ToLower());
                        }
                        _context.Update(category);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!CategoryExists(category.CastId))
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
                return View(category);
            }
        }

            // GET: Admin/Categories/Delete/5
            public async Task<IActionResult> Delete(int? id)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var category = await _context.Categories
                    .FirstOrDefaultAsync(m => m.CastId == id);
                if (category == null)
                {
                    return NotFound();
                }

                return View(category);
            }

            // POST: Admin/Categories/Delete/5
            [HttpPost, ActionName("Delete")]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> DeleteConfirmed(int id)
            {
                var category = await _context.Categories.FindAsync(id);
                _context.Categories.Remove(category);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            private bool CategoryExists(int id)
            {
                return _context.Categories.Any(e => e.CastId == id);
            }
        }
    }

