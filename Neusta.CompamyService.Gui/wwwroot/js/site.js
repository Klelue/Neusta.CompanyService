// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function SubmitForm(formName) {
    var form = $("#" + formName);
    $.ajax({
        type: form.attr("method"),
        url: form.attr("action"),
        data:  form.serialize(),
        dataType: "html"
        })
        .done(function(result) {
            CallSuccessAlert();
            $('#grid').html(result);
        })
        .fail(function() {
            alert("Aktualisieren ist fehlgeschlagen");
        });
};

function PostData(url, dataString) {
    
    $.ajax({
            type: "post",
            dataType: "html",
            url: url,
            data: MergeDatas(dataString)
        })
        .done(function(result) {
            CallSuccessAlert();
            $('#grid').html(result);
        })
        .fail(function() {
            alert("Aktualisieren ist fehlgeschlagen");
        });
};

function MergeDatas(dataString) {
    var token = GetRequestVerificationTokenArray();
    var mergedData = token;
    if (dataString != null) {
        mergedData = Object.assign(dataString, token);
    }
    return mergedData;
};

function PopUpModal(url, title) {

    $.ajax({
            type: "get",
            url: url
        })
        .done(function(result) {
            $('.modal-title').html(title);
            $('.modal-body').html(result);
            $('#modal').modal('show');
        })
        .fail(function() {
            alert("Modal konnte nicht geladen werden");
        });
};

function GetRequestVerificationTokenArray() {
    var form = $("#__AjaxAntiForgeryForm");
    var token = $('input[name="__RequestVerificationToken"]', form).val();
    var tokenString = { __RequestVerificationToken: token };
    return tokenString;
};

function CallSuccessAlert() {
    $("#AlertSuccess").show("fade");
    setTimeout(function() {
            $("#AlertSuccess").hide("fade");
        },
        2000);
};