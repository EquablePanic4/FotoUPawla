//Zmienne globalne
var deviceIsMobile = false;

function LoadStartImage() {
    //Wybieranie tła strony powitalnej
    //$('#Start').css('background-image', 'url(../images/home/start'+ GenerujLosowyObrazek().toString() + '.jpeg)');
    var WybranyCytat = "#CytatBox" + GenerujLosowyCytat().toString();
    $(WybranyCytat).css('display', 'block');

    if(/(android|bb\d+|meego).+mobile|avantgo|bada\/|blackberry|blazer|compal|elaine|fennec|hiptop|iemobile|ip(hone|od)|ipad|iris|kindle|Android|Silk|lge |maemo|midp|mmp|netfront|opera m(ob|in)i|palm( os)?|phone|p(ixi|re)\/|plucker|pocket|psp|series(4|6)0|symbian|treo|up\.(browser|link)|vodafone|wap|windows (ce|phone)|xda|xiino/i.test(navigator.userAgent) 
    || /1207|6310|6590|3gso|4thp|50[1-6]i|770s|802s|a wa|abac|ac(er|oo|s\-)|ai(ko|rn)|al(av|ca|co)|amoi|an(ex|ny|yw)|aptu|ar(ch|go)|as(te|us)|attw|au(di|\-m|r |s )|avan|be(ck|ll|nq)|bi(lb|rd)|bl(ac|az)|br(e|v)w|bumb|bw\-(n|u)|c55\/|capi|ccwa|cdm\-|cell|chtm|cldc|cmd\-|co(mp|nd)|craw|da(it|ll|ng)|dbte|dc\-s|devi|dica|dmob|do(c|p)o|ds(12|\-d)|el(49|ai)|em(l2|ul)|er(ic|k0)|esl8|ez([4-7]0|os|wa|ze)|fetc|fly(\-|_)|g1 u|g560|gene|gf\-5|g\-mo|go(\.w|od)|gr(ad|un)|haie|hcit|hd\-(m|p|t)|hei\-|hi(pt|ta)|hp( i|ip)|hs\-c|ht(c(\-| |_|a|g|p|s|t)|tp)|hu(aw|tc)|i\-(20|go|ma)|i230|iac( |\-|\/)|ibro|idea|ig01|ikom|im1k|inno|ipaq|iris|ja(t|v)a|jbro|jemu|jigs|kddi|keji|kgt( |\/)|klon|kpt |kwc\-|kyo(c|k)|le(no|xi)|lg( g|\/(k|l|u)|50|54|\-[a-w])|libw|lynx|m1\-w|m3ga|m50\/|ma(te|ui|xo)|mc(01|21|ca)|m\-cr|me(rc|ri)|mi(o8|oa|ts)|mmef|mo(01|02|bi|de|do|t(\-| |o|v)|zz)|mt(50|p1|v )|mwbp|mywa|n10[0-2]|n20[2-3]|n30(0|2)|n50(0|2|5)|n7(0(0|1)|10)|ne((c|m)\-|on|tf|wf|wg|wt)|nok(6|i)|nzph|o2im|op(ti|wv)|oran|owg1|p800|pan(a|d|t)|pdxg|pg(13|\-([1-8]|c))|phil|pire|pl(ay|uc)|pn\-2|po(ck|rt|se)|prox|psio|pt\-g|qa\-a|qc(07|12|21|32|60|\-[2-7]|i\-)|qtek|r380|r600|raks|rim9|ro(ve|zo)|s55\/|sa(ge|ma|mm|ms|ny|va)|sc(01|h\-|oo|p\-)|sdk\/|se(c(\-|0|1)|47|mc|nd|ri)|sgh\-|shar|sie(\-|m)|sk\-0|sl(45|id)|sm(al|ar|b3|it|t5)|so(ft|ny)|sp(01|h\-|v\-|v )|sy(01|mb)|t2(18|50)|t6(00|10|18)|ta(gt|lk)|tcl\-|tdg\-|tel(i|m)|tim\-|t\-mo|to(pl|sh)|ts(70|m\-|m3|m5)|tx\-9|up(\.b|g1|si)|utst|v400|v750|veri|vi(rg|te)|vk(40|5[0-3]|\-v)|vm40|voda|vulc|vx(52|53|60|61|70|80|81|83|85|98)|w3c(\-| )|webc|whit|wi(g |nc|nw)|wmlb|wonu|x700|yas\-|your|zeto|zte\-/i.test(navigator.userAgent.substr(0,4))) {
        deviceIsMobile = true;
    }
}

