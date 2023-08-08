using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyPrecticesCatSabcat.Data;
using MyPrecticesCatSabcat.Models;

namespace MyPrecticesCatSabcat.Areas.Admin.Controllers
{
    [Area("admin")]
    public class testsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public testsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/tests
        //[Route("index")]
        public async Task<IActionResult> Index()
        {
            return View(await _context.test.ToListAsync());
        }

        // GET: Admin/tests/Details/5
        //[Route("details/{id}")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.test == null)
            {
                return NotFound();
            }

            var test = await _context.test
                .FirstOrDefaultAsync(m => m.Id == id);
            if (test == null)
            {
                return NotFound();
            }

            return View(test);
        }

        // GET: Admin/tests/Create
        //[Route("create")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/tests/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,IsActive")] test test)
        {
            if (ModelState.IsValid)
            {
                _context.Add(test);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(test);
        }

        // GET: Admin/tests/Edit/5
        //[Route("edit/{id}")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.test == null)
            {
                return NotFound();
            }

            var test = await _context.test.FindAsync(id);
            if (test == null)
            {
                return NotFound();
            }
            return View(test);
        }

        // POST: Admin/tests/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //[Route("edit/{id}")]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,IsActive")] test test)
        {
            if (id != test.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(test);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!testExists(test.Id))
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
            return View(test);
        }

        // GET: Admin/tests/Delete/5
        //[Route("delete/{id}")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.test == null)
            {
                return NotFound();
            }

            var test = await _context.test
                .FirstOrDefaultAsync(m => m.Id == id);
            if (test == null)
            {
                return NotFound();
            }

            return View(test);
        }

        // POST: Admin/tests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        //[Route("delete/{id}")]

        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.test == null)
            {
                return Problem("Entity set 'ApplicationDbContext.test'  is null.");
            }
            var test = await _context.test.FindAsync(id);
            if (test != null)
            {
                _context.test.Remove(test);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool testExists(int id)
        {
            return _context.test.Any(e => e.Id == id);
        }
    }
}
