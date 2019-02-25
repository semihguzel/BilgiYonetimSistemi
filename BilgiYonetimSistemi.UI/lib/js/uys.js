//AJAX LOADER----------------------------------------------------------

$(document).ready(function () {
    $(document).ajaxStart(function () {
        $("#page-container").showLoading();
    });
    $(document).ajaxStop(function () {
        $("#page-container").hideLoading();
    });
});

//GLOBAL DEĞİŞKENLER---------------------------------------------------

var UYS_DATATABLE_LAST_SELECTED_PAGE = 0;
var UYS_DATATABLE_DATA_LENGTH = 0;

var UYS_SUB_DATATABLE_LAST_SELECTED_PAGE = 0;
var UYS_SUB_DATATABLE_DATA_LENGTH = 0;
var UYS_DATATABLE_PAGE_COUNT = 0;
//FONKSİYONLAR----------------------------------------------------------

//1. Datatable

//function uys_build_sub_pagination(parentId, pageCapacity, dataCount) {

//    //UYS_DATATABLE_LAST_SELECTED_PAGE = 2011;

//    UYS_DATATABLE_LAST_SELECTED_PAGE --;
//    var pageCount = Math.ceil(dataCount / pageCapacity);

//    var htmlResult = '<ul id="pager" class="pagination pagination-sm pull-right" count="' + pageCount + '">';

//    if (UYS_DATATABLE_LAST_SELECTED_PAGE > 0) { htmlResult += '<li class="sub-pager-item"><a href="#" data-page="' + (UYS_DATATABLE_LAST_SELECTED_PAGE ) + '">&lt;&lt;</a></li>'; };
//    if (UYS_DATATABLE_LAST_SELECTED_PAGE - 2 > 0) { htmlResult += '<li class="sub-pager-item"><a href="#" data-page="1">1</a></li>'; }
//    if (UYS_DATATABLE_LAST_SELECTED_PAGE - 3 > 0) { htmlResult += '<li class="sub-pager-item"><a href="#">...</a></li>'; }
//    if (UYS_DATATABLE_LAST_SELECTED_PAGE - 1 > 0) { htmlResult += '<li class="sub-pager-item"><a href="#" data-page="' + (UYS_DATATABLE_LAST_SELECTED_PAGE - 1) + '">' + (UYS_DATATABLE_LAST_SELECTED_PAGE - 1) + '</a></li>'; }
//    if (UYS_DATATABLE_LAST_SELECTED_PAGE > 0) { htmlResult += '<li class="sub-pager-item"><a href="#" data-page="' + (UYS_DATATABLE_LAST_SELECTED_PAGE) + '">' + (UYS_DATATABLE_LAST_SELECTED_PAGE) + '</a></li>'; };
//    htmlResult += '<li class="pager-item"><a href="#">' + (UYS_DATATABLE_LAST_SELECTED_PAGE + 1) + '</a></li>';
//    if (UYS_DATATABLE_LAST_SELECTED_PAGE + 1 < pageCount) { htmlResult += '<li class="sub-pager-item"><a href="#" data-page="' + (UYS_DATATABLE_LAST_SELECTED_PAGE + 2) + '">' + (UYS_DATATABLE_LAST_SELECTED_PAGE + 2) + '</a></li>'; }
//    if (UYS_DATATABLE_LAST_SELECTED_PAGE + 2 < pageCount) { htmlResult += '<li class="sub-pager-item"><a href="#" data-page="' + (UYS_DATATABLE_LAST_SELECTED_PAGE + 3) + '">' + (UYS_DATATABLE_LAST_SELECTED_PAGE + 3) + '</a></li>'; }
//    if (UYS_DATATABLE_LAST_SELECTED_PAGE + 4 < pageCount) { htmlResult += '<li class="sub-pager-item"><a href="#">...</a></li>'; }
//    if (UYS_DATATABLE_LAST_SELECTED_PAGE + 3 < pageCount) { htmlResult += '<li class="sub-pager-item"><a href="#" data-page="' + (pageCount) + '">' + pageCount + '</a></li>'; }
//    if (UYS_DATATABLE_LAST_SELECTED_PAGE + 1 < pageCount) { htmlResult += '<li class="sub-pager-item"><a href="#" data-page="' + (UYS_DATATABLE_LAST_SELECTED_PAGE + 2) + '">&gt;&gt;</a></li>'; }
//    htmlResult += '</ul>';

