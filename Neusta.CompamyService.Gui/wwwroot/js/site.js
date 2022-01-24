// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


/*$(function () {
    $('button[data-toggle="AddAttribute-Modal"]').click(function (event) {
    $.ajax({
        type: "GET",
        url: $(this).data('url'),
        success: function(response) {
            $("#form-modal .modal-body").html(response);
            $("#form-modal .modal-title").html("Attribute hinzufügen");
            $("#form-modal").showModal();
        }
    });
};*/

$(function() {
    $('button[data-toggle="AddAttribute-Modal"]').click(function(event) {
        var url = $(this).data('url');
        $.get(url).done(function(data) {
            $(document.body).append(data).find('.modal').modal('show');
        });
    });
});

ShowAddAttribute2 = (url) => {
    $("#form-modal .modal-title").html("Attribute hinzufügen");
    ShowModal(url);
}

ShowModal = () => {
    $(function() {
        $("#form-modal .modal-body").load('/Edit/');
    });
}

ShowEdit = (url, button) => {
    $(function() {
        $(button).on("click", ShowModal(url));
    });
}

IndexFunction = (url, data) => {
    $.ajax({
        type: "POST",
        url: url,
        data: data,
        contentType: "application/json; charset=utf-8",
        dataType: "html",
        success: function(response) {
            $("#companyTable").html(response);
        },
        failure: function (response) {
            alert(response.responseText);
        },
        error: function (response) {
            alert(response.responseText);
        }
    });
};

