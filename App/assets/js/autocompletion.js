$("#MainContent_search_ac").on("input", function () {
    // Input variables
    var searchf = $("#MainContent_search_ac");
    var search_charcount = $(searchf).val().replace(/ /g, '').length;
    var search_query = $(searchf).val();

    // Variables for the ajax call
    var url = "Search.aspx/Find";
    var data = '{ "query": "'+search_query+'" }';

    
    if (search_charcount >= 3) {
        $.ajax({
            type: "POST",
            url: url,
            data: data,
            dataType: 'json',
            contentType: 'application/json',
            success: function (data) {
                console.log(data);
            },
            error: function (data, status) {
                alert("Error.");
            }
        });
    }
});