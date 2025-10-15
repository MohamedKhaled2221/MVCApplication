
$(document).ready(function () {

    $('form input, form select, form textarea').on('blur', function () {
        $(this).valid();
    });
});