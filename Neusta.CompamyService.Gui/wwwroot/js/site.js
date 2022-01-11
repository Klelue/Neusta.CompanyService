// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

var ButtonKeys = { "EnterKey": 13 };

ShowAddAttribute  => {
    $.ajax({
        type: "GET",
        url: url,
        success: function(res) {
            $("#form-modal .modal-body").html(res);
            $("#form-modal .modal-title").html("Attribute hinzufügen");
            $("#form-modal").Modal('show');
        }
    });
};

GetTable = (url) => {
    $.ajax({
        type: "GET",
        url: url,
        success: function(res) {

        }
    });
};

UpdateAttributeByPressingButton = (formName) => {
    $("#" + formName).keypress(function(e) {
        if (e.which === ButtonKeys.EnterKey) {
            var defaultButtonId = $(this).attr("updateAttributeButton");
            $("#" + defaultButtonId).click(function() {

            });
            return false;
        }
    });
};
