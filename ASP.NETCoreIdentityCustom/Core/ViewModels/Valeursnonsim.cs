using System;
using System.Collections.Generic;
using ASP.NETCoreIdentityCustom.Core.ViewModels;

#nullable disable

namespace Rappro.Data
{
    public partial class Valeursnonsim
    {
        public int Idvns { get; set; }
        public string FichierVns { get; set; }
        public int? NumRapp { get; set; }

        public virtual Rapprochement NumRappNavigation { get; set; }
    }
}
