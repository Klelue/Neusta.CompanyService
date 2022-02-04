// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function submitForm() {
    $('#attributeForm').submit().done(function(result) {
        CallSuccessAlert();
        $('#grid').html(result);
    });
}


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

function MergeDatas(dataString) {
    var token = GetRequestVerificationTokenArray();
    var mergedData = token;
    if (dataString != null) {
        mergedData = Object.assign(dataString, token);
    }
    return mergedData;
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