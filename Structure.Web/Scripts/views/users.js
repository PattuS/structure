// users
; (function (ns, window, document, undefined) {

    ns.users = (function(){

        return {
            init: function () {
                console.log("users.init");
            },

            show: function () {
                console.log("users.show");
            }
        };

    })();

})(Structure, window, document);