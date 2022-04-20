using System;
using System.Collections.Generic;
using ASP.NETCoreIdentityCustom.Areas.Identity.Data;

#nullable disable

namespace Rappro.Data
{
    public partial class Rapprochement
    {
        public Rapprochement()
        {
            Valeursnonsims = new HashSet<Valeursnonsim>();
            Valeurssims = new HashSet<Valeurssim>();
        }

        public int NumRapp { get; set; }
        public DateTime? DateRapp { get; set; }
        public string? Id  { get; set; }
        public int? NumActif { get; set; }
        public int? NumPassif { get; set; }
        public string FichierRapp { get; set; }

        public virtual Actif NumActifNavigation { get; set; }
        public virtual Passif NumPassifNavigation { get; set; }
        public virtual ApplicationUser IdNavigation { get; set; }
        public virtual ICollection<Valeursnonsim> Valeursnonsims { get; set; }
        public virtual ICollection<Valeurssim> Valeurssims { get; set; }
    }
}
