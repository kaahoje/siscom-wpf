jQuery(function () {

    $(":input[data-autocomplete]").each(function () {
        var input = $(this);
        input.autocomplete({ source: input.attr('data-autocomplete') });
    });

})