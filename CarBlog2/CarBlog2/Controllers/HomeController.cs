using CarBlog2.Models;
using CarBlog2.ModelView;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CarBlog2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly blogDBContext _context;

        public HomeController(ILogger<HomeController> logger, blogDBContext context)
        {
            _logger = logger;
            _context = context;
        }
       
        public IActionResult Index()
        {
            HomeViewModel model = new HomeViewModel();
            var ls = _context.Posts.Include(x => x.Cast).AsNoTracking().ToList();
            model.Populars = ls;
            model.Inspiration = ls;
            model.Recents = ls;
            model.Feature = ls.Last();
            return View(model);
        }
        [Route("Contact.html")]
        public IActionResult Contact()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
