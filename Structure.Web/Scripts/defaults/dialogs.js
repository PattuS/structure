/*
* Dialog infrastructure
*
*/
; (function (ns, window, document, undefined) {

    ns.dialogs = (function(){

        return {

            // alert replacement for 
            alert: function (msg) {
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
            confirm: function (msg, callback) {
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
            modal: function (href) {
                if (href.indexOf('#') === 0) {
                    $(href).modal();
                }
                else {
                    ns.common.block();
                    $.get(href, function (data) {
                        $modal = $(data).appendTo('body');
                        $modal.on('show', function(){
                                var controller = $modal.attr("data-controller"),
                                    action = $modal.attr("data-action");

                                ns.loader.exec(controller, action);
                            })
                            .on('hidden', function () {
                                $(this).remove();
                            });

                        $modal.modal({
                            backdrop: true,
                            keyboard: true
                        }).css({
                            width: 'auto',
                            'margin-left': function () {
                                return -($(this).width() / 2);
                            }
                        });
                        ns.common.unblock();
                    });
                }
            }
        }; // return

    })(); // exec ns.dialogs

})(Structure, this, document);