//    $('#' + parentId).append(htmlResult);
//}


function uys_build_pagination(parentId, pageCapacity, dataCount) {

    UYS_DATATABLE_LAST_SELECTED_PAGE = 1;
    var pageCount = Math.ceil(dataCount / pageCapacity);

    var htmlResult = '';

    var ul_open = '<ul id="pager" class="pagination pagination-sm pull-right" count="' + pageCount + '">';
    var ul_close = '</ul>';
    var ul_body = '';

    var left_arrow = '<li class="pager-item left-arrow disabled" ><a href="#"><i class="fa fa-angle-double-left"></i></a></li>';
    var right_arrow = '<li class="pager-item right-arrow"><a href="#"><i class="fa fa-angle-double-right"></i></a></li>';

    ul_body += left_arrow;
    ul_body += '<li class="pager-item active"><a href="#">1</a></li>';

    for (var i = 2; i <= pageCount; i++) {
        ul_body += '<li class="pager-item"><a href="#">' + i + '</a></li>';
    }

    ul_body += right_arrow;

    htmlResult += ul_open + ul_body + ul_close;

    $('#' + parentId).append(htmlResult);
}

function uys_build_sub_paginationForHareket(parentId, pageCapacity, dataCount) {

    var pageCount = Math.ceil(dataCount / pageCapacity);

    var htmlResult = '';

    var ul_open = '<ul id="sub_pager" class="pagination pagination-sm pull-right" count="' + pageCount + '">';
    var ul_close = '</ul>';
    var ul_body = '';

    var left_arrow = '<li class="sub-pager-item left-arrow" ><a href="#"><i class="fa fa-angle-double-left"></i></a></li>';
    var right_arrow = '<li class="sub-pager-item right-arrow"><a href="#"><i class="fa fa-angle-double-right"></i></a></li>';

    ul_body += left_arrow;
    var selectedPage = 0;
    if (parseInt(UYS_SUB_DATATABLE_LAST_SELECTED_PAGE) == 0) {
        selectedPage = 1;

    }
    UYS_DATATABLE_PAGE_COUNT = pageCount;
    if (pageCount <= 10) {
        for (var i = 1; i <= pageCount; i++) {
            if (i == selectedPage) {
                ul_body += '<li class="sub-pager-item active"><a href="#">' + i + '</a></li>';
            }
            else if (i == parseInt(UYS_SUB_DATATABLE_LAST_SELECTED_PAGE)) {
                ul_body += '<li class="sub-pager-item active"><a href="#">' + i + '</a></li>';
            }
            else {
                ul_body += '<li class="sub-pager-item"><a href="#">' + i + '</a></li>';
            }

        }
    }
    else {
        for (var i = parseInt(UYS_SUB_DATATABLE_LAST_SELECTED_PAGE); i <= parseInt(UYS_SUB_DATATABLE_LAST_SELECTED_PAGE) + 10; i++) {
            if (parseInt(UYS_SUB_DATATABLE_LAST_SELECTED_PAGE) == 0 && i == 0) {
                continue;
            }
            else if (parseInt(UYS_SUB_DATATABLE_LAST_SELECTED_PAGE) == 0 && i == 1) {
                ul_body += '<li class="sub-pager-item active"><a href="#">' + i + '</a></li>';
                continue;
            }
            else if (parseInt(UYS_SUB_DATATABLE_LAST_SELECTED_PAGE) + 10 > parseInt(UYS_DATATABLE_PAGE_COUNT) && parseInt(UYS_SUB_DATATABLE_LAST_SELECTED_PAGE) != parseInt(UYS_DATATABLE_PAGE_COUNT)) {
                ul_body += '<li class="sub-pager-item active"><a href="#">' + parseInt(UYS_SUB_DATATABLE_LAST_SELECTED_PAGE) + '</a></li>';
                for (var j = parseInt(UYS_SUB_DATATABLE_LAST_SELECTED_PAGE) + 1; j <= parseInt(UYS_DATATABLE_PAGE_COUNT); j++) { ul_body += '<li class="sub-pager-item"><a href="#">' + j + '</a></li>'; }

                break;
            }
            else if (parseInt(UYS_SUB_DATATABLE_LAST_SELECTED_PAGE) == parseInt(UYS_DATATABLE_PAGE_COUNT)) {
                for (var j = parseInt(UYS_SUB_DATATABLE_LAST_SELECTED_PAGE) - 10; j < (parseInt(UYS_SUB_DATATABLE_LAST_SELECTED_PAGE)); j++) { ul_body += '<li class="sub-pager-item"><a href="#">' + j + '</a></li>'; }
                ul_body += '<li class="sub-pager-item active"><a href="#">' + j + '</a></li>';
                break;
            }
            else if (i == parseInt(UYS_SUB_DATATABLE_LAST_SELECTED_PAGE)) {
                ul_body += '<li class="sub-pager-item active"><a href="#">' + i + '</a></li>';
            }

            else {
                ul_body += '<li class="sub-pager-item"><a href="#">' + i + '</a></li>';
            }

        }
    }

    ul_body += right_arrow;

    htmlResult += ul_open + ul_body + ul_close;

    $('#' + parentId).append(htmlResult);
}

