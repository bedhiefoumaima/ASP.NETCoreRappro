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
    public class PassifsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PassifsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Passifs
        public async Task<IActionResult> Index()
        {
            return View(await _context.Passifs.ToListAsync());
        }

        // GET: Passifs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var passif = await _context.Passifs
                .FirstOrDefaultAsync(m => m.NumPassif == id);
            if (passif == null)
            {
                return NotFound();
            }

            return View(passif);
        }

        // GET: Passifs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Passifs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(IFormFile file, [Bind("NumPassif")] Passif passif)
        {
            if (ModelState.IsValid)
            {
                _context.Add(passif);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(passif);
        }

        // GET: Passifs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var passif = await _context.Passifs.FindAsync(id);
            if (passif == null)
            {
                return NotFound();
            }
            return View(passif);
        }

        // POST: Passifs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(IFormFile file, [Bind("NumPassif,FichierPassif")] Passif passif)
        {
            {
                {
                    if (file != null)

                    {
                        //int id = actif.NumActif;
                        //string ids = id.ToString();  


                        string filename = file.FileName;
                        string path = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\passif"));
                        using (var filestream = new FileStream(Path.Combine(path, filename), FileMode.Create)) { await file.CopyToAsync(filestream); }
                        passif.FichierPassif = filename;



                        //UseShellExecute = false,
                        //WindowStyle = ProcessWindowStyle.Hidden,
                        //CreateNoWindow = true,
                        //RedirectStandardOutput = true,
                    }
                    _context.Add(passif);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
        }

            // GET: Passifs/Delete/5
            public async Task<IActionResult> Delete(int? id)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var passif = await _context.Passifs
                    .FirstOrDefaultAsync(m => m.NumPassif == id);
                if (passif == null)
                {
                    return NotFound();
                }

                return View(passif);
            }

            // POST: Passifs/Delete/5
            [HttpPost, ActionName("Delete")]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> DeleteConfirmed(int id)
            {
                var passif = await _context.Passifs.FindAsync(id);
                _context.Passifs.Remove(passif);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            private bool PassifExists(int id)
            {
                return _context.Passifs.Any(e => e.NumPassif == id);
            }
        }
    } 
