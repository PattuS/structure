// forms
; (function (ns, window, document, undefined) {

    ns.forms = (function () {

        return {

            // save
            saveAsync: function(e){
                e.preventDefault();
                $form = $(this);

                // validation
                if(!$form.valid())
                    return false;

                // success
                var success = function(result){
                    window.location.reload();
                };

                // fail
                var fail = function(error){
                    ns.dialogs.alert(error);
                };
                    
                // handle the form submission
                ns.forms.ajaxSubmit($form, success, fail);
            },
            
            // submit a form via ajax and handle the response
            ajaxSubmit: function($form, success, fail){
                // normalize so we always return false if no callback is provided
                success = success || function(){ return false; };
                fail = fail || function(){ return false; };

                // post the form and execute the callbacks
                // expects response to have 3 properties { HasError, Error, Result }
                $.post($form.attr('action'), $form.serialize(), function(response){
                    if(response.HasError){
                        return fail(response.Error);
                    }
                    else {
                        return success(response.Result);
                    }
                });
            }

        };

    })();

})(Structure, window, document);