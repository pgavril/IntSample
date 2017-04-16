// Write your Javascript code.
$(function () {
    $("glyphicon").mouseover(function () {
        $(this).animate({ height: '+=25', width: '+=25' })
            .animate({ height: '-=25', width: '-=25' });
    });
});

$(document).ajaxSend(function (e, xhr, options) {
    if (options.type.toUpperCase() == "POST") {
        var token = $form.find("input[name='af_token']").val();
        xhr.setRequestHeader("RequestVerificationToken", token);
    }
});