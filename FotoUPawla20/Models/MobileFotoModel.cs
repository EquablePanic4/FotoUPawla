using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FotoUPawla20.Models
{
    public class MobileFotoModel
    {
        public string[] TablicaURL { get; set; }

        public string GenerujWidok()
        {
            string Morata = String.Empty;

            foreach (string e in TablicaURL)
                Morata += "<img src='" + e + "' alt='Obraazek przystosowany na urządzenia mobilne' class='MobilePhoto' />";

            return Morata;
        }
    }
}