function uys_click_pager_item(obj) {

    var jelement = $(obj);
    var count = $('#pager').attr('count'); //Gelen verinin toplam uzunluğunu alıyorum, count attribute üne gömdüm

    var lastActiveElement = $('#pager > li.active').get(0); //Butona basılmadan önce seçili olan elementi alıyorum

    if (jelement.hasClass("left-arrow")) {
        jelement = $(lastActiveElement).prev(); //Sol oka basıldıysa sol taraftaki elemente git
    }
    else if (jelement.hasClass("right-arrow")) {
        jelement = $(lastActiveElement).next(); //Sağ oka basıldıysa sağ taraftaki elemente git
    }

    var clickVal = jelement.children('a').get(0).text; //Basıldıktan sonraki sayfa numarasını al

    if (clickVal != null && clickVal != '') { //Eğer basıldıktan sonra bir sayfa numarası dönüyor ise

        UYS_DATATABLE_LAST_SELECTED_PAGE = clickVal;

        $('#pager > li').removeClass("active");
        jelement.addClass("active");

        $('#pager > *').removeClass('disabled');

        if (clickVal == 1) {
            $('#pager > .left-arrow').addClass('disabled');
        }
        else if (clickVal == count) {
            $('#pager > .right-arrow').addClass('disabled');
        }
    }
}
function uys_build_sub_pagination(parentId, pageCapacity, dataCount) {

    UYS_SUB_DATATABLE_LAST_SELECTED_PAGE = 1;
    var pageCount = Math.ceil(dataCount / pageCapacity);

    var htmlResult = '';

    var ul_open = '<ul id="sub_pager" class="pagination pagination-sm pull-right" count="' + pageCount + '">';
    var ul_close = '</ul>';
    var ul_body = '';

    var left_arrow = '<li class="sub-pager-item left-arrow disabled" ><a href="#"><i class="fa fa-angle-double-left"></i></a></li>';
    var right_arrow = '<li class="sub-pager-item right-arrow"><a href="#"><i class="fa fa-angle-double-right"></i></a></li>';

    ul_body += left_arrow;
    ul_body += '<li class="sub-pager-item active"><a href="#">1</a></li>';

    for (var i = 2; i <= pageCount; i++) {
        ul_body += '<li class="sub-pager-item"><a href="#">' + i + '</a></li>';
    }

    ul_body += right_arrow;

    htmlResult += ul_open + ul_body + ul_close;

    $('#' + parentId).append(htmlResult);
}


