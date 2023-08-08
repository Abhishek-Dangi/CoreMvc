using Final_Project_Implements.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Final_Project_Implements.Components
{
    public class TestViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext _context;

        public TestViewComponent(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(await _context.Category.ToListAsync());
        }
    }
}
