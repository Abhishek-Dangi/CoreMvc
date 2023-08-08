using Final_Project_Implements.Data;
using Final_Project_Implements.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Slugify;

namespace Final_Project_Implements.Controllers
{
    public class PostsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public PostsController(ApplicationDbContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;
        }

        // GET: Posts
        public async Task<IActionResult> Index()
        {
            //take use to get limited data from data base
            //var applicationDbContext = _context.Post.Include(p => p.SubCategory).Take(1);
            var applicationDbContext = _context.Post.Include(p => p.SubCategory);

            //var applicationDbContext = _context.Post.FirstAsync();
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Posts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.PostRegion == null)
            {
                return NotFound();
            }

            var post = await _context.Post
                .Include(p => p.SubCategory)
                .Include(p => p.Tag)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (post == null)
            {
                return NotFound();
            }

            return View(post);
        }

        // GET: Posts/Create
        public IActionResult Create()
        {
            ViewData["SubCategoryId"] = new SelectList(_context.SubCategory, "Id", "Title");
            ViewData["CategoryId"] = new SelectList(_context.Category, "Id", "Title");
            ViewData["RegionId"] = new SelectList(_context.PostRegion, "Id", "Title");
            ViewData["TagId"] = new SelectList(_context.Tag, "Id", "Title");
            Post post = new Post();
            return View(post);
        }

        // POST: Posts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Post post)
        {
            if (ModelState.IsValid)
            {
                if (post.ImageSrc != null)
                {

                    SlugHelper helper = new SlugHelper();
                    string folderpath = "/Images/Post/";
                    string wwwRootPath = _hostEnvironment.WebRootPath;
                    //string fileName = Path.GetFileName(post.ImageSrc.FileName);
                    string fileName = post.Title;

                    //remove spaces between string
                    string slug = helper.GenerateSlug(fileName);

                    string extension = Path.GetExtension(post.ImageSrc.FileName);
                    if (extension != null)
                    {
                        string path = Path.Combine(wwwRootPath + folderpath, string.Concat(slug, extension));
                        //post.ImageUrl = path;

                        post.ImageUrl = folderpath + string.Concat(slug, extension);
                        using (var fileStream = new FileStream(path, FileMode.Create))
                        {
                            //await imageModel.ImageFile.CopyToAsync(fileStream);
                            await post.ImageSrc.CopyToAsync(fileStream);
                        }
                    }
                    //string path = Path.Combine(wwwRootPath+folderpath, fileName);           
                }
                _context.Add(post);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SubCategoryId"] = new SelectList(_context.SubCategory, "Id", "Title", post.SubCategoryId);
            ViewData["TagId"] = new SelectList(_context.Tag, "Id", "Title", post.TagId);
            return View(post);
        }



        // GET: Posts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.PostRegion == null)
            {
                return NotFound();
            }

            var post = await _context.Post.FindAsync(id);
            if (post == null)
            {
                return NotFound();
            }
            ViewData["SubCategoryId"] = new SelectList(_context.SubCategory, "Id", "Title", post.SubCategoryId);
            ViewData["TagId"] = new SelectList(_context.Tag, "Id", "Title", post.TagId);
            return View(post);
        }

        // POST: Posts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,RegionId,SubCategoryId,TagId,MediaTypeEnum,Title,Description,Content")] Post post)
        {
            if (id != post.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(post);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PostExists(post.Id))
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
            ViewData["SubCategoryId"] = new SelectList(_context.SubCategory, "Id", "Title", post.SubCategoryId);
            ViewData["TagId"] = new SelectList(_context.Tag, "Id", "Title", post.TagId);
            return View(post);
        }

        // GET: Posts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.PostRegion == null)
            {
                return NotFound();
            }

            var post = await _context.Post
                .Include(p => p.SubCategory)
                .Include(p => p.Tag)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (post == null)
            {
                return NotFound();
            }

            return View(post);
        }

        // POST: Posts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Post == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Post_1'  is null.");
            }
            var post = await _context.Post.FindAsync(id);
            if (post != null)
            {
                _context.Post.Remove(post);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PostExists(int id)
        {
            return _context.PostRegion.Any(e => e.Id == id);
        }
        //dropdownfillmethod
        public JsonResult getAllCategory()
        {
            var Categoryobj = _context.Category.ToList();
            return new JsonResult(Categoryobj);
        }

        public JsonResult getSubCategoryByCategory(int Id)
        {
            var SubCategoryobj = _context.SubCategory.Where(x => x.CategoryId == Id).ToList();
            return new JsonResult(SubCategoryobj);
        }


        //file upload


    }



}
