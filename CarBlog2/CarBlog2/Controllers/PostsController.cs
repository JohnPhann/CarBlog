using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CarBlog2.Models;
using PagedList.Core;

namespace CarBlog2.Controllers
{
    public class PostsController : Controller
    {
        private readonly blogDBContext _context;

        public PostsController(blogDBContext context)
        {
            _context = context;
        }
       //GET: Posts
       ///GET: List
       [Route("{Alias}", Name = "ListTin")]
                public IActionResult List(string Alias, int? page)
        {
            if (string.IsNullOrEmpty(Alias)) return RedirectToAction("Index", "Home");
            var danhmuc = _context.Categories.FirstOrDefault(x => x.Alias == Alias);
            if (danhmuc == null) return RedirectToAction("Index", "Home");
            var pageNumber = page == null || page <= 0 ? 1 : page.Value;
            var pageSize = 20;
            List<Post> lsPosts = new List<Post>();

            if (!string.IsNullOrEmpty(Alias))
            {
                lsPosts = _context.Posts
                    .Include(x => x.Cast)
                    .Where(x => x.CastId == danhmuc.CastId)
                    .AsNoTracking()
              .OrderByDescending(x => x.CreateDate)
              .ToList();


            }
            else {
                lsPosts = _context.Posts
                     .Include(x => x.Cast)
                      .AsNoTracking()
                     .OrderByDescending(x => x.CreateDate)
                        .ToList();
            }


            
            PagedList<Post> models = new PagedList<Post>(lsPosts.AsQueryable(), pageNumber, pageSize);
            ViewBag.CurrentPage = pageNumber;
            ViewBag.DanhMuc = danhmuc;
            return View(models);
        }

        //GET: Posts/Details/5
        [Route("/{Alias}.html", Name = "PostsDetails")]
        public async Task<IActionResult> Details(string Alias)
        {
            if (string.IsNullOrEmpty(Alias))
            {
                return NotFound();
            }

            var post = await _context.Posts
                .Include(p => p.Account)
                .Include(p => p.Cast)
                .FirstOrDefaultAsync(m => m.Alias == Alias);
            if (post == null)
            {
                return NotFound();
            }

            return View(post);
        }



        //POST: Posts/Edit/5
        //         To protect from overposting attacks, enable the specific properties you want to bind to.
        //         For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.

                private bool PostExists(int? id)
        {
            return _context.Posts.Any(e => e.PostId == id);
        }
    }
}
