// shared startup code
$(function () {

    // disable ajax caching, wire up callbacks
    $.ajaxSetup({
        cache: false,
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            return false;
        },
        success: function (data, textStatus, XMLHttpRequest) {
            return false;
        }
    });

    // modal dialog links
    $(document).on('click', 'a.dialog, button.dialog', function (e) {
        e.preventDefault();
        var href = $(this).attr('href');
        Structure.Dialogs.Modal(href);
    });

});