function MobileScript_ENGINE() {
    if (deviceIsMobile == false)
    {
        //Jakaś instrukcja
    }
}

function GenerujLosowyObrazek() {
    return Math.floor(Math.random() * (6 - 0 + 1)) + 0;
}

function GenerujLosowyCytat() {
    return Math.floor(Math.random() * (17 - 1 + 1)) + 1;
}

function Show1() {
    //Zachowanie Canvasu
    $('#s1').css('display', 'block');
    $('#s2').css('display', 'none');
    $('#s3').css('display', 'none');
    $('#s4').css('display', 'none');
    
    //Zachowanie wciśniętego przycisku
    $('#s1btn').css('background-color', '#2962FF');
    $('#s1btn').css('font-weight', '400');
    $('#s1btn').disabled = true;

    //Zachowanie pozostałych przycisków
    $('#s2btn').css('background-color', '#3F51B5');
    $('#s2btn').css('font-weight', '300');
    $('#s2btn').disabled = false;

    $('#s3btn').css('background-color', '#3F51B5');
    $('#s3btn').css('font-weight', '300');
    $('#s3btn').disabled = false;

    $('#s4btn').css('background-color', '#3F51B5');
    $('#s4btn').css('font-weight', '300');
    $('#s4btn').disabled = false;
}
function Show2() {
    $('#s2').css('display', 'block');
    $('#s1').css('display', 'none');
    $('#s3').css('display', 'none');
    $('#s4').css('display', 'none');

    //Zachowanie wciśniętego przycisku
    $('#s2btn').css('background-color', '#2962FF');
    $('#s2btn').css('font-weight', '400');
    $('#s2btn').disabled = true;

    //Zachowanie pozostałych przycisków
    $('#s1btn').css('background-color', '#3F51B5');
    $('#s1btn').css('font-weight', '300');
    $('#s1btn').disabled = false;

    $('#s3btn').css('background-color', '#3F51B5');
    $('#s3btn').css('font-weight', '300');
    $('#s3btn').disabled = false;

    $('#s4btn').css('background-color', '#3F51B5');
    $('#s4btn').css('font-weight', '300');
    $('#s4btn').disabled = false;
}
function Show3() {
    $('#s3').css('display', 'block');
    $('#s2').css('display', 'none');
    $('#s1').css('display', 'none');
    $('#s4').css('display', 'none');

    //Zachowanie wciśniętego przycisku
    $('#s3btn').css('background-color', '#2962FF');
    $('#s3btn').css('font-weight', '400');
    $('#s3btn').disabled = true;

    //Zachowanie pozostałych przycisków
    $('#s2btn').css('background-color', '#3F51B5');
    $('#s2btn').css('font-weight', '300');
    $('#s2btn').disabled = false;

    $('#s1btn').css('background-color', '#3F51B5');
    $('#s1btn').css('font-weight', '300');
    $('#s1btn').disabled = false;

    $('#s4btn').css('background-color', '#3F51B5');
    $('#s4btn').css('font-weight', '300');
    $('#s4btn').disabled = false;
}
function Show4() {
    $('#s4').css('display', 'block');
    $('#s2').css('display', 'none');
    $('#s3').css('display', 'none');
    $('#s1').css('display', 'none');

    //Zachowanie wciśniętego przycisku
    $('#s4btn').css('background-color', '#2962FF');
    $('#s4btn').css('font-weight', '400');
    $('#s4btn').disabled = true;

    //Zachowanie pozostałych przycisków
    $('#s2btn').css('background-color', '#3F51B5');
    $('#s2btn').css('font-weight', '300');
    $('#s2btn').disabled = false;

    $('#s3btn').css('background-color', '#3F51B5');
    $('#s3btn').css('font-weight', '300');
    $('#s3btn').disabled = false;

    $('#s1btn').css('background-color', '#3F51B5');
    $('#s1btn').css('font-weight', '300');
    $('#s1btn').disabled = false;
}

