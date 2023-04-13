function hasClass(elem, className) {
    return elem.classList.contains(className);
}

function CalcUkupnaCijenaBezPoreza() {
    var x = document.getElementsByClassName("UkupnaCijenaStavkeBezPoreza");
    var kolicinaProdaneStavke = document.getElementsByClassName("KolicinaProdaneStavke");
    var jedinicnaCijenaStavkeBezPoreza = document.getElementsByClassName("JedinicnaCijenaStavkeBezPoreza");
    var ukupnoBezPoreza = 0;
    var ukupnoSaPorezom = 0;
    var ukupnaCijenaStavkeBezPoreza = 0;
    var i;

    for (i = 0; i < x.length; i++) {

        var btnRemove = "btnremove-" + i;

        var idofIsDeleted = i + "__IsDeleted";
        var hidIsDelId = document.querySelector("[id$='" + idofIsDeleted + "']").id;
        var ukupnoSaDec;
        x[i].value = eval(kolicinaProdaneStavke[i].value) * eval(jedinicnaCijenaStavkeBezPoreza[i].value);
        if (document.getElementById(btnRemove).value != "true")
            ukupnoBezPoreza = ukupnoBezPoreza + eval(x[i].value);

        //Drugi nacin za racunanje poreza, medjutim ovaj dio je uradjen u controlleru za Create i Edit metodu (HttpPost)

        //ukupnoSaPorezom = ukupnoBezPoreza + ukupnoBezPoreza * 17 / 100;
        //ukupnoSaDec = parseFloat(ukupnoSaPorezom).toFixed(3);
        //ukupnoSaDec = ukupnoSaDec.replace('.', ',')
        //ukupnoSaDec = ukupnoSaPorezom.toFixed(3);
    }

    document.getElementById('UkupnaCijenaBezPoreza').value = ukupnoBezPoreza;

    return;
}

document.addEventListener('change', function (e) {
    if (hasClass(e.target, 'JedinicnaCijenaStavkeBezPoreza')) {
        CalcUkupnaCijenaBezPoreza();
    }
    else if (hasClass(e.target, 'KolicinaProdaneStavke')) {
        CalcUkupnaCijenaBezPoreza();
    }
}, false);

function DeleteStavke(btn) {
    var table = document.getElementById('StavkeTable');
    var counterRows = document.getElementById('counterRows');

    var rows = table.getElementsByTagName('tr');

    if (counterRows.value == 2) {
        alert("Ovaj red se ne može izbrisati");
        return;
    }

    counterRows.value = eval(counterRows.value) - 1;

    var btnIdx = btn.id.replaceAll('btnremove-', '');

    var idOfIsDeleted = btnIdx + "__IsDeleted";

    var hidIsDelId = document.querySelector("[id$='" + idOfIsDeleted + "']").id;

    var btnRemove = "btnremove-" + btnIdx;
    document.getElementById(btnRemove).value = "true";

    document.getElementById(hidIsDelId).value = "true";
    $(btn).closest('tr').hide();

    CalcUkupnaCijenaBezPoreza();
}

function AddStavke(btn) {

    var table = document.getElementById('StavkeTable');
    var rows = table.getElementsByTagName('tr');

    var counterRows = document.getElementById('counterRows');
    counterRows.value = eval(counterRows.value) + 1;

    var lastrowIdx = rows.length - 1;

    //get the last row of StavkeTable
    var rowOuterHtml = rows[lastrowIdx].outerHTML;

    lastrowIdx = lastrowIdx - 1;

    //convert stored string to number
    var nextrowIdx = eval(lastrowIdx) + 1;

    console.log('Last Row Idx = ' + lastrowIdx);
    console.log('Next Row Idx = ' + nextrowIdx);

    //rowOuterHtml hold the source of the last row, and raplace old index to new one
    rowOuterHtml = rowOuterHtml.replaceAll('_' + lastrowIdx + '_', '_' + nextrowIdx + '_');
    rowOuterHtml = rowOuterHtml.replaceAll('[' + lastrowIdx + ']', '[' + nextrowIdx + ']');
    rowOuterHtml = rowOuterHtml.replaceAll('-' + lastrowIdx, '-' + nextrowIdx);

    //attach new row to the table
    var newRow = table.insertRow();

    newRow.innerHTML = rowOuterHtml;

    var btnRemove = "btnremove-" + nextrowIdx;
    document.getElementById(btnRemove).value = "false";

    document.getElementById("FakturaStavki_" + nextrowIdx + "__IsDeleted").value = false;

    //Setting default value for a new row, to be 0.
    document.getElementById("brojStavke-" + nextrowIdx).value = "0";
    document.getElementById("kolicinaProdaneStavke-" + nextrowIdx).value = "0";
    document.getElementById("jedinicnaCijenaStavkeBezPoreza-" + nextrowIdx).value = "0";
    document.getElementById("ukupnaCijenaStavkeBezPoreza-" + nextrowIdx).value = "0";

    rebindvalidators();
}

function rebindvalidators() {

    var $form = $("#FakturaForm");

    $form.unbind();

    $form.data("validator", null);

    $.validator.unobtrusive.parse($form);

    $form.validate($form.data("unobtrusiveValidation").options);
}