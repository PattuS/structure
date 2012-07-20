// script loader
; (function (ns, undefined) {

    ns.loader = ns.loader || {};
    ns.loader.exec = function (controller, action) {
        var action = (action === undefined) ? "init" : action;

        if (controller !== '' && ns[controller] && typeof ns[controller][action] === "function") {
            ns[controller][action]();
        }
    };

    // load each startup script for the page
    $(function () {
        var body = document.body,
            controller = body.getAttribute("data-controller"),
            action = body.getAttribute("data-action");

        ns.loader.exec("common");
        ns.loader.exec(controller);
        ns.loader.exec(controller, action);
    });

})(Structure);
