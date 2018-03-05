using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FotoUPawla20.Models;
using FotoUPawla20.Models.Database;

namespace FotoUPawla20.Controllers
{
    public class HomeController : Controller
    {

        private CustomModelsContext db;

        public HomeController(CustomModelsContext context)
        {
            db = context;
        }

        /*
         Dane logowania do Imgur:
            Login: fotoupawla (kontakt@codli.eu)
            Hasło: fotoupawla1
            Client ID: ca75ca4c292e7dd
            Client secret: 1e5f620e88600b9c9f31a0c2c4fd1d4b861652b4

            NIESTETY, DO UŻYTKU NIEKOMERCYJNEGO
         */

        public IActionResult Index()
        {
            //URL Przerwy technicznej
            string PrzerwaIMG = "https://i.imgur.com/FiG0ZHG.jpg";

            //Generowanie obrazka startowego
            Random losowyObrazek = new Random();

            var Model = new HomeViewModel();

            //Generowanie skryptu obsługi galerii
            var ListaGalerii = (from a in db.Zdjecia select a).ToList<ZdjeciaModel>();

            /*
                 ---IDENTYFIKATORY POSZCZEGÓLNYCH GALERII---
                 
                 1- Pierwsza galeria (ogólna)
                 2- Galeria ze zdjęciami z przygotowań
                 3- Galeria ze zdjęciami z ceremoni
                 4- Galeria ze zdjęciami z imprezy weselnej
                 5- Galeria ze zdjęciami plenerowymi
                 6- Galeria z obrazkami powitalnymi (baner startowy)
             
             */

            Model.Galeria1 = SilnikGaleriowy(ListaGalerii, 1);
            Model.GaleriaPrzygotowania = SilnikGaleriowy(ListaGalerii, 2);
            Model.GaleriaCeremonia = SilnikGaleriowy(ListaGalerii, 3);
            Model.GaleriaWesele = SilnikGaleriowy(ListaGalerii, 4);
            Model.GaleriaPlener = SilnikGaleriowy(ListaGalerii, 5);
            Model.GaleriaBaner = SilnikGaleriowy(ListaGalerii, 6);

            //Generowanie obrazka startowego cz. 2
            if (Model.GaleriaBaner.Length == 1)
                Model.ObrazekStartowy = Model.GaleriaBaner[0];
            else
            {
                int BanerOptions = Model.GaleriaBaner.Length - 1;
                Model.ObrazekStartowy = Model.GaleriaBaner[losowyObrazek.Next(0, BanerOptions)];
            }

            return View(Model);
        }

        public IActionResult GaleriaMobilna(string Galeria)
        {
            int Nawigator = 0;

            switch (Galeria)
            {
                case "Przygotowania":
                    Nawigator = 2;
                    break;

                case "Ceremonia":
                    Nawigator = 3;
                    break;

                case "Wesele":
                    Nawigator = 4;
                    break;

                case "Plener":
                    Nawigator = 5;
                    break;

                default:
                    Nawigator = 2;
                    break;
            }

            var Model = new MobileFotoModel();
            Model.TablicaURL = TablicaZdjecMobilnych(Nawigator);

            return View(Model);
        }

        private string[] SilnikGaleriowy(List<ZdjeciaModel> WszystkieZdjecia, int GaleriaID)
        {
            var CacheList = (from Mourinho in WszystkieZdjecia where Mourinho.GaleriaId == GaleriaID select Mourinho.Path);
            string PrzerwaIMG = "https://i.imgur.com/FiG0ZHG.jpg";
            string[] tablica;
            int Counter = CacheList.Count();

            if (Counter != 0)
            {
                tablica = new string[Counter];
                int Conte = 0;

                foreach (var i in CacheList)
                {
                    tablica[Conte] = i;
                    Conte++;
                }
            }

            else
            {
                tablica = new string[1];
                tablica[0] = PrzerwaIMG;
            }

            return tablica;
        }

        private string[] TablicaZdjecMobilnych(int GaleriaID)
        {
            string[] array = (from a in db.Zdjecia where a.GaleriaId == GaleriaID select a.Path).ToArray();

            return array;
        }
    }
}
