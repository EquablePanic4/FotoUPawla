using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FotoUPawla20.Models
{
    public class HomeViewModel
    {
        //Właściwości
        public string ObrazekStartowy { get; set; }

        public string[] Galeria1 { get; set; }

        public string[] GaleriaPrzygotowania { get; set; }

        public string[] GaleriaCeremonia { get; set; }

        public string[] GaleriaWesele { get; set; }

        public string[] GaleriaPlener { get; set; }


        //Metody generujące skrypty
        public string SkryptGalerii1()
        {
            string skrypt = String.Empty;
            char q = '"';
            int Conte = 0;

            while (Conte != Galeria1.Length)
            {
                skrypt += q + Galeria1[Conte] + q;

                if (Conte != (Galeria1.Length - 1))
                    skrypt += ',';

                Conte++;
            }

            return skrypt;
        }

        public string SkryptGaleriiPrzygotowania()
        {
            string skrypt = String.Empty;
            char q = '"';
            int Conte = 0;

            while (Conte != GaleriaPrzygotowania.Length)
            {
                skrypt += q + GaleriaPrzygotowania[Conte] + q;

                if (Conte != (GaleriaPrzygotowania.Length - 1))
                    skrypt += ',';

                Conte++;
            }

            return skrypt;
        }

        public string SkryptGaleriiCeremonia()
        {
            string skrypt = String.Empty;
            char q = '"';
            int Conte = 0;

            while (Conte != GaleriaCeremonia.Length)
            {
                skrypt += q + GaleriaCeremonia[Conte] + q;

                if (Conte != (GaleriaCeremonia.Length - 1))
                    skrypt += ',';

                Conte++;
            }

            return skrypt;
        }

        public string SkryptGaleriiWesele()
        {
            string skrypt = String.Empty;
            char q = '"';
            int Conte = 0;

            while (Conte != GaleriaWesele.Length)
            {
                skrypt += q + GaleriaWesele[Conte] + q;

                if (Conte != (GaleriaWesele.Length - 1))
                    skrypt += ',';

                Conte++;
            }

            return skrypt;
        }

        public string SkryptGaleriiPlener()
        {
            string skrypt = String.Empty;
            char q = '"';
            int Conte = 0;

            while (Conte != GaleriaPlener.Length)
            {
                skrypt += q + GaleriaPlener[Conte] + q;

                if (Conte != (GaleriaPlener.Length - 1))
                    skrypt += ',';

                Conte++;
            }

            return skrypt;
        }


        //Pozostałe metody
        public int LiczbaZdjecWGalerii1()
        {
            return Galeria1.Length - 1;
        }

        public int LiczbaZdjecWGaleriiPrzygotowania()
        {
            return GaleriaPrzygotowania.Length - 1;
        }

        public int LiczbaZdjecWGaleriiCeremonia()
        {
            return GaleriaCeremonia.Length - 1;
        }

        public int LiczbaZdjecWGaleriiWesele()
        {
            return GaleriaWesele.Length - 1;
        }

        public int LiczbaZdjecWGaleriiPlener()
        {
            return GaleriaPlener.Length - 1;
        }
    }
}