//SKLEP

function Show5() {
    $('#sklep1').css('display', 'block');
    $('#sklep2').css('display', 'none');
    $('#sklep3').css('display', 'none');
    $('#sklep4').css('display', 'none');
    $('#sklep5').css('display', 'none');

    //Zachowanie wciśniętego przycisku
    $('#sklep1btn').css('background-color', '#2962FF');
    $('#sklep1btn').css('font-weight', '400');
    $('#sklep1btn').disabled = true;

    //Zachowanie pozostałych przycisków
    $('#sklep2btn').css('background-color', '#3F51B5');
    $('#sklep2btn').css('font-weight', '300');
    $('#sklep2btn').disabled = false;

    $('#sklep3btn').css('background-color', '#3F51B5');
    $('#sklep3btn').css('font-weight', '300');
    $('#sklep3btn').disabled = false;

    $('#sklep4btn').css('background-color', '#3F51B5');
    $('#sklep4btn').css('font-weight', '300');
    $('#sklep4btn').disabled = false;

    $('#sklep5btn').css('background-color', '#3F51B5');
    $('#sklep5btn').css('font-weight', '300');
    $('#sklep5btn').disabled = false;
}

function Show6() {
    $('#sklep2').css('display', 'block');
    $('#sklep1').css('display', 'none');
    $('#sklep3').css('display', 'none');
    $('#sklep4').css('display', 'none');
    $('#sklep5').css('display', 'none');

    //Zachowanie wciśniętego przycisku
    $('#sklep2btn').css('background-color', '#2962FF');
    $('#sklep2btn').css('font-weight', '400');
    $('#sklep2btn').disabled = true;

    //Zachowanie pozostałych przycisków
    $('#sklep1btn').css('background-color', '#3F51B5');
    $('#sklep1btn').css('font-weight', '300');
    $('#sklep1btn').disabled = false;

    $('#sklep3btn').css('background-color', '#3F51B5');
    $('#sklep3btn').css('font-weight', '300');
    $('#sklep3btn').disabled = false;

    $('#sklep4btn').css('background-color', '#3F51B5');
    $('#sklep4btn').css('font-weight', '300');
    $('#sklep4btn').disabled = false;

    $('#sklep5btn').css('background-color', '#3F51B5');
    $('#sklep5btn').css('font-weight', '300');
    $('#sklep5btn').disabled = false;
}

function Show7() {
    $('#sklep3').css('display', 'block');
    $('#sklep2').css('display', 'none');
    $('#sklep1').css('display', 'none');
    $('#sklep4').css('display', 'none');
    $('#sklep5').css('display', 'none');

    //Zachowanie wciśniętego przycisku
    $('#sklep3btn').css('background-color', '#2962FF');
    $('#sklep3btn').css('font-weight', '400');
    $('#sklep3btn').disabled = true;

    //Zachowanie pozostałych przycisków
    $('#sklep2btn').css('background-color', '#3F51B5');
    $('#sklep2btn').css('font-weight', '300');
    $('#sklep2btn').disabled = false;

    $('#sklep1btn').css('background-color', '#3F51B5');
    $('#sklep1btn').css('font-weight', '300');
    $('#sklep1btn').disabled = false;

    $('#sklep4btn').css('background-color', '#3F51B5');
    $('#sklep4btn').css('font-weight', '300');
    $('#sklep4btn').disabled = false;

    $('#sklep5btn').css('background-color', '#3F51B5');
    $('#sklep5btn').css('font-weight', '300');
    $('#sklep5btn').disabled = false;
}

