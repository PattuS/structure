/* 
* Default application and namespace
*
*/
var Structure = Structure || {};
;  (function (ns, window, document, undefined) {

    ns.common = (function(){

        return {
            // global init
            init: function () {

                // disable ajax caching, wire up callbacks
                $.ajaxSetup({
                    cache: false
                });

                // modal dialog links
                $(document).on('click', 'a.dialog, button.dialog', function (e) {
                    e.preventDefault();
                    var href = $(this).attr('href');
                    ns.dialogs.modal(href);
                });

                console.log("common.init");

            },

            // block ui
            block: function (element) {
                if (typeof element === undefined)
                    element = 'body';

                return $(element).block();
            },

            // unblock ui
            unblock: function (element) {
                if (typeof element === undefined)
                    element = 'body';

                return $(element).unblock();
            }

        }; // return
        
    })(); // exec ns.common

})(Structure, this, document);
