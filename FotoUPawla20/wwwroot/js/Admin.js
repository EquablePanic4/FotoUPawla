//Usuwanie zdjęcia z galerii, oraz wiersza tabeli w panelu ADM
function AjaxRemovePhoto(CodliSecret, ToRemove) {
    var JSON = { "CodliSecret" : CodliSecret }
    $.ajax({
        type: "POST",
        url: "/Admin/RemovePhoto/",
        data: JSON,
        success: function (data) {
            $(ToRemove).remove();
            alert("Pomyślnie usunięto zdjęcie z galerii!");
        },
        error: function (e) {
            alert("Wystąpił nieznany błąd przy usuwaniu zdjęcia! Czym prędzej skontaktuj się z autorem aplikacji.")
        }
    })
}

function AjaxAddPhoto(idElementu, GaleriaID) {
    //Pobieranie tekstu z inputText
    var inputName = "#" + idElementu;
    var AdresURL = $(inputName).val();

    var JSON = { "AdresURL": AdresURL, "GaleriaID": GaleriaID }
    $.ajax({
        type: "POST",
        url: "/Admin/AddGalleryPhoto/",
        data: JSON,
        success: function (data) {
            //Czyszczenie formularza
            $(inputName).val("");

            alert("Pomyślnie dodano zdjęcie!");
        },
        error: function (e) {
            alert("Wystąpił nieznany błąd przy dodawaniu zdjęcia! Czym prędzej skontaktuj się z autorem aplikacji.")
        }
    })
}