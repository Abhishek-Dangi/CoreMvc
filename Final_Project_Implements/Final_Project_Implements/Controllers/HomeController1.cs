using Final_Project_Implements.Models;
using Microsoft.AspNetCore.Mvc;

namespace Final_Project_Implements.Controllers
{
    public class HomeController1 : Controller
    {
        public IActionResult Index()
        {
            Post post = new Post();
            return View(post);
        }
    }
}