function Show8() {
    $('#sklep4').css('display', 'block');
    $('#sklep2').css('display', 'none');
    $('#sklep3').css('display', 'none');
    $('#sklep1').css('display', 'none');
    $('#sklep5').css('display', 'none');

    //Zachowanie wciśniętego przycisku
    $('#sklep4btn').css('background-color', '#2962FF');
    $('#sklep4btn').css('font-weight', '400');
    $('#sklep4btn').disabled = true;

    //Zachowanie pozostałych przycisków
    $('#sklep2btn').css('background-color', '#3F51B5');
    $('#sklep2btn').css('font-weight', '300');
    $('#sklep2btn').disabled = false;

    $('#sklep3btn').css('background-color', '#3F51B5');
    $('#sklep3btn').css('font-weight', '300');
    $('#sklep3btn').disabled = false;

    $('#sklep1btn').css('background-color', '#3F51B5');
    $('#sklep1btn').css('font-weight', '300');
    $('#sklep1btn').disabled = false;

    $('#sklep5btn').css('background-color', '#3F51B5');
    $('#sklep5btn').css('font-weight', '300');
    $('#sklep5btn').disabled = false;
}

function Show9() {
    $('#sklep5').css('display', 'block');
    $('#sklep2').css('display', 'none');
    $('#sklep3').css('display', 'none');
    $('#sklep4').css('display', 'none');
    $('#sklep1').css('display', 'none');

    //Zachowanie wciśniętego przycisku
    $('#sklep5btn').css('background-color', '#2962FF');
    $('#sklep5btn').css('font-weight', '400');
    $('#sklep5btn').disabled = true;

    //Zachowanie pozostałych przycisków
    $('#sklep2btn').css('background-color', '#3F51B5');
    $('#sklep2btn').css('font-weight', '300');
    $('#sklep2btn').disabled = false;

    $('#sklep3btn').css('background-color', '#3F51B5');
    $('#sklep3btn').css('font-weight', '300');
    $('#sklep3btn').disabled = false;

    $('#sklep4btn').css('background-color', '#3F51B5');
    $('#sklep4btn').css('font-weight', '300');
    $('#sklep4btn').disabled = false;

    $('#sklep1btn').css('background-color', '#3F51B5');
    $('#sklep1btn').css('font-weight', '300');
    $('#sklep1btn').disabled = false;
}

function StartBlock() {
    $("body").ready(function(){
        $("html, body").delay(0).animate({
            scrollTop: $('body').offset().top - 60
        }, 2000, "linear");
    });
}

function Zdjecia() {
    $("#Segment1").ready(function(){
        $("html, body").delay(0).animate({
            scrollTop: $('#Segment1').offset().top + 700 
        }, 2000);
    });
}

function Fotoslub() {
    $("#Segment2").ready(function(){
        $("html, body").delay(0).animate({
            scrollTop: $('#Segment2').offset().top + 700 
        }, 2000);
    });
}

function Oslub() {
    $("#Segment3").ready(function(){
        $("html, body").delay(0).animate({
            scrollTop: $('#Segment3').offset().top + 700 
        }, 2000);
    });
}

function StartScroll() {
    $("body").ready(function(){
        $("html, body").delay(0).animate({
            scrollTop: $('body').offset().top
        }, 2000);
    });
}

function Ofoto() {
    $("#Segment4").ready(function(){
        $("html, body").delay(0).animate({
            scrollTop: $('#Segment4').offset().top + 700 
        }, 2000);
    });
}

function Osklep() {
    $("#Segment5").ready(function(){
        $("html, body").delay(0).animate({
            scrollTop: $('#Segment5').offset().top + 700 
        }, 2000);
    });
}

function Kont() {
    $("#Segment6").ready(function(){
        $("html, body").delay(0).animate({
            scrollTop: $('#Segment6').offset().top + 700 
        }, 2000);
    });
}

$(document).ready(function(){
    $('#OfertaBoxMini').slick({
        infinite: true,
        slidesToShow: 1,
        slidesToScroll: 1,
        prevArrow: $('#Slick1L'),
        nextArrow: $('#Slick1R'),
        initialSlide: 1
    });
});

$(document).ready(function(){
    $('#ImprezyOkolicznosciowe').slick({
        infinite: true,
        slidesToShow: 1,
        slidesToScroll: 1,
        prevArrow: $('#Slick2L'),
        nextArrow: $('#Slick2R'),
        initialSlide: 1
    });
});