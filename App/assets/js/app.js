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
                    marker = new google.maps.Marker({
                        position: new google.maps.LatLng(locations[i][1], locations[i][2]),
                        icon: '../assets/img/markerblue.png',
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
        }
        google.maps.event.addDomListener(window, 'load', initialize);
    }

    
});