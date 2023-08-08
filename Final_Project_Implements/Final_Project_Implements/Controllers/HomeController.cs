using Final_Project_Implements.Data;
using Final_Project_Implements.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Final_Project_Implements.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;


        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _context = context;
            _logger = logger;
        }


        public IActionResult Index()
        {

            var applicationDbContext = _context.Post;
            return View(applicationDbContext.ToList());
            //return View(_context.Post);
        }

        public IActionResult Privacy()
        {
            HomeMv homeMv = new HomeMv()
            {
                //TopPost = _context.Post.Include(p => p.SubCategory).Include(p => p.PostRegion).Include(s => s.Tag).OrderByDescending(n => n.Id).Take(5)
                TopPost = _context.Post.Include(s => s.SubCategory).OrderByDescending(n => n.Id).Take(2),
            };
            return View(homeMv);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}