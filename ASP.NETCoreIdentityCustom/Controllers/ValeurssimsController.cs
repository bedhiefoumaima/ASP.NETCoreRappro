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
    public class ValeurssimsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ValeurssimsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Valeurssims
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Valeurssims.Include(v => v.NumRappNavigation);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Valeurssims/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var valeurssim = await _context.Valeurssims
                .Include(v => v.NumRappNavigation)
                .FirstOrDefaultAsync(m => m.Idvs == id);
            if (valeurssim == null)
            {
                return NotFound();
            }

            return View(valeurssim);
        }

        // GET: Valeurssims/Create
        public IActionResult Create()
        {
            ViewData["NumRapp"] = new SelectList(_context.Rapprochements, "NumRapp", "NumRapp");
            return View();
        }

        // POST: Valeurssims/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idvs,FichierVs,NumRapp")] Valeurssim valeurssim)
        {
            if (ModelState.IsValid)
            {
                _context.Add(valeurssim);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["NumRapp"] = new SelectList(_context.Rapprochements, "NumRapp", "NumRapp", valeurssim.NumRapp);
            return View(valeurssim);
        }

        // GET: Valeurssims/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var valeurssim = await _context.Valeurssims.FindAsync(id);
            if (valeurssim == null)
            {
                return NotFound();
            }
            ViewData["NumRapp"] = new SelectList(_context.Rapprochements, "NumRapp", "NumRapp", valeurssim.NumRapp);
            return View(valeurssim);
        }

        // POST: Valeurssims/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Idvs,FichierVs,NumRapp")] Valeurssim valeurssim)
        {
            if (id != valeurssim.Idvs)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(valeurssim);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ValeurssimExists(valeurssim.Idvs))
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
            ViewData["NumRapp"] = new SelectList(_context.Rapprochements, "NumRapp", "NumRapp", valeurssim.NumRapp);
            return View(valeurssim);
        }

        // GET: Valeurssims/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var valeurssim = await _context.Valeurssims
                .Include(v => v.NumRappNavigation)
                .FirstOrDefaultAsync(m => m.Idvs == id);
            if (valeurssim == null)
            {
                return NotFound();
            }

            return View(valeurssim);
        }

        // POST: Valeurssims/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var valeurssim = await _context.Valeurssims.FindAsync(id);
            _context.Valeurssims.Remove(valeurssim);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ValeurssimExists(int id)
        {
            return _context.Valeurssims.Any(e => e.Idvs == id);
        }
    }
}
