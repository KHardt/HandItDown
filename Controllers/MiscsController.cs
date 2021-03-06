﻿using System;
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
    public class MiscsController : Controller
    {
        private readonly ApplicationDbContext _context;

        private readonly UserManager<ApplicationUser> _userManager;

        public MiscsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            _context = context;
        }
        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);


        // GET: Miscs
        public async Task<IActionResult> Index()
        {
            var user = await GetCurrentUserAsync();

            var applicationDbContext = _context.Misc
                .Include(c => c.User)
                .Include(s => s.Status)
                .Where(t => t.UserId == user.Id);

            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Miscs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var misc = await _context.Misc
                .Include(m => m.Status)
                .Include(m => m.User)
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

            ViewData["StatusId"] = new SelectList(_context.Statuses, "StatusId", "Label");
            ViewData["UserId"] = new SelectList(_context.ApplicationUsers, "Id", "Id");
            return View();
        }

        // POST: Miscs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MiscId,Description,Quantity,Color,UserId,ImagePath,StatusId")] Misc misc)
        {

            ModelState.Remove("User");
            ModelState.Remove("UserId");

            if (ModelState.IsValid)
            {
                var user = await GetCurrentUserAsync();
                misc.User = user;
                misc.UserId = user.Id;
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
            ViewData["StatusId"] = new SelectList(_context.Statuses, "StatusId", "Label", misc.StatusId);
            ViewData["UserId"] = new SelectList(_context.ApplicationUsers, "Id", "Id", misc.UserId);
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
            ModelState.Remove("UserId");
            ModelState.Remove("User");

            if (ModelState.IsValid)
            {

                var user = await GetCurrentUserAsync();
                misc.User = user;
                misc.UserId = user.Id;

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
            ViewData["StatusId"] = new SelectList(_context.Statuses, "StatusId", "Label", misc.StatusId);
            ViewData["UserId"] = new SelectList(_context.ApplicationUsers, "Id", "Id", misc.UserId);
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
