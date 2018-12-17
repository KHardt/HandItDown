using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HandItDown.Data;
using HandItDown.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace HandItDown.Controllers
{
    [Authorize]
    public class ClothingsController : Controller
    {
        private readonly ApplicationDbContext _context;

        private readonly UserManager<ApplicationUser> _userManager;

        public ClothingsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            _context = context;
        }
        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);


        // GET: Clothings
        public async Task<IActionResult> Index()
        {
            var user = await GetCurrentUserAsync();

            var applicationDbContext = _context.Clothing
                .Include(c => c.User)
                .Where(t => t.UserId == user.Id);

            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Clothings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clothing = await _context.Clothing
                .Include(c => c.ClothingType)
                .Include(c => c.Status)
                .Include(c => c.User)
                .FirstOrDefaultAsync(m => m.ClothingId == id);
            if (clothing == null)
            {
                return NotFound();
            }

            return View(clothing);
        }

        // GET: Clothings/Create
        public IActionResult Create()
        {
            ViewData["ClothingTypeId"] = new SelectList(_context.ClothingType, "ClothingTypeId", "Label");
            ViewData["StatusId"] = new SelectList(_context.Statuses, "StatusId", "Label");
            ViewData["UserId"] = new SelectList(_context.ApplicationUsers, "Id", "Id");
            return View();
        }

        // POST: Clothings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ClothingId,Description,Quantity,Size,Color,UserId,ImagePath,StatusId,ClothingTypeId")] Clothing clothing)
        {
            ModelState.Remove("User");
            ModelState.Remove("UserId");

            if (ModelState.IsValid)
            {
                var user = await GetCurrentUserAsync();
                clothing.User = user;
                clothing.UserId = user.Id;
                _context.Add(clothing);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClothingTypeId"] = new SelectList(_context.ClothingType, "ClothingTypeId", "Label", clothing.ClothingTypeId);
            ViewData["StatusId"] = new SelectList(_context.Statuses, "StatusId", "Label", clothing.StatusId);
            ViewData["UserId"] = new SelectList(_context.ApplicationUsers, "Id", "Id", clothing.UserId);
            return View(clothing);
        }

        // GET: Clothings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clothing = await _context.Clothing.FindAsync(id);
            if (clothing == null)
            {
                return NotFound();
            }
            ViewData["ClothingTypeId"] = new SelectList(_context.ClothingType, "ClothingTypeId", "Label", clothing.ClothingTypeId);
            ViewData["StatusId"] = new SelectList(_context.Statuses, "StatusId", "Label", clothing.StatusId);
            ViewData["UserId"] = new SelectList(_context.ApplicationUsers, "Id", "Id", clothing.UserId);
            return View(clothing);
        }

        // POST: Clothings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ClothingId,Description,Quantity,Size,Color,UserId,ImagePath,StatusId,ClothingTypeId")] Clothing clothing)
        {
            if (id != clothing.ClothingId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(clothing);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClothingExists(clothing.ClothingId))
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
            ViewData["ClothingTypeId"] = new SelectList(_context.ClothingType, "ClothingTypeId", "Label", clothing.ClothingTypeId);
            ViewData["StatusId"] = new SelectList(_context.Statuses, "StatusId", "Label", clothing.StatusId);
            ViewData["UserId"] = new SelectList(_context.ApplicationUsers, "Id", "Id", clothing.UserId);
            return View(clothing);
        }

        // GET: Clothings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clothing = await _context.Clothing
                .Include(c => c.ClothingType)
                .Include(c => c.Status)
                .Include(c => c.User)
                .FirstOrDefaultAsync(m => m.ClothingId == id);
            if (clothing == null)
            {
                return NotFound();
            }

            return View(clothing);
        }

        // POST: Clothings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var clothing = await _context.Clothing.FindAsync(id);
            _context.Clothing.Remove(clothing);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClothingExists(int id)
        {
            return _context.Clothing.Any(e => e.ClothingId == id);
        }
    }
}
