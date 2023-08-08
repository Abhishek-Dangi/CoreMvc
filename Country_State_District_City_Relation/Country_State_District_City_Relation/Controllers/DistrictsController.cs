using Country_State_District_City_Relation.Data;
using Country_State_District_City_Relation.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Country_State_District_City_Relation.Controllers
{
    public class DistrictsController : Controller
    {
        private readonly ApplicationDbContext _context;
        //private readonly ApplicationDbContext _contextForCountry;

        public DistrictsController(ApplicationDbContext context)
        {
            _context = context;
            //_contextForCountry = contextForCountry;
        }

        // GET: Districts
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.District.Include(d => d.State).ThenInclude(s => s.Country);
            //var applicationDbContext1 = _contextForCountry.Country.Include(c => c.Title);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Districts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.District == null)
            {
                return NotFound();
            }

            var district = await _context.District
                .Include(d => d.State)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (district == null)
            {
                return NotFound();
            }

            return View(district);
        }

        // GET: Districts/Create
        public IActionResult Create()
        {
            ViewData["StateId"] = new SelectList(_context.State, "Id", "Title");
            ViewData["CountryId"] = new SelectList(_context.Country, "Id", "Title");
            return View();
        }

        // POST: Districts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,StateId,DisplayOrder,Description,IsActive")] District district)
        {
            if (ModelState.IsValid)
            {
                _context.Add(district);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["StateId"] = new SelectList(_context.State, "Id", "Title", district.StateId);
            return View(district);
        }

        // GET: Districts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.District == null)
            {
                return NotFound();
            }

            var district = await _context.District.FindAsync(id);
            if (district == null)
            {
                return NotFound();
            }
            ViewData["StateId"] = new SelectList(_context.State, "Id", "Title", district.StateId);
            ViewData["CountryId"] = new SelectList(_context.Country, "Id", "Title", district.CountryId);
            return View(district);
        }

        // POST: Districts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,StateId,DisplayOrder,Description,IsActive")] District district)
        {
            if (id != district.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(district);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DistrictExists(district.Id))
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
            ViewData["StateId"] = new SelectList(_context.State, "Id", "Title", district.StateId);
            return View(district);
        }

        // GET: Districts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.District == null)
            {
                return NotFound();
            }

            var district = await _context.District
                .Include(d => d.State)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (district == null)
            {
                return NotFound();
            }

            return View(district);
        }

        // POST: Districts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.District == null)
            {
                return Problem("Entity set 'ApplicationDbContext.District'  is null.");
            }
            var district = await _context.District.FindAsync(id);
            if (district != null)
            {
                _context.District.Remove(district);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DistrictExists(int id)
        {
            return _context.District.Any(e => e.Id == id);
        }

    }
}
