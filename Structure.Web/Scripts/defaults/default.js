// default namespace
Structure = Structure || {};

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
    $(document).on('click', '.dialog', function (e) {
        e.preventDefault();
        var href = $(this).attr('href');
        Structure.Dialog(href);
    });

});

// alert replacement
Structure.Dialogs.Alert = function (msg) {
    var k = '<div class="modal">';
    k += '<div class="modal-header"><button class="close" data-dismiss="modal">×</button><h3>Alert</h3></div>';
    k += '<div class="modal-body"><p>' + msg + '</p></div>';
    k += '<div class="modal-footer"><a href="#" class="btn" data-dismiss="modal">Close</a></div></div>';
    $k = $(k).appendTo('body');

    $k.modal({
        keyboard: true
    });
};

// confirm replacement
Structure.Dialogs.Confirm = function (msg, callback) {
    var k = '<div class="modal" style="display:none;">';
    k += '<div class="modal-header"><h3>Confirm</h3></div>';
    k += '<div class="modal-body"><p>' + msg + '</p></div>';
    k += '<div class="modal-footer"><a href="#" class="btn" data-dismiss="modal">Close</a><a href="#" class="ok btn btn-primary">OK</a></div></div>';
    $k = $(k).appendTo('body');

    $k.on('show', function () {
        var dialog = this;
        $('a.ok').click(function (event) {
            event.preventDefault();
            if ($.isFunction(callback)) {
                callback.apply(this);
            }
            $(dialog).modal('hide');
        });
    });

    $k.modal({
        keyboard: false
    });
};

// modal dialog
Structure.Dialogs.Modal = function (href) {
    if (href.indexOf('#') == 0) {
        $(href).modal();
    }
    else {
        Structure.Block();
        $.get(href, function (data) {
            $(data).modal()
                .on('hidden', function () {
                    $(this).remove();
                });
            Structure.Unblock();
        });
    }
};

// block ui
Structure.Block = function (element) {
    if (typeof element === 'undefined')
        element = 'body';

    if ($(element).has('.blockUI').length == 0)
        return $(element).block();
};

// unblock ui
Structure.Unblock = function (element) {
    if (typeof element === 'undefined')
        element = 'body';

    return $(element).unblock();
};