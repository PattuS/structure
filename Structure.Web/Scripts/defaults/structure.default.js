// default namespace
Structure = (function ($, window, document, undefined) {

    return {
        // block ui
        Block: function (element) {
            if (typeof element === 'undefined')
                element = 'body';

            if ($(element).has('.blockUI').length == 0)
                return $(element).block();
        },

        // unblock ui
        Unblock: function (element) {
            if (typeof element === 'undefined')
                element = 'body';

            return $(element).unblock();
        }
    };

})(jQuery, this, document);
