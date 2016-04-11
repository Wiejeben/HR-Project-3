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
    if ($('#map').length)
    {
        function initialize() {

            //wordt for-loop voor list met coordinaten uit DB op basis van query.
            var center = new google.maps.LatLng(35.7022077, 139.7722703);

            //constant
            var mapOptions = {
                zoom: 8,
                center: center
            }

            // DE map
            map = new google.maps.Map(document.getElementById("map"), mapOptions);

            //// Add marker
            //var marker = new google.maps.Marker({
            //    position: center,
            //    animation: google.maps.Animation.DROP,
            //    map: map
            //});


            //marker.addListener('click', function() {
            //    infowindow.open(map, marker);
            //});

            var infowindow = new google.maps.InfoWindow({});
            var markericon = '';
            var locations = [
                ['Atlantis', 35.7022077, 139.2722703],
                ['iets', 35.2022077, 139.7722703]
                ['niets ２', 35.7022077, 139.7722703],
                ['in.', 35.0022077, 139.7722703]
            ];

            for (i = 0; i < locations.length; i++) {
                marker = new google.maps.Marker({
                    position: new google.maps.LatLng(locations[i][1], locations[i][2]),
                    animation: google.maps.Animation.DROP,
                    icon: markericon,
                    map: map
                });

                google.maps.event.addListener(marker, 'click', (function (marker, i) {
                    return function () {
                        infowindow.setContent(locations[i][0]);
                        infowindow.open(map, marker);
                    }
                })(marker, i));
            }
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