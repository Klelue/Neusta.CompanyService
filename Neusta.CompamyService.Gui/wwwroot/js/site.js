// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

var ButtonKeys = { "EnterKey": 13 };

ShowAddAttribute = (url) => {
    $.ajax({
        type: 'GET',
        url: url,
        success: function(result) {
            $("#form-modal .modal-body").html(res);
            $("#form-modal .modal-title").html("Attribute hinzufügen");
            $("#form-modal").Modal('show');
        }
    });
};

UpdateTableOnclick = (url) => {
    $(function() {
        $('#load').on('click', LoadTable(url));
    });
};

LoadTable = (url) => {
    $(function() {
        $('#grid').load(url);
    });
}

UpdateAttributeByPressingButton = (formName) => {
    $("#" + formName).keypress(function(result) {
        if (result.which === ButtonKeys.EnterKey) {
            var defaultButtonId = $(this).attr("updateAttributeButton");
            $("#" + defaultButtonId).click(function() {

            });
            return false;
        }
    });
};
