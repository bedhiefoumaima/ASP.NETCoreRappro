#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Rappro.Data;
using System.Diagnostics;
using ASP.NETCoreIdentityCustom.Areas.Identity.Data;


namespace ASP.NETCoreIdentityCustom.Controllers
{
    public class ActifsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ActifsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Actifs
        public async Task<IActionResult> Index()
        {
            return View(await _context.Actifs.ToListAsync());
        }

        // GET: Actifs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var actif = await _context.Actifs
                .FirstOrDefaultAsync(m => m.NumActif == id);
            if (actif == null)
            {
                return NotFound();
            }

            return View(actif);
        }

        // GET: Actifs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Actifs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(IFormFile file, [Bind("NumActif")] Actif actif)
        {

            {
                if (file != null)

                {
                    //int id = actif.NumActif;
                    //string ids = id.ToString();  


                    string filename = file.FileName;
                    string path = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\actif"));
                    using (var filestream = new FileStream(Path.Combine(path, filename), FileMode.Create)) { await file.CopyToAsync(filestream); }
                    actif.FichierActif = filename;

                    ProcessStartInfo StartInfo = new ProcessStartInfo();
                    Process proRaymark = new Process();

                    StartInfo.UseShellExecute = true;
                    StartInfo.FileName = "rapp_0.1\\rapp\\rapp_run.bat";
                    proRaymark = Process.Start(StartInfo);

                    //UseShellExecute = false,
                    //WindowStyle = ProcessWindowStyle.Hidden,
                    //CreateNoWindow = true,
                    //RedirectStandardOutput = true,
                }
                _context.Add(actif);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));



            }

        }

        // GET: Actifs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var actif = await _context.Actifs.FindAsync(id);
            if (actif == null)
            {
                return NotFound();
            }
            return View(actif); 
        }
        // POST: Actifs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(IFormFile file, int id, [Bind("NumActif,FichierActif")] Actif actif)
        {
            if (file != null)
            {
                string filename = file.FileName;
                string path = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\actif"));
                using (var filestream = new FileStream(Path.Combine(path, filename), FileMode.Create)) { await file.CopyToAsync(filestream); }
                actif.FichierActif = filename;
            }


            _context.Update(actif);
            await _context.SaveChangesAsync();


            return RedirectToAction(nameof(Index));

        }

        // GET: Actifs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var actif = await _context.Actifs
                .FirstOrDefaultAsync(m => m.NumActif == id);
            if (actif == null)
            {
                return NotFound();
            }

            return View(actif);
        }

        // POST: Actifs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var actif = await _context.Actifs.FindAsync(id);
            _context.Actifs.Remove(actif);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ActifExists(int id)
        {
            return _context.Actifs.Any(e => e.NumActif == id);
        }
    }
}
