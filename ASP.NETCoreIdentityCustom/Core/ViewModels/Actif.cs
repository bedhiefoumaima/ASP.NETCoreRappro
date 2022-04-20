using System;
using System.Collections.Generic;
using ASP.NETCoreIdentityCustom.Core.ViewModels;

#nullable disable

namespace Rappro.Data
{
    public partial class Actif
    {
        public Actif()
        {
            Rapprochements = new HashSet<Rapprochement>();
        }

        public int NumActif { get; set; }
        public string FichierActif { get; set; }

        public virtual ICollection<Rapprochement> Rapprochements { get; set; }
    }
}
