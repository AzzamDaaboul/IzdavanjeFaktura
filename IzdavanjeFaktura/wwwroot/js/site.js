// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function hasClass(elem, className) {
    return elem.classList.contains(className);
}

function CalcUkupnaCijenaBezPoreza() {
    var x = document.getElementsByClassName("UkupnaCijenaStavkeBezPoreza");
    //var totalExp = 0;
    var ukupnoBezPoreza = 0;
    var ukupnoSaPorezom = 0;
    var ukupnaCijenaStavkeBezPoreza = 0;
    var i;

    for (i = 0; i < x.length; i++) {

        var idofIsDeleted = i + "__IsDeleted";
        var hidIsDelId = document.querySelector("[id$='" + idofIsDeleted + "']").id;
        var ukupnoSaDec;
        if (document.getElementById(hidIsDelId).value != "true")
            ukupnoBezPoreza = ukupnoBezPoreza + eval(x[i].value);

        //Drugi nacin za racunanje poreza, medjutim ovaj dio je uradjen u controlleru za Create i Edit metodu (HttpPost)

        //ukupnoSaPorezom = ukupnoBezPoreza + ukupnoBezPoreza * 17 / 100;
        //ukupnoSaDec = parseFloat(ukupnoSaPorezom).toFixed(3);
        //ukupnoSaDec = ukupnoSaDec.replace('.', ',')
        //ukupnoSaDec = ukupnoSaPorezom.toFixed(3);
    }

    document.getElementById('UkupnaCijenaBezPoreza').value = ukupnoBezPoreza;
    //document.getElementById('UkupnaCijenaSaPorezom').value = ukupnoSaDec;

    return;
}

document.addEventListener('change', function (e) {
    if (hasClass(e.target, 'UkupnaCijenaStavkeBezPoreza')) {
        CalcUkupnaCijenaBezPoreza();
    }
}, false);

function DeleteStavke(btn) {
    var table = document.getElementById('StavkeTable');
    var rows = table.getElementsByTagName('tr');
    if (rows.length == 2) {
        alert("Ovaj red se ne može izbrisati");
        return;
    }
    $(btn).closest('tr').remove();

    CalcUkupnaCijenaBezPoreza();

}

//function DeleteStavkeEdit(btn) {

//    var table = document.getElementsById('StavkeTable');
//    var rows = table.getElementsByTagName('tr');
//    if (rows.length == 2) {
//        alert("Ovaj red se ne može izbrisati");
//        return;
//    }

//    var btnIdx = btn.id.replaceAll('btnremove-@i', '');
//    var idofIsDeleted = btnIdx + "__IsDeleted";

//    var hidIsDelId = document.querySelector("[id$='" + idofIsDeleted + "']").id;

//    document.getElementById(hidIsDelId).value = "true";

//    //$(btn).closest('tr').remove();

//    $(btn).closest('tr').hide();
//}

function AddStavke(btn) {

    var table = document.getElementById('StavkeTable');
    var rows = table.getElementsByTagName('tr');

    //get the last row of StavkeTable
    var rowOuterHtml = rows[rows.length - 1].outerHTML;

    var lastrowIdx = rows.length - 2;

    //convert stored string to number
    var nextrowIdx = eval(lastrowIdx) + 1;

    //assign new index to hidden control
    document.getElementById('hdnLastIndex').value = nextrowIdx;

    //rowOuterHtml hold the source of the last row, and raplace old index to new one
    rowOuterHtml = rowOuterHtml.replaceAll('_' + lastrowIdx + '_', '_' + nextrowIdx + '_');
    rowOuterHtml = rowOuterHtml.replaceAll('[' + lastrowIdx + ']', '[' + nextrowIdx + ']');
    rowOuterHtml = rowOuterHtml.replaceAll('-' + lastrowIdx, '-' + nextrowIdx);

    //attach new row to the table
    var newRow = table.insertRow();
    newRow.innerHTML = rowOuterHtml;

    rebindvalidatiors();

    var x = document.getElementsByTagName("INPUT");

    for (var cnt = 0; cnt < x.length; cnt++) {
        document.getElementsByClassName("BrojStavke").value += 1;
        if (x[cnt].type == "text" && x[cnt].id.indexOf('_' + nextrowIdx + '_') > 0)
            x[cnt].value = '';
        else if (x[cnt].type == "number" && x[cnt].id.indexOf('_' + nextrowIdx + '_') > 0)
            x[cnt].value = 0;
    }

    //show hide buttons
    var btnAddId = btn.id;
    var btnDeleteId = btnAddId.replaceAll('btnaddStavke', 'btnremove');

    var delbtn = document.getElementById(btnDeleteId);
    delbtn.classList.add("visible");
    delbtn.classList.remove("invisible");

    var addbtn = document.getElementById(btnAddId);
    addbtn.classList.remove("visible");
    addbtn.classList.add("invisible");
}

function rebindvalidators() {

    //Provjeriti ovaj id #FakturaForm gdje da primjenimo u primjeru #ApplicationForm
    var $form = $("#FakturaForm");

    $form.unbind();

    $form.data("validator", null);

    $.validator.unobtrusive.parse($form);

    $form.validate($form.data("unobtrusiveValidation").options);
}