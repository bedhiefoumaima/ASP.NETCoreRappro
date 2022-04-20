using System;
using System.Collections.Generic;
using ASP.NETCoreIdentityCustom.Core.ViewModels;

#nullable disable

namespace Rappro.Data
{
    public partial class Valeurssim
    {
        public int Idvs { get; set; }
        public string FichierVs { get; set; }
        public int? NumRapp { get; set; }

        public virtual Rapprochement NumRappNavigation { get; set; }
    }
}