function uys_click_sub_pager_item(obj) {

    var jelement = $(obj);
    var count = $('#sub_pager').attr('count'); //Gelen verinin toplam uzunluğunu alıyorum, count attribute üne gömdüm

    var lastActiveElement = $('#sub_pager > li.active').get(0); //Butona basılmadan önce seçili olan elementi alıyorum

    if (jelement.hasClass("left-arrow")) {
        jelement = $(lastActiveElement).prev(); //Sol oka basıldıysa sol taraftaki elemente git
    }
    else if (jelement.hasClass("right-arrow")) {
        jelement = $(lastActiveElement).next(); //Sağ oka basıldıysa sağ taraftaki elemente git
    }

    var clickVal = jelement.children('a').get(0).text; //Basıldıktan sonraki sayfa numarasını al

    if (clickVal != null && clickVal != '') { //Eğer basıldıktan sonra bir sayfa numarası dönüyor ise

        UYS_SUB_DATATABLE_LAST_SELECTED_PAGE = clickVal;

        $('#sub_pager > li').removeClass("active");
        jelement.addClass("active");

        $('#sub_pager > *').removeClass('disabled');

        if (clickVal == 1) {
            $('#sub_pager > .left-arrow').addClass('disabled');
        }
        else if (clickVal == count) {
            $('#sub_pager > .right-arrow').addClass('disabled');
        }
    }
}

function uys_click_sub_pager_itemForHareket(obj) {

    var jelement = $(obj);
    var count = $('#sub_pager').attr('count'); //Gelen verinin toplam uzunluğunu alıyorum, count attribute üne gömdüm

    var lastActiveElement = $('#sub_pager > li.active').get(0); //Butona basılmadan önce seçili olan elementi alıyorum

    if (jelement.hasClass("left-arrow")) {
        UYS_SUB_DATATABLE_LAST_SELECTED_PAGE = 1;
        //jelement = $(lastActiveElement).prev(); //Sol oka basıldıysa sol taraftaki elemente git
    }
    else if (jelement.hasClass("right-arrow")) {
        UYS_SUB_DATATABLE_LAST_SELECTED_PAGE = UYS_DATATABLE_PAGE_COUNT;
        //  jelement = $(lastActiveElement).next(); //Sağ oka basıldıysa sağ taraftaki elemente git
    }

    var clickVal = jelement.children('a').get(0).text; //Basıldıktan sonraki sayfa numarasını al

    if (clickVal != null && clickVal != '' && !isNaN(clickVal)) { //Eğer basıldıktan sonra bir sayfa numarası dönüyor ise

        UYS_SUB_DATATABLE_LAST_SELECTED_PAGE = clickVal;

        $('#sub_pager > li').removeClass("active");
        jelement.addClass("active");

        $('#sub_pager > *').removeClass('disabled');

        //if (clickVal == 1) {
        //    $('#sub_pager > .left-arrow').addClass('disabled');
        //}
        //else if (clickVal == count) {
        //    $('#sub_pager > .right-arrow').addClass('disabled');
        //}
    }
}

function uys_reset_selected_page(val) {
    UYS_DATATABLE_LAST_SELECTED_PAGE = val;
}

function uys_reset_sub_selected_page(val) {
    UYS_SUB_DATATABLE_LAST_SELECTED_PAGE = val;
}

function uys_set_page_number(selectedVal) {
    var count = $('#pager').attr('count');

    if (count >= selectedVal) {
        UYS_DATATABLE_LAST_SELECTED_PAGE = selectedVal;

        $('#pager > li').removeClass("active");

        $('#pager > *').removeClass('disabled');

        if (selectedVal == 1) {
            $('#pager > .left-arrow').addClass('disabled');
        }
        else if (selectedVal == count) {
            $('#pager > .right-arrow').addClass('disabled');
        }

        var elementList = $("li.pager-item");
        console.log(elementList);

        $.each(elementList, function (i) {
            if (i == selectedVal) {
                console.log(elementList);
                $(elementList[i]).addClass("active");
            }
        });
    }
}

function uys_set_sub_page_number(selectedVal) {
    UYS_SUB_DATATABLE_LAST_SELECTED_PAGE = selectedVal;

    var count = $('#sub_pager').attr('count');

    if (count >= selectedVal) {
        UYS_DATATABLE_LAST_SELECTED_PAGE = selectedVal;

        $('#sub_pager > li').removeClass("active");

        $('#sub_pager > *').removeClass('disabled');

        if (selectedVal == 1) {
            $('#sub_pager > .left-arrow').addClass('disabled');
        }
        else if (selectedVal == count) {
            $('#sub_pager > .right-arrow').addClass('disabled');
        }

        var elementList = $("li.sub-pager-item");
        console.log(elementList);

        $.each(elementList, function (i) {
            if (i == selectedVal) {
                console.log(elementList);
                $(elementList[i]).addClass("active");
            }
        });
    }
}

