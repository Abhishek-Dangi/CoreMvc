using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Final_Project_Implements.Data;
using Final_Project_Implements.Areas.Admin.Models;

namespace Final_Project_Implements.Controllers
{
    public class PostRegionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PostRegionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PostRegions
        public async Task<IActionResult> Index()
        {
              return View(await _context.PostRegion.ToListAsync());
        }

        // GET: PostRegions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.PostRegion == null)
            {
                return NotFound();
            }

            var postRegion = await _context.PostRegion
                .FirstOrDefaultAsync(m => m.Id == id);
            if (postRegion == null)
            {
                return NotFound();
            }

            return View(postRegion);
        }

        // GET: PostRegions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PostRegions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Description,IsActive")] PostRegion postRegion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(postRegion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(postRegion);
        }

        // GET: PostRegions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.PostRegion == null)
            {
                return NotFound();
            }

            var postRegion = await _context.PostRegion.FindAsync(id);
            if (postRegion == null)
            {
                return NotFound();
            }
            return View(postRegion);
        }

        // POST: PostRegions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description,IsActive")] PostRegion postRegion)
        {
            if (id != postRegion.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(postRegion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PostRegionExists(postRegion.Id))
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
            return View(postRegion);
        }

        // GET: PostRegions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.PostRegion == null)
            {
                return NotFound();
            }

            var postRegion = await _context.Post
                .FirstOrDefaultAsync(m => m.Id == id);
            if (postRegion == null)
            {
                return NotFound();
            }

            return View(postRegion);
        }

        // POST: PostRegions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Post == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Post'  is null.");
            }
            var postRegion = await _context.Post.FindAsync(id);
            if (postRegion != null)
            {
                _context.Post.Remove(postRegion);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PostRegionExists(int id)
        {
          return _context.Post.Any(e => e.Id == id);
        }
    }
}
