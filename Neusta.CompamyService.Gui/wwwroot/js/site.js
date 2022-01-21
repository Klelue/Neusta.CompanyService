// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

const EnterKeyCode = 13;

function ShowAddAttribute (url) {
    $.ajax({
        type: 'GET',
        url: url,
        success: function(response) {
            $("#form-modal .modal-body").html(response);
            $("#form-modal .modal-title").html("Attribute hinzufügen");
            $("#form-modal").showModal();
        }
    });
};

IndexFunction = (url, data) => {
    $.ajax({
        type: 'POST',
        url: url,
        data: data,
        contentType: "application/json; charset=utf-8",
        dataType: "html",
        success: function(response) {
            $('#companyTable').html(response);
        },
        failure: function (response) {
            alert(response.responseText);
        },
        error: function (response) {
            alert(response.responseText);
        }
    });
};

function UpdateAttributeByPressingButton () {
    var element = document.getElementById('attributeName');

    element.addEventListener("keyup",
        function(event) {
            if (event.keyCode === EnterKeyCode) {
                document.getElementById('attributeForm').submit();
            }
        });
};
