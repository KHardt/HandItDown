using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HandItDown.Data;
using HandItDown.Models;

namespace HandItDown.Controllers
{
    public class MiscsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MiscsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Miscs
        public async Task<IActionResult> Index()
        {
            return View(await _context.Misc.ToListAsync());
        }

        // GET: Miscs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var misc = await _context.Misc
                .FirstOrDefaultAsync(m => m.MiscId == id);
            if (misc == null)
            {
                return NotFound();
            }

            return View(misc);
        }

        // GET: Miscs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Miscs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MiscId,Description,Quantity,Color,UserId,ImagePath,StatusId")] Misc misc)
        {
            if (ModelState.IsValid)
            {
                _context.Add(misc);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(misc);
        }

        // GET: Miscs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var misc = await _context.Misc.FindAsync(id);
            if (misc == null)
            {
                return NotFound();
            }
            return View(misc);
        }

        // POST: Miscs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MiscId,Description,Quantity,Color,UserId,ImagePath,StatusId")] Misc misc)
        {
            if (id != misc.MiscId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(misc);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MiscExists(misc.MiscId))
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
            return View(misc);
        }

        // GET: Miscs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var misc = await _context.Misc
                .FirstOrDefaultAsync(m => m.MiscId == id);
            if (misc == null)
            {
                return NotFound();
            }

            return View(misc);
        }

        // POST: Miscs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var misc = await _context.Misc.FindAsync(id);
            _context.Misc.Remove(misc);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MiscExists(int id)
        {
            return _context.Misc.Any(e => e.MiscId == id);
        }
    }
}
