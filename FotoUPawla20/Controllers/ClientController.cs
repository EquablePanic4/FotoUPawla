using Microsoft.AspNetCore.Mvc;
using FotoUPawla20.Models;
using FotoUPawla20.Models.Database;
using System.Linq;

namespace FotoUPawla20.Controllers
{
    public class ClientController : Controller
    {
        private CustomModelsContext db;

        public ClientController(CustomModelsContext context)
        {
            db = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult WalidujKodKlienta(string KodKlienta)
        {
            var response = new StringModel();
            string Success = "<h1 id='H2PobieranieInfo'>Pobieranie rozpocznie się automatycznie po wciśnięciu przycisku.</h1><script>$('#FormularzKlienta').remove();$('#StrefaKlientaInfo').remove();</script>";
            string Error = "<h2>Wystąpił nieznany błąd, sprawdź poprawność kodu i spróbuj ponownie!</h2>";

            //Szukanie klucza w bazie danych
            var encja = (from a in db.Klienci where a.KodKlienta == KodKlienta select a).ToList();

            if (encja.Count() != 1)
                response.QueryString = Error;
            else
            {
                //Budowanie linku
                string link = "<a href='";
                link += encja[0].AdresZdjec;
                link += "'>Pobierz</a>";

                //Budowanie odpowiedzi
                response.QueryString = Success + link;
            }

            return PartialView("_PartialStrefaKlienta", response);
        }
    }
}