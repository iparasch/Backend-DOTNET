using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjDAW.Data;
using ProjDAW.Models;

namespace ProjDAW.Controllers
{
    public class ForHomesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ForHomesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ForHomes
        public async Task<IActionResult> Index()
        {
            return View(await _context.ForHomes.ToListAsync());
        }

        // GET: ForHomes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var forHome = await _context.ForHomes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (forHome == null)
            {
                return NotFound();
            }

            return View(forHome);
        }

        // GET: ForHomes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ForHomes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Type,Quantity")] ForHome forHome)
        {
            if (ModelState.IsValid)
            {
                _context.Add(forHome);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(forHome);
        }

        // GET: ForHomes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var forHome = await _context.ForHomes.FindAsync(id);
            if (forHome == null)
            {
                return NotFound();
            }
            return View(forHome);
        }

        // POST: ForHomes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Type,Quantity")] ForHome forHome)
        {
            if (id != forHome.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(forHome);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ForHomeExists(forHome.Id))
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
            return View(forHome);
        }

        // GET: ForHomes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var forHome = await _context.ForHomes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (forHome == null)
            {
                return NotFound();
            }

            return View(forHome);
        }

        // POST: ForHomes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var forHome = await _context.ForHomes.FindAsync(id);
            _context.ForHomes.Remove(forHome);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ForHomeExists(int id)
        {
            return _context.ForHomes.Any(e => e.Id == id);
        }
    }
}
