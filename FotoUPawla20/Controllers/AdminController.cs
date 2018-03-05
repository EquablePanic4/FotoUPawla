using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using FotoUPawla20.Models.Database;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;
using FotoUPawla20.Models;
using CodliDevelopment;
using System.Net.Mail;
using System.Net;

namespace FotoUPawla20.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        public string PrzerwaGalerii = "https://i.imgur.com/FiG0ZHG.jpg";

        private CustomModelsContext db;

        public AdminController(CustomModelsContext context)
        {
            db = context;
        }

        //AKCJE

        public IActionResult Index()
        {
            char q = '"';

            //Model do zwrócenia
            var AdminView = new AdminViewModel();

            //Oczekujący klienci
            var ListaOczekujacych = new List<KlienciModel>(from a in db.Klienci where a.Zrealizowano == false select a);

            if (ListaOczekujacych.Count() == 0)
                AdminView.OczekujacyKlienci = "</table><h3 class='alert'>Brak oczekujących klientów!</h3>";
            else
            {
                foreach (var element in ListaOczekujacych)
                {
                    AdminView.OczekujacyKlienci += "<tr><td>" + element.Nazwa + "</td>";
                    AdminView.OczekujacyKlienci += "<td class='TabelkaOpisInside'>" + element.Tytul + "</td>";
                    AdminView.OczekujacyKlienci += "<td>" + TimeX.DateIntToReadableString(element.Data) + "</td>";
                    AdminView.OczekujacyKlienci += "<td>" + element.Telefon + "</td></tr><tr><td colspan='4' class='borderRow1'><form id='FormularzRealizacjiKlienta" + element.KlienciModelId + "' method='POST' class='NonBorderForm' data-ajax='true' data-ajax-method='POST' data-ajax-loading='#LoadingDIV' data-ajax-update='#LinkReply' name='CompleteClientForm' action='/Admin/CompleteClient'><input type='number' name='idKlienta' style='display: none;' value='";
                    AdminView.OczekujacyKlienci += element.KlienciModelId + "' /><input type='text' name='urlAdres' placeholder='Adres bezprośredni do zdjęć'/><input type='submit' value='Zatwierdź' /></form></td></tr>";
                }

                AdminView.OczekujacyKlienci += "</table>";
            }

            //Zrealizowani klienci
            var ListaZrealizowanych = new List<KlienciModel>(from a in db.Klienci where a.Zrealizowano == true orderby a.KlienciModelId descending select a);

            if (ListaZrealizowanych.Count() == 0)
                AdminView.ZrealizowaniKlienci = "</table><h3 class='alert'>Brak zrealizowanych klientów!</h3>";
            else
            {
                int Courtois = 0;

                foreach (var element in ListaZrealizowanych)
                {
                    AdminView.ZrealizowaniKlienci += "<tr><td>" + element.Nazwa + "</td>";
                    AdminView.ZrealizowaniKlienci += "<td>" + element.Tytul + "</td>";
                    AdminView.ZrealizowaniKlienci += "<td>" + TimeX.IntDateToSmartString(element.Data) + "</td>";
                    AdminView.ZrealizowaniKlienci += "<td>" + element.Telefon + "</td>";
                    AdminView.ZrealizowaniKlienci += "<td>" + element.KodKlienta + "</td>";
                    AdminView.ZrealizowaniKlienci += "<td>" + element.KlienciModelId + "</td></tr>";

                    Courtois++;

                    if (Courtois == 5)
                        break;
                }

                AdminView.ZrealizowaniKlienci += "</table>";
            }

            //Generowanie sekcji usuwania zdjęć
            var AllPhotos = (from b in db.Zdjecia select b).ToList<ZdjeciaModel>();

            AdminView.MainGalleryDeleteArray = GeneratorUsuwaczaZdjec(AllPhotos, 1);
            AdminView.PrzygotowaniaGalleryDeleteArray = GeneratorUsuwaczaZdjec(AllPhotos, 2);
            AdminView.CeremoniaGalleryDeleteArray = GeneratorUsuwaczaZdjec(AllPhotos, 3);
            AdminView.WeseleGalleryDeleteArray = GeneratorUsuwaczaZdjec(AllPhotos, 4);
            AdminView.PlenerGalleryDeleteArray = GeneratorUsuwaczaZdjec(AllPhotos, 5);
            AdminView.BanerGalleryDeleteArray = GeneratorUsuwaczaZdjec(AllPhotos, 6);

            //Generowanie sekcji zdjęć pojedynczych
            AdminView.PolyGaleria = GeneratorUsuwaczaZdjec(AllPhotos, 7);
            AdminView.PolySlubna = GeneratorUsuwaczaZdjec(AllPhotos, 8);
            AdminView.PolyOferta = GeneratorUsuwaczaZdjec(AllPhotos, 9);
            AdminView.PolyPakiety = GeneratorUsuwaczaZdjec(AllPhotos, 10);
            AdminView.PolyOkolicznosciowe = GeneratorUsuwaczaZdjec(AllPhotos, 11);
            AdminView.PolyOsiemnastki = GeneratorUsuwaczaZdjec(AllPhotos, 12);
            AdminView.PolyRocznice = GeneratorUsuwaczaZdjec(AllPhotos, 13);
            AdminView.PolyChrzciny = GeneratorUsuwaczaZdjec(AllPhotos, 14);
            AdminView.PolyInne = GeneratorUsuwaczaZdjec(AllPhotos, 15);
            AdminView.PolySklep = GeneratorUsuwaczaZdjec(AllPhotos, 16);
            AdminView.PolyKontakt = GeneratorUsuwaczaZdjec(AllPhotos, 17);
            //I trzeba tutaj dopisać całą resztę z AdminViewModelu

            return View(AdminView);
        }

        [HttpPost]
        public IActionResult AddNewClient(string ClientName, string PhotosDate, string TaskTitle, string ClientEmail, string ClientPhone)
        {
            var NowyKlient = new KlienciModel();
            NowyKlient.Nazwa = ClientName;
            NowyKlient.Telefon = ClientPhone;
            NowyKlient.Tytul = TaskTitle;

            //Generowanie poprawnej daty
            string[] DataArray = PhotosDate.Split('-');

            int Conte = 0;

            while (Conte != 3)
            {
                if (DataArray[Conte].Length == 1)
                {
                    DataArray[Conte] = "0" + DataArray[Conte];
                }

                Conte++;
            }

            Conte = 2;
            string CodliDate = String.Empty;

            while (Conte >= 0)
            {
                CodliDate += DataArray[Conte];

                Conte--;
            }

            NowyKlient.Data = int.Parse(CodliDate);

            //Dodawanie adresu e-mail
            if (String.IsNullOrEmpty(ClientEmail) == true)
                NowyKlient.Email = "SHNull";
            else
                NowyKlient.Email = ClientEmail;

            //Jako że jest to nowy klient, jego zamówienie nie zostało jeszcze zrealizowane
            NowyKlient.Zrealizowano = false;

            //Dodawanie rekordu do bazy danych
            //var kontekst = new CustomModelsContext(DbContextOptions<CustomModelsContext> context);

            //kontekst.Klienci.Add(NowyKlient);
            //kontekst.SaveChanges();

            db.Klienci.Add(NowyKlient);
            db.SaveChanges();

                return Content("Dodano nowego klienta <script>$('#AddClientForm').reset();</script>");
        }

        [HttpPost]
        public IActionResult CompleteClient(int idKlienta, string urlAdres)
        {
            KlienciModel zlecenie = (from a in db.Klienci where a.KlienciModelId == idKlienta select a).First();

            zlecenie.AdresZdjec = urlAdres;
            zlecenie.Zrealizowano = true;
            zlecenie.KodKlienta = GenerujKodUsera();

            db.Klienci.Update(zlecenie);
            db.SaveChanges();

            if (zlecenie.Email != "SHNull")
            {
                //Wysyłanie e-maila z kodem do pobrania zdjęć
                SmtpClient client = new SmtpClient("mail.codli.eu"); //Domyślnie dla mojego hostingu
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential("adres e-mail", "Hasło");
                client.Port = 8889;

                MailMessage mailMessage = new MailMessage();
                mailMessage.From = new MailAddress("Nadawca");
                mailMessage.To.Add(zlecenie.Email);
                mailMessage.Body = "Twój kod klienta: " + zlecenie.KodKlienta;
                mailMessage.Subject = "Twoje zdjęcia są gotowe do pobrania!";
                client.Send(mailMessage);
            }

            return Content("Wykonano!");
        }

        [HttpPost]
        public IActionResult AddGalleryPhoto(string AdresURL, int GaleriaID)
        {
            //Jeżeli do metody trafiają zdjęcia z galerii jednozdjęciowych
            if (GaleriaID >= 7)
            {
                var MonoPhoto = (from codli in db.Zdjecia where codli.GaleriaId == GaleriaID select codli).FirstOrDefault();

                //Jeżeli jeszcze nie ma zdjęcia
                if (MonoPhoto == null)
                {
                    MonoPhoto = new ZdjeciaModel();

                    MonoPhoto.Path = AdresURL;
                    MonoPhoto.GaleriaId = GaleriaID;

                    db.Add(MonoPhoto);
                    db.SaveChanges();

                    return Content("Wykonano!");
                }

                MonoPhoto.Path = AdresURL;

                db.Update(MonoPhoto);
                db.SaveChanges();

                return Content("Wykonano!");
            }

            //Tworzenie obiektu rekordu LINQ
            var obiekt = new ZdjeciaModel()
            {
                GaleriaId = GaleriaID,
                Path = AdresURL
            };

            db.Zdjecia.Add(obiekt);
            db.SaveChanges();

            return Content("Wykonano!");
        }

        [HttpPost]
        public IActionResult RemovePhoto(string CodliSecret)
        {
            //Budowa zmiennej sekretnej
            /* ID_Galeri_#Codli-Secret#_ID_Zdjęcia */
            string[] array = VariableX.SplitStringByString(CodliSecret, "#Codli-Secret#");

            var zdjecie = (from c in db.Zdjecia where c.ZdjeciaModelId == int.Parse(array[1]) select c).FirstOrDefault<ZdjeciaModel>();

            db.Remove(zdjecie);
            db.SaveChanges();

            return Content("Wykonano!");
        }

        //METODY

        private string GenerujKodUsera()
        {
            var data = new DateTime();
            data = DateTime.Now;

            //Generowanie stringa liczbowego
            string rok = data.Year.ToString();
            string msc = data.Month.ToString();
            if (msc.Length == 1)
                msc = "0" + msc;
            string dzien = data.Day.ToString();
            if (dzien.Length == 1)
                dzien = "0" + dzien;
            string godz = data.Hour.ToString();
            if (godz.Length == 1)
                godz = "0" + godz;
            string min = data.Minute.ToString();
            if (min.Length == 1)
                min = "0" + min;
            string sek = data.Second.ToString();
            if (sek.Length == 1)
                sek = "0" + sek;

            //Generowanie zakodowanego kodu na podstawie daty jego wygenerowania
            string sekwencja = rok + msc + dzien + godz + min + sek;
            string kod = String.Empty;

            foreach (char e in sekwencja)
            {
                switch (e)
                {
                    case '0':
                        kod += 'Y';
                        break;

                    case '1':
                        kod += 'T';
                        break;

                    case '2':
                        kod += 'V';
                        break;

                    case '3':
                        kod += 'K';
                        break;

                    case '4':
                        kod += 'E';
                        break;

                    case '5':
                        kod += 'J';
                        break;

                    case '6':
                        kod += 'W';
                        break;

                    case '7':
                        kod += 'G';
                        break;

                    case '8':
                        kod += 'B';
                        break;

                    case '9':
                        kod += 'D';
                        break;
                }
            }

            return kod;
        }

        private string[] GeneratorUsuwaczaZdjec(List<ZdjeciaModel> WszystkieFoty, int GaleriaID)
        {
            /*
             *      OZNACZENIA GALERII
             * 1) Galeria główna
             * 2) Galeria przygotowania
             * 3) Galeria ceremonialna
             * 4) Galeria weselna
             * 5) Galeria plenerowa
             * 6) Zdjęcia baneru powitalnego
             * 7+) Zdjęcia CodliMono
             */

            //Specjalna instrukcja jeżeli chodzi o zdjęcie CodliPoli
            if (GaleriaID >= 7)
            {
                string PhotoURL = (from codli in WszystkieFoty where codli.GaleriaId == GaleriaID select codli.Path).FirstOrDefault();

                if (String.IsNullOrEmpty(PhotoURL) == true)
                    PhotoURL = PrzerwaGalerii;

                string[] CodliReturns = new string[2] { PhotoURL, GaleriaID.ToString() };

                return CodliReturns;
            }

            char q = '"';
            var MainGalleryDeleteList = (from b in WszystkieFoty where b.GaleriaId == GaleriaID select b).ToList<ZdjeciaModel>();
            string[] Tablica = new string[MainGalleryDeleteList.Count()];

            int Conte = 0;

            while (Conte != MainGalleryDeleteList.Count())
            {
                Tablica[Conte] += "<tr id='Remove1PhotoGallery" + MainGalleryDeleteList[Conte].ZdjeciaModelId + "'><td><img src='";
                Tablica[Conte] += MainGalleryDeleteList[Conte].Path;
                Tablica[Conte] += "' alt='Miniaturka zdjęcia' class='dwiesciepxPhoto' /></td><td><button onClick=" + q + "AjaxRemovePhoto('" + MainGalleryDeleteList[Conte].GaleriaId + "#Codli-Secret#" + MainGalleryDeleteList[Conte].ZdjeciaModelId + "', " + "'" + "#Remove1PhotoGallery" + MainGalleryDeleteList[Conte].ZdjeciaModelId + "'" + ")" + q + ">Usuń</button></td>";

                Conte++;
            }

            return Tablica;
        }
    }
}