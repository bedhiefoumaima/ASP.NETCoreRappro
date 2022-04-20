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
    public class RapprochementsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RapprochementsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Rapprochements
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Rapprochements.Include(r => r.IdNavigation).Include(r => r.NumActifNavigation).Include(r => r.NumPassifNavigation);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Rapprochements/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rapprochement = await _context.Rapprochements
                .Include(r => r.IdNavigation)
                .Include(r => r.NumActifNavigation)
                .Include(r => r.NumPassifNavigation)
                .FirstOrDefaultAsync(m => m.NumRapp == id);
            if (rapprochement == null)
            {
                return NotFound();
            }

            return View(rapprochement);
        }

        // GET: Rapprochements/Create
        public IActionResult Create()
        {
            ViewData["Id"] = new SelectList(_context.Users, "Id", "Id");
            ViewData["NumActif"] = new SelectList(_context.Actifs, "NumActif", "NumActif");
            ViewData["NumPassif"] = new SelectList(_context.Passifs, "NumPassif", "NumPassif");
            return View();
        }

        // POST: Rapprochements/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NumRapp,DateRapp,Id,NumActif,NumPassif,FichierRapp")] Rapprochement rapprochement)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rapprochement);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Id"] = new SelectList(_context.Users, "Id", "Id", rapprochement.Id);
            ViewData["NumActif"] = new SelectList(_context.Actifs, "NumActif", "NumActif", rapprochement.NumActif);
            ViewData["NumPassif"] = new SelectList(_context.Passifs, "NumPassif", "NumPassif", rapprochement.NumPassif);
            return View(rapprochement);
        }

        // GET: Rapprochements/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rapprochement = await _context.Rapprochements.FindAsync(id);
            if (rapprochement == null)
            {
                return NotFound();
            }
            ViewData["Id"] = new SelectList(_context.Users, "Id", "Id", rapprochement.Id);
            ViewData["NumActif"] = new SelectList(_context.Actifs, "NumActif", "NumActif", rapprochement.NumActif);
            ViewData["NumPassif"] = new SelectList(_context.Passifs, "NumPassif", "NumPassif", rapprochement.NumPassif);
            return View(rapprochement);
        }

        // POST: Rapprochements/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("NumRapp,DateRapp,Id,NumActif,NumPassif,FichierRapp")] Rapprochement rapprochement)
        {
            if (id != rapprochement.NumRapp)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rapprochement);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RapprochementExists(rapprochement.NumRapp))
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
            ViewData["Id"] = new SelectList(_context.Users, "Id", "Id", rapprochement.Id);
            ViewData["NumActif"] = new SelectList(_context.Actifs, "NumActif", "NumActif", rapprochement.NumActif);
            ViewData["NumPassif"] = new SelectList(_context.Passifs, "NumPassif", "NumPassif", rapprochement.NumPassif);
            return View(rapprochement);
        }

        // GET: Rapprochements/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rapprochement = await _context.Rapprochements
                .Include(r => r.IdNavigation)
                .Include(r => r.NumActifNavigation)
                .Include(r => r.NumPassifNavigation)
                .FirstOrDefaultAsync(m => m.NumRapp == id);
            if (rapprochement == null)
            {
                return NotFound();
            }

            return View(rapprochement);
        }

        // POST: Rapprochements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rapprochement = await _context.Rapprochements.FindAsync(id);
            _context.Rapprochements.Remove(rapprochement);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RapprochementExists(int id)
        {
            return _context.Rapprochements.Any(e => e.NumRapp == id);
        }
    }
}
