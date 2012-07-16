// common dialogs using bootstrap
Structure.Dialogs = (function ($, window, document, undefined) {

    return {

        // alert replacement for 
        Alert: function (msg) {
            var k = '<div class="modal">';
            k += '<div class="modal-header"><button class="close" data-dismiss="modal">×</button><h3>Alert</h3></div>';
            k += '<div class="modal-body"><p>' + msg + '</p></div>';
            k += '<div class="modal-footer"><a href="#" class="btn" data-dismiss="modal">Close</a></div></div>';
            $k = $(k).appendTo('body');

            $k.modal({
                keyboard: true
            });
        },

        // confirm replacement
        Confirm: function (msg, callback) {
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
        },

        // modal dialogs
        Modal: function (href) {
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
        }
    };

})(jQuery, this, document);