//2. Notify

function uys_show_notify(title, type, text, sure) {
    $.pnotify({
        title: title,
        type: type,
        text: text,
        delay: sure
    });
    $("div.ui-pnotify-history-container").remove();
}
function uys_show_notify_timeout(title, type, text, sure) {
    $.pnotify({
        title: title,
        type: type,
        text: text,
        delay: sure
    });
    $("div.ui-pnotify-history-container").remove();
}

function uys_show_notifyv2(message) {
    $.pnotify({
        title: message.MessageHeader,
        type: message.MessageType,
        text: message.MessageText,
        hide: message.MessageHide
    });
    $("div.ui-pnotify-history-container").remove();
}

//3. Data Bind

function uys_data_bind(jsonData) {

    $.each(jsonData[0], function (key, value) {
        console.log('key:' + key + ' value: ' + value);
        var obj = document.getElementsByName(key)[0];
        if (obj != null) {
            console.log('obj: ' + obj);
            obj.value = value;
            if ($(obj).is("select")) {
                if (obj[value] != null) {

                    console.log('ojşkjlkjlkjlkjbj: ' + obj[value].text);
                    $(obj).closest(".select2-chosen").text = obj[value].text;
                }
            }
        }
    });

}

//4. Datatable plugin

/**
* Rapor Goruntule jQ.extended
*
**/

(function ($) {

    $.fn.raporGoruntule = function (raporGUID) {
        var randomizedID = Math.floor((Math.random() * 10000) + 1);

        $("body").append('<div id="fakeModalBack" style="position:absolute; opacity:0.5; width:100%; height:100%; background:#000; top:0; z-index:99;"></div>');
        $("body").append('<div id="fakeModalAna" class="modal-content col-md-6 col-md-offset-3 col-sm-8 col-sm-offset-2 col-xs-12"  style="position:absolute; background:#fff; top:100px; z-index:101; height:80%;"><div class="modal-header"><button type="button" class="close" id="fakeModalKapat' + randomizedID + '" aria-hidden="true">×</button><h4 class="modal-title">Önizleme</h4></div><div id="fakeModal" class="modal-body" style="height:100%;"><iframe src="" style="width: 100%; height: 90%;" frameborder="0" > <p>Tarayıcınız iframe desteklemiyor.</p> </iframe></div></div>');
        $("#fakeModal iframe").attr("src", '/Rapor/Goster?raporGuid=' + raporGUID);

        var fakeModalKapatFunc = function () {
            console.log("fake-modal-kapat " + randomizedID);
            $("#fakeModalKapat" + randomizedID).unbind("click");
            $("#fakeModalBack").remove();
            $("#fakeModalAna").remove();
        }

        $(document).on('click', "#fakeModalKapat" + randomizedID, fakeModalKapatFunc);
        console.log("rapor görüntülendi");
    }

}(jQuery));



/**
* Rapor Goruntule jQ.extended --end--
*
**/

