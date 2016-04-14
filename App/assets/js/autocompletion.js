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
    var url = "Search.aspx/Find";
    var data = '{ "query": "' + search_query + '" }';
    if (search_charcount > 2) {

        $.ajax({
            type: "POST",
            url: url,
            data: data,
            dataType: 'json',
            contentType: 'application/json',
            success: function (data) {

                if (data['d'] != null) {
                    streetNames = data['d'].replace(/\"/g, "").replace(/\[/g, "").replace(/\]/g, "");
                    streetArray = streetNames.split(',');

                    // Empty onchange
                    $('.result').remove();

                    $.each(streetArray, function (key, value) {
                        $(dropdown).append("<div class='result'>" + value + "</div>");
                    });

                    $(dropdown).find('p').addClass('hidden');

                }
                else {
                    $(dropdown).find('.result').remove();
                    $(dropdown).find('p').removeClass('hidden');
                }
            },
            error: function (data, status) {
                alert("Error. " + status);
            }
        });
    }
    else{
        $(dropdown).find('p').addClass('hidden');
        $(dropdown).find('.result').remove();
    }
});

$('.search_dropdown').on("click", '.result' , function () {
    var searchf = $('.search_ac');
    var selected = $(this).text();
        
    searchf.val(selected);
    $("#search_func").submit();

});