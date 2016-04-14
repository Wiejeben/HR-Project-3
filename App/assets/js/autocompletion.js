$(".search_ac").on("input", function () {
    // Empty onchange
    $('.result').remove();

    // Input variables
    var searchf = $(this);
    var searchp = $(searchf).parent('form');
    var search_charcount = $(searchf).val().replace(/ /g, '').length;
    var search_query = $(searchf).val();
    var dropdown = $('.search_dropdown');

    // Variables for the ajax call
    var url = "Search_Ajax.aspx?q=" + search_query;

    if (search_charcount > 2) {

        $.ajax({
            type: "GET",
            url: url,
            dataType: 'json',

            success: function (data) {

                // Clear results
                $('.result').remove();

                // Fill in new results
                $.each(data, function (index, element) {
                    $(dropdown).append('<div class="result" data-id="' + element.ID + '">' + element.Name + '</div>');
                });

            },
            error: function (data, status) {
                alert("Error. " + status);
            }
        });
    }
    else {
        $(dropdown).find('p').addClass('hidden');
        $(dropdown).find('.result').remove();
    }
});

$('.search_dropdown').on("click", '.result', function () {
    window.location.href = '/Street.aspx?hid=' + $(this).data('id');
});