using ASP.NETCoreIdentityCustom.Core.ViewModels;
using CsvHelper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Globalization;
using System.Security.Claims;
using System.Diagnostics;

namespace ASP.NETCoreIdentityCustom.Controllers
{
    public class DonnesActif : Controller
    {

        [HttpGet]
        public IActionResult Index(List<DonneeActif> donneesActif = null) 
        {
            List<DonneeActif> donneeActifs = donneesActif == donneesActif == null ? new List<DonneeActif>() : donneesActif;
            return View(donneesActif);
            
        }

        [HttpPost]

        public async Task<IActionResult> Index(IFormFile file , [FromServices] Microsoft.AspNetCore.Hosting.IHostingEnvironment hostingEnvironment)
        {

            //string fileName = $"{hostingEnvironment.WebRootPath}\\actif\\{file.FileName}";
            Guid id = Guid.NewGuid();
            var claimsIdentity = (ClaimsIdentity)this.User.Identity;
            var claim = claimsIdentity.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier);
            var userId = claim.Value;
            string filename = file.FileName;
            string uniqueFileName = id + filename;
            string path = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\actif"));

            using (var filestream = new FileStream(Path.Combine(path, uniqueFileName), FileMode.Create)) { await file.CopyToAsync(filestream); }

            using (FileStream fileStream= System.IO.File.Create(filename) )
            {
                file.CopyTo(fileStream);
                fileStream.Flush();
            }
            
            var donneesActif = this.GetActifList(file.FileName);

            return Index(donneesActif); 
        }
        private List<DonneeActif> GetActifList(string fileName)
        {
            List<DonneeActif> donneesActif = new List<DonneeActif>();
            var path = $"{Directory.GetCurrentDirectory()}{@"\wwwroot\actif"}" + "\\" + fileName;
            using (var reader = new StreamReader(path))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                csv.Read();
                csv.ReadHeader();
                while (csv.Read())
                {
                    var donneeActif = csv.GetRecords<DonneeActif>().ToList();
                    Debug.WriteLine("Liste1 : "+ donneeActif);
                }
                return donneesActif;
            }
            //path = $"{Directory.GetCurrentDirectory()}{@"\@wwwroot\ActifTo"}";
            //using (var write = new StreamWriter(path + "\\NewFile.csv"))
            //using (var csv = new CsvWriter(write, CultureInfo.InvariantCulture))
            //{
            //    csv.WriteRecords(donneesActif); 
            //}
            return donneesActif;
        }
   
  
    

    }
}
