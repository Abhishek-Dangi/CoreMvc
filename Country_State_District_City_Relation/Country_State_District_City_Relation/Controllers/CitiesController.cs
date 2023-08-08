using Country_State_District_City_Relation.Data;
using Country_State_District_City_Relation.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Country_State_District_City_Relation.Controllers
{
    public class CitiesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CitiesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Cities
        public async Task<IActionResult> Index()
        {
            //List<Country> country = new List<Country>();
            //List<State> state = new List<State>();

            var applicationDbContext = _context.City.Include(c => c.District).ThenInclude(s => s.State).ThenInclude(c => c.Country);


            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Cities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.City == null)
            {
                return NotFound();
            }

            var city = await _context.City
                .Include(c => c.District)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (city == null)
            {
                return NotFound();
            }

            return View(city);
        }

        // GET: Cities/Create
        public IActionResult Create()
        {
            ViewData["DistrictId"] = new SelectList(_context.District, "Id", "Title");
            ViewData["CountryId"] = new SelectList(_context.Country, "Id", "Title");

            return View();
        }

        // POST: Cities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,DistrictId,DisplayOrder,Description,IsActive")] City city)
        {
            if (ModelState.IsValid)
            {
                _context.Add(city);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DistrictId"] = new SelectList(_context.District, "Id", "Title", city.DistrictId);
            return View(city);
        }

        // GET: Cities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.City == null)
            {
                return NotFound();
            }

            var city = await _context.City.FindAsync(id);
            if (city == null)
            {
                return NotFound();
            }
            ViewData["DistrictId"] = new SelectList(_context.District, "Id", "Title", city.DistrictId);
            ViewData["CountryId"] = new SelectList(_context.Country, "Id", "Title");

            return View(city);
        }

        // POST: Cities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,DistrictId,DisplayOrder,Description,IsActive")] City city)
        {
            if (id != city.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(city);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CityExists(city.Id))
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
            ViewData["DistrictId"] = new SelectList(_context.District, "Id", "Title", city.DistrictId);
            return View(city);
        }

        // GET: Cities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.City == null)
            {
                return NotFound();
            }

            var city = await _context.City
                .Include(c => c.District)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (city == null)
            {
                return NotFound();
            }

            return View(city);
        }

        // POST: Cities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.City == null)
            {
                return Problem("Entity set 'ApplicationDbContext.City'  is null.");
            }
            var city = await _context.City.FindAsync(id);
            if (city != null)
            {
                _context.City.Remove(city);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CityExists(int id)
        {
            return _context.City.Any(e => e.Id == id);
        }
        public JsonResult getAllCountry()
        {
            var C = _context.Country.ToList();
            return new JsonResult(C);
        }

        public JsonResult getStateByCountry(int Id)
        {
            var S = _context.State.Where(x => x.CountryId == Id).ToList();
            return new JsonResult(S);
        }

        // for state and district mapping
        public JsonResult getAllState()
        {
            var state = _context.State.ToList();
            return new JsonResult(state);
        }

        public JsonResult getDistrictByState(int Id)
        {
            var district = _context.District.Where(x => x.StateId == Id).ToList();
            return new JsonResult(district);
        }
    }
}
