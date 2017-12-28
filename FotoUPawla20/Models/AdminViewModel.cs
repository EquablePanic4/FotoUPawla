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
        public string[] MainGalleryDeleteArray { get; set; }
        public string[] PrzygotowaniaGalleryDeleteArray { get; set; }
        public string[] CeremoniaGalleryDeleteArray { get; set; }
        public string[] WeseleGalleryDeleteArray { get; set; }
        public string[] PlenerGalleryDeleteArray { get; set; }
    }
}
