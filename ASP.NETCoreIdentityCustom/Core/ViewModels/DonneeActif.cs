

using CsvHelper.Configuration.Attributes;

namespace ASP.NETCoreIdentityCustom.Core.ViewModels
{
    public class DonneeActif
    {
        //[Index(0)]
        //public string DateValorisation { get; set; } = "";

        //[Index(1)]

        //public string AliasPortefeuille { get; set; } = "";

        //[Index(2)]

        //public string CodeValeur { get; set; } = "";

        //[Index(3)]

        //public string PlaceCotationValeur { get; set; } = "";


        //[Index(4)]

        //public string QuantitStock { get; set; } = "";


        //[Index(5)]

        //public string ValeurBoursi { get; set; } = "";

        //[Index(6)]

        //public string Gestionnaire { get; set; } = "";

        //[Index(7)]


        //public string LibellGroupePortefeuille { get; set; } = "";


        //[Index(8)]

        //public string LibellLongPortefeuille { get; set; } = "";


        //[Index(9)]

        //public string LibellSteGstion { get; set; } = "";


        //[Index(10)]

        //public string LibellLongGstion { get; set; } = "";

        [Index(0)]
        public string UserName { get; set; } = "";

        [Index(1)]
        public string EmailID { get; set; } = "";

        [Index(2)]
        public string MobileNumber { get; set; } = "";

        [Index(3)]
        public string Age { get; set; } = "";

        [Index(4)]
        public string Salary { get; set; } = "";
        [Index(5)]

        public string Gender { get; set; } = "";





    }
}
