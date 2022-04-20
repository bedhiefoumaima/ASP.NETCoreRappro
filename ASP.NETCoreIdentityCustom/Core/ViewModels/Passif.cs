using System;
using System.Collections.Generic;
using ASP.NETCoreIdentityCustom.Core.ViewModels; 

#nullable disable

namespace Rappro.Data
{
    public partial class Passif
    {
        public Passif()
        {
            Rapprochements = new HashSet<Rapprochement>();
        }

        public int NumPassif { get; set; }
        public string FichierPassif { get; set; }

        public virtual ICollection<Rapprochement> Rapprochements { get; set; }
    }
}
