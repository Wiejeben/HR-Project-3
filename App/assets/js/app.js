// Graph settings
var randomScalingFactor = function () { return Math.round(Math.random() * 100) };

var barChartData = {
    labels: ["January", "February", "March", "April", "May", "June", "July"],
    datasets: [
        {
            fillColor: "rgba(220,220,220,0.5)",
            strokeColor: "rgba(220,220,220,0.8)",
            highlightFill: "rgba(220,220,220,0.75)",
            highlightStroke: "rgba(220,220,220,1)",
            data: [randomScalingFactor(), randomScalingFactor(), randomScalingFactor(), randomScalingFactor(), randomScalingFactor(), randomScalingFactor(), randomScalingFactor()]
        },
        {
            fillColor: "rgba(151,187,205,0.5)",
            strokeColor: "rgba(151,187,205,0.8)",
            highlightFill: "rgba(151,187,205,0.75)",
            highlightStroke: "rgba(151,187,205,1)",
            data: [randomScalingFactor(), randomScalingFactor(), randomScalingFactor(), randomScalingFactor(), randomScalingFactor(), randomScalingFactor(), randomScalingFactor()]
        }
    ]
}

$(document).ready(function () {

    // Google Maps
    if ($('#map').length != null)
    {
        function initialize() {

            var latlng = new google.maps.LatLng(35.7022077, 139.7722703);

            var mapOptions = {
                zoom: 8,
                center: latlng
            }

            map = new google.maps.Map(document.getElementById("map"), mapOptions);

            var marker = new google.maps.Marker({
                position: latlng,
                map: map,
                title: 'Hey buddy.'
            });
        }

        google.maps.event.addDomListener(window, 'load', initialize);
    }

    // Bar graph
    if ($("#chart").length) {
        var ctx = $("#chart").get(0).getContext("2d");
        window.myBar = new Chart(ctx).Bar(barChartData, {
            responsive: false
        });
    }

});