/**
* FakeModal Başlangıç
**/
var fakeModall = function (nesne, duzenle, guncelle, iptal, animasyonHiz) {
    var nesneParent = $(nesne).parent();
    animasyonHiz = animasyonHiz || "slow";
    var randomizedID = Math.floor((Math.random() * 10000) + 1);
    $(guncelle).hide();
    $(iptal).hide();

    var olustur = function () {
        $("body").append('<div id="fakeModalBack" style="position:absolute; opacity:0.5; width:100%; height:100%; background:#000; top:0; z-index:99;"></div>');
        $("body").append('<div id="fakeModalAna" class="col-md-6 col-md-offset-3 col-sm-8 col-sm-offset-2 col-xs-12"  style="position:absolute; background:#fff; top:100px; z-index:101;"><div class="modal-header"><button type="button" class="close" id="fakeModalKapat' + randomizedID + '" aria-hidden="true">×</button><h4 class="modal-title">Güncelleme</h4></div><div id="fakeModal" class="modal-body"></div></div>');
        $(nesne).appendTo($("#fakeModal")).show(animasyonHiz);
    }

    var fakeModalKapatFunc = function () {
        console.log("fake-modal-kapat " + randomizedID);
        $("#fakeModalKapat" + randomizedID).unbind("click");
        $(nesne).hide();
        $(nesne).appendTo($(nesneParent)).show(animasyonHiz);
        $("#fakeModalBack").remove();
        $("#fakeModalAna").remove();
        $(duzenle).show();
        $(iptal).hide();
        $(guncelle).hide();
    }

    $(document).on('click', "#fakeModalKapat" + randomizedID, fakeModalKapatFunc);

    $(duzenle).click(function () {
        $(nesne).hide();
        olustur();
        $(duzenle).hide();
        $(iptal).show();
        $(guncelle).show();
    });

    $(iptal).click(function () {
        fakeModalKapatFunc();
    });

}

/**
* FakeModal Bitiş
**/
function setCookie(cname, cvalue, exdays) {
    var d = new Date();
    d.setTime(d.getTime() + (exdays * 24 * 60 * 60 * 1000));
    var expires = "expires=" + d.toGMTString();
    document.cookie = cname + "=" + cvalue + "; " + expires;
}

function getCookie(cname) {
    var name = cname + "=";
    var ca = document.cookie.split(';');
    for (var i = 0; i < ca.length; i++) {
        var c = ca[i];
        while (c.charAt(0) == ' ') c = c.substring(1);
        if (c.indexOf(name) != -1) return c.substring(name.length, c.length);
    }
    return "";
}
/*
* son gezilen öğrenciler başlangıç
*/
function Ogrenci(id, foto, asoy, numara) {
    this.id = id;
    this.foto = foto;
    this.asoy = asoy;
    this.numara = numara;
}

function islemYapilanOgrenciEkle(ogrenci) {
    var tmp = getCookie("SonIslemYapilanOgrenciler");
    if (tmp != "") {
        var SonIslemYapilanOgrenciler = JSON.parse(tmp);
        if (SonIslemYapilanOgrenciler.length > 7) {
            SonIslemYapilanOgrenciler.shift();
        }
        SonIslemYapilanOgrenciler.push(ogrenci);
        setCookie("SonIslemYapilanOgrenciler", JSON.stringify(SonIslemYapilanOgrenciler), 999);
    } else {
        console.log("array empty");
        var SonIslemYapilanOgrenciler = new Array();
        SonIslemYapilanOgrenciler.push(ogrenci);
        setCookie("SonIslemYapilanOgrenciler", JSON.stringify(SonIslemYapilanOgrenciler), 999);
    }
}

function islemYapilanOgrencileriGetir() {
    var tmp = getCookie("SonIslemYapilanOgrenciler");
    var result = new Array();
    if (tmp != "") {
        result = JSON.parse(tmp);
    }
    return result;
}

/*
* son gezilen öğrenciler bitiş
*/

function uys_cascading_dropdown(obj, action, cascId, cascDefaultText) {

    var val = obj.value;
    uys_reset_dropdown(cascId, cascDefaultText);

    if (val != null && val != '') {
        $.ajax({
            type: "post",
            url: action,
            data: '{"id":"' + val + '"}',
            async: false,
            contentType: "application/json; charset=utf-8",
            dataType: 'json',
            success: function (data) {
                uys_fill_dropdown(cascId, data, cascDefaultText);
            },
            error: function () {
                alert('Fakülteden Veri Yanlış Geldi');
            }
        });
    }
}

function uys_reset_dropdown(elementId, defaultText) {
    $('#' + elementId).empty();
    $('#' + elementId).text = '';
    $('#' + elementId).value = '';

    $('#' + elementId).append($('<option />', {
        selected: true,
        value: '',
        text: defaultText
    }));
}

function uys_fill_dropdown(elementId, jsonData, defaultText) {

    $.each(jsonData, function (index, item) {

        $('#' + elementId).append($('<option />', {
            value: item.Value,
            text: item.Text
        }));
    });

}