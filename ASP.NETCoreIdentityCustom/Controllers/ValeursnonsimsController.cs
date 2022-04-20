#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ASP.NETCoreIdentityCustom.Areas.Identity.Data;
using Rappro.Data;

namespace ASP.NETCoreIdentityCustom.Controllers
{
    public class ValeursnonsimsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ValeursnonsimsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Valeursnonsims
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Valeursnonsims.Include(v => v.NumRappNavigation);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Valeursnonsims/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var valeursnonsim = await _context.Valeursnonsims
                .Include(v => v.NumRappNavigation)
                .FirstOrDefaultAsync(m => m.Idvns == id);
            if (valeursnonsim == null)
            {
                return NotFound();
            }

            return View(valeursnonsim);
        }

        // GET: Valeursnonsims/Create
        public IActionResult Create()
        {
            ViewData["NumRapp"] = new SelectList(_context.Rapprochements, "NumRapp", "NumRapp");
            return View();
        }

        // POST: Valeursnonsims/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idvns,FichierVns,NumRapp")] Valeursnonsim valeursnonsim)
        {
            if (ModelState.IsValid)
            {
                _context.Add(valeursnonsim);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["NumRapp"] = new SelectList(_context.Rapprochements, "NumRapp", "NumRapp", valeursnonsim.NumRapp);
            return View(valeursnonsim);
        }

        // GET: Valeursnonsims/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var valeursnonsim = await _context.Valeursnonsims.FindAsync(id);
            if (valeursnonsim == null)
            {
                return NotFound();
            }
            ViewData["NumRapp"] = new SelectList(_context.Rapprochements, "NumRapp", "NumRapp", valeursnonsim.NumRapp);
            return View(valeursnonsim);
        }

        // POST: Valeursnonsims/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Idvns,FichierVns,NumRapp")] Valeursnonsim valeursnonsim)
        {
            if (id != valeursnonsim.Idvns)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(valeursnonsim);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ValeursnonsimExists(valeursnonsim.Idvns))
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
            ViewData["NumRapp"] = new SelectList(_context.Rapprochements, "NumRapp", "NumRapp", valeursnonsim.NumRapp);
            return View(valeursnonsim);
        }

        // GET: Valeursnonsims/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var valeursnonsim = await _context.Valeursnonsims
                .Include(v => v.NumRappNavigation)
                .FirstOrDefaultAsync(m => m.Idvns == id);
            if (valeursnonsim == null)
            {
                return NotFound();
            }

            return View(valeursnonsim);
        }

        // POST: Valeursnonsims/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var valeursnonsim = await _context.Valeursnonsims.FindAsync(id);
            _context.Valeursnonsims.Remove(valeursnonsim);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ValeursnonsimExists(int id)
        {
            return _context.Valeursnonsims.Any(e => e.Idvns == id);
        }
    }
}
