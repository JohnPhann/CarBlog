using CarBlog2.Enum;
using CarBlog2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CarBlog2.Controllers.Components
{
    public class CategorieViewComponent : ViewComponent
    {
        private readonly blogDBContext _context;
        private IMemoryCache _memoryCache;
        public CategorieViewComponent(blogDBContext context, IMemoryCache memoryCache)
        {
            _context = context;
            _memoryCache = memoryCache;


        }

        public IViewComponentResult Invoke()
        {
            var _tinseo = _memoryCache.GetOrCreate(CacheKeys.Categories, entry =>
            {
                entry.SlidingExpiration = TimeSpan.MaxValue;
                return GetlsCategories();


            });
            return View(_tinseo);


        }

     
        public List<Category> GetlsCategories()
        {
            List<Category> lstins = new List<Category>();
            lstins = _context.Categories
                .Where(x => x.Published == true)
                .OrderBy(x => x.Ordering)
                .ToList();
            return lstins;

        
        
        }
    }
}
