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
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;

namespace CarBlog2.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PostsController : Controller
    {
        private readonly blogDBContext _context;

        public PostsController(blogDBContext context)
        {
            _context = context;
        }

        // GET: Admin/Posts
        
        public async Task<IActionResult> Index(int? page)
        {
            // Kiem tra quyen truy cap
           // if (User.Identity.IsAuthenticated) Response.Redirect("/dang-nhap.html");
           // //var taikhoanID = HttpContext.Session.GetString("AccountId");
           // if (taikhoanID == null) return RedirectToAction("Login", "Accounts", new { Area = "Admin" });

          //  var account = _context.Accounts.AsNoTracking().FirstOrDefault(x => x.AccountId == int.Parse(taikhoanID));
           // if (account != null) return NotFound();
            var pageNumber = page == null || page <= 0 ? 1 : page.Value;
            var pageSize = 10;
            var lsPosts = _context.Posts
               .OrderByDescending(x => x.Cast);
            PagedList<Post> models = new PagedList<Post>(lsPosts, pageNumber, pageSize);
            ViewBag.CurrentPage = pageNumber;
            return View(models);
        }

        // GET: Admin/Posts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var post = await _context.Posts
                .Include(p => p.Account)
                .Include(p => p.Cast)
                .FirstOrDefaultAsync(m => m.PostId == id);
            if (post == null)
            {
                return NotFound();
            }

            return View(post);
        }

        // GET: Admin/Posts/Create
        public IActionResult Create()
        {
            ViewData["AccountId"] = new SelectList(_context.Accounts, "AccountId", "FullName");
            ViewData["CastId"] = new SelectList(_context.Categories, "CastId", "CastName");
            return View();
        }

        // POST: Admin/Posts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PostId,Tite,Contents,Thumb,Published,Alias,CreateDate,Author,AccountId,ShortContent,Tag,CastId,IsHot,IsNewfeed")] Post post, Microsoft.AspNetCore.Http.IFormFile fThumb, Microsoft.AspNetCore.Http.IFormFile fThumb1, Microsoft.AspNetCore.Http.IFormFile fThumb2)
        {
            post.Alias = Utilities.SEOurl(post.Tite);
            if (ModelState.IsValid)
            {
                if (fThumb != null)
                {
                    string extension = Path.GetExtension(fThumb.FileName);
                    string NewName = Utilities.SEOurl(post.ShortContent) + "preview_" + extension;
                    post.Thumb = await Utilities.UploadFile(fThumb, @"posts\", NewName.ToLower());
                }
                if (fThumb1 != null)
                {
                    string extension = Path.GetExtension(fThumb1.FileName);
                    string NewName = Utilities.SEOurl(post.ShortContent) + "preview_" + extension;
                    post.Thumb1 = await Utilities.UploadFile(fThumb1, @"posts\", NewName.ToLower());
                }
                if (fThumb2 != null)
                {
                    string extension = Path.GetExtension(fThumb2.FileName);
                    string NewName = Utilities.SEOurl(post.ShortContent) + "preview_" + extension;
                    post.Thumb2 = await Utilities.UploadFile(fThumb2, @"posts\", NewName.ToLower());
                }
                _context.Add(post);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AccountId"] = new SelectList(_context.Accounts, "AccountId", "FullName", post.AccountId);
            ViewData["CastId"] = new SelectList(_context.Categories, "CastId", "CastName", post.CastId);
            return View(post);
        }

        // GET: Admin/Posts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var post = await _context.Posts.FindAsync(id);
            if (post == null)
            {
                return NotFound();
            }
            ViewData["AccountId"] = new SelectList(_context.Accounts, "AccountId", "AccountId", post.AccountId);
            ViewData["CastId"] = new SelectList(_context.Categories, "CastId", "CastId", post.CastId);
            return View(post);
        }

        // POST: Admin/Posts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, [Bind("PostId,Tite,Contents,Thumb,Published,Alias,CreateDate,Author,AccountId,ShortContent,Tag,CastId,IsHot,IsNewfeed")] Post post, Microsoft.AspNetCore.Http.IFormFile fThumb, Microsoft.AspNetCore.Http.IFormFile fThumb1, Microsoft.AspNetCore.Http.IFormFile fThumb2)
        {
            if (id != post.PostId)
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
                        string NewName = Utilities.SEOurl(post.ShortContent) + "preview_" + extension;
                        post.Thumb = await Utilities.UploadFile(fThumb, @"posts\", NewName.ToLower());
                    }
                    if (fThumb1 != null)
                    {
                        string extension = Path.GetExtension(fThumb1.FileName);
                        string NewName = Utilities.SEOurl(post.ShortContent) + "preview_" + extension;
                        post.Thumb1 = await Utilities.UploadFile(fThumb1, @"posts\", NewName.ToLower());
                    }
                    if (fThumb2 != null)
                    {
                        string extension = Path.GetExtension(fThumb2.FileName);
                        string NewName = Utilities.SEOurl(post.ShortContent) + "preview_" + extension;
                        post.Thumb2 = await Utilities.UploadFile(fThumb2, @"posts\", NewName.ToLower());
                    }
                    _context.Update(post);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PostExists(post.PostId))
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
            ViewData["AccountId"] = new SelectList(_context.Accounts, "AccountId", "AccountId", post.AccountId);
            ViewData["CastId"] = new SelectList(_context.Categories, "CastId", "CastId", post.CastId);
            return View(post);
        }

        // GET: Admin/Posts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var post = await _context.Posts
                .Include(p => p.Account)
                .Include(p => p.Cast)
                .FirstOrDefaultAsync(m => m.PostId == id);
            if (post == null)
            {
                return NotFound();
            }

            return View(post);
        }

        // POST: Admin/Posts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            var post = await _context.Posts.FindAsync(id);
            _context.Posts.Remove(post);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PostExists(int? id)
        {
            return _context.Posts.Any(e => e.PostId == id);
        }
    }
}
