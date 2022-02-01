// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


$(function() {
    $('button[data-toggle="AddAttribute-Modal"]').click(function(event) {
        var url = $(this).data('url');
        $.get(url).done(function(data) {
            $(document.body).append(data).find('.modal').modal('show');
        });
    });
});

$('#AttributeNameForm').submit(function() {
    $.ajax({
            type: "post",
            url: '/?handler=UpdateAttribute',
            data: $('#AttributeNameForm').serialize()
        })
        .done(function() {
            CallSuccessAlert();
        });
});

function PostData(url, dataString) {

    var mergedData = MergeDatas(dataString);
    $.ajax({
        type: "post",
        dataType: "html",
        url: url,
        data: mergedData
})
        .done(function() {
            CallSuccessAlert();
            UpdateTable();
        })
        .fail(function() {
            alert("Aktualisieren ist fehlgeschlagen");
        });
};

function UpdateTable() {
    $('#grid').load('/?handler=TablePartial');
};

function MergeDatas(dataString) {
    var token = GetRequestVerificationTokenArray();
    var mergedData = Object.assign(dataString, token);
    return mergedData;
};

function GetRequestVerificationTokenArray() {
    var form = $('#__AjaxAntiForgeryForm');
    var token = $('input[name="__RequestVerificationToken"]', form).val();
    var tokenString = {__RequestVerificationToken :  token  };
    return tokenString;
};

function CallSuccessAlert() {
    $('#AlertSuccesss').show('fade');
    setTimeout(function() {
        $('#AlertSuccesss').hide('fade');
    }, 2000);
};