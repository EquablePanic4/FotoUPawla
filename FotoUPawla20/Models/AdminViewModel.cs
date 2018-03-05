using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FotoUPawla20.Models
{
    public class AdminViewModel
    {
        //Zmienne klasyczne
        public string ZrealizowaniKlienci { get; set; }
        public string OczekujacyKlienci { get; set; }

        //Tablice
        public string[] BanerGalleryDeleteArray { get; set; }
        public string[] MainGalleryDeleteArray { get; set; }
        public string[] PrzygotowaniaGalleryDeleteArray { get; set; }
        public string[] CeremoniaGalleryDeleteArray { get; set; }
        public string[] WeseleGalleryDeleteArray { get; set; }
        public string[] PlenerGalleryDeleteArray { get; set; }

        //Zmienne jednozdjęciowe
        //[0] - adres do zdjęcia, [1] - id galerii (analogicznie od 7 wzwyż)
        public string[] PolyGaleria { get; set; }
        public string[] PolySlubna { get; set; }
        public string[] PolyOferta { get; set; }
        public string[] PolyPakiety { get; set; }
        public string[] PolyOkolicznosciowe { get; set; }
        public string[] PolyOsiemnastki { get; set; }
        public string[] PolyRocznice { get; set; }
        public string[] PolyChrzciny { get; set; }
        public string[] PolyInne { get; set; }
        public string[] PolySklep { get; set; }
        public string[] PolyKontakt { get; set; }
    }
}
