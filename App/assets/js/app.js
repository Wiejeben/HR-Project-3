// Graph settings
var barChartData = {
    labels: objects,
    datasets: [
        {
            fillColor: "rgba(220,220,220,0.5)",
            strokeColor: "rgba(220,220,220,0.8)",
            highlightFill: "rgba(220,220,220,0.75)",
            highlightStroke: "rgba(220,220,220,1)",
            data: thefts
        },
        //{
        //    fillColor: "rgba(151,187,205,0.5)",
        //    strokeColor: "rgba(151,187,205,0.8)",
        //    highlightFill: "rgba(151,187,205,0.75)",
        //    highlightStroke: "rgba(151,187,205,1)",
        //    data: [randomScalingFactor(), randomScalingFactor(), randomScalingFactor(), randomScalingFactor(), randomScalingFactor(), randomScalingFactor(), randomScalingFactor()]
        //}
    ]
}

$(document).ready(function () {
    // Google Maps
    if ($('#map').length && typeof center !== "undefined") {
        function initialize() {
            var rotterdam_cords = [51.919980, 4.479993];

            var map_center = new google.maps.LatLng(center[1], center[2]);
            var rotterdam_center = new google.maps.LatLng(rotterdam_cords[0], rotterdam_cords[1]);

            var mapOptions = {
                zoom: 15,
                center: map_center
            }

            map = new google.maps.Map(document.getElementById("map"), mapOptions);

            // Marker Street
            var marker = new google.maps.Marker({
                position: map_center,
                animation: google.maps.Animation.DROP,
                map: map
            });

            google.maps.event.addListener(marker, 'click', (function (marker) {
                return function () {
                    infowindow.setContent(center[0]);
                    infowindow.open(map, marker);
                }
            })(marker));

            // Marker Rotterdam Centrum
            var marker = new google.maps.Marker({
                position: rotterdam_center,
                map: map,
                icon: '../assets/img/markerblue.png'
            });

            google.maps.event.addListener(marker, 'click', (function (marker) {
                return function () {
                    infowindow.setContent("Rotterdam Centrum");
                    infowindow.open(map, marker);
                }
            })(marker));

            // Markers OV haltes
            var infowindow = new google.maps.InfoWindow({});

            if (typeof locations !== "undefined") {
                for (i = 0; i < locations.length; i++) {
                    var location = locations[i];

                    marker = new google.maps.Marker({
                        position: new google.maps.LatLng(location[3], location[4]),
                        icon: '../assets/img/markerblue.png',
                        map: map
                    });

                    google.maps.event.addListener(marker, 'click', (function (marker, i) {
                        return function () {
                            var location = locations[i];

                            var contents = "<strong>" + location[0] + "</strong><br>" + location[1] + "<br>Afstand: " + location[2] + " meter";

                            infowindow.setContent(contents);
                            infowindow.open(map, marker);
                        }
                    })(marker, i));
                }
            }

            var lineToCentrumCoordinates = [
                { lat: center[1], lng: center[2] },
                { lat: rotterdam_cords[0], lng: rotterdam_cords[1] }
            ];

            var lineToCentrum = new google.maps.Polyline({
                path: lineToCentrumCoordinates,
                geodesic: true,
                strokeColor: '#4986E7',
                strokeOpacity: .8,
                strokeWeight: 3
            });

            lineToCentrum.setMap(map);

            //Heatmap
            heatmap = new google.maps.visualization.HeatmapLayer({
                data: heatMapPoints,
                maxIntensity: 100,
                radius: 30
            });
            heatmap.setMap(map);
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