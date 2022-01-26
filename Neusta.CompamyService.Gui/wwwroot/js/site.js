// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


$(function() {
    $('button[data-toggle="AddAttribute-Modal"]').click(function(event) {
        UpdateTable();
        var url = $(this).data('url');
        $.get(url).done(function(data) {
            $(document.body).append(data).find('.modal').modal('show');
        });
    });
});

$(function () {
    $('#submit').on('click', function (evt) {
        evt.preventDefault();
        $.post('', $('form').serialize(), function () {
            alert('Posted using jQuery');
        });
    });
});

completed = function(res) {
    alert("Table aktualisiert");
    $('#grid').load(res);
};



