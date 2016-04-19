function initializeHeatMap() {

    var mapOptions = {
        zoom: 14,
        center: new google.maps.LatLng(51.919980, 4.479993)
    }

    map = new google.maps.Map(document.getElementById('maps-heatmap'), mapOptions);

    //Heatmap
    heatmap = new google.maps.visualization.HeatmapLayer({
        data: heatmapInfo,
        maxIntensity: 100,
        radius: 30
    });

    heatmap.setMap(map);
}

function initializeStreetsMap() {
    var rotterdam_cords = [51.919980, 4.479993];

    var map_center = new google.maps.LatLng(center[1], center[2]);
    var rotterdam_center = new google.maps.LatLng(rotterdam_cords[0], rotterdam_cords[1]);

    var mapOptions = {
        zoom: 15,
        center: map_center
    }

    map = new google.maps.Map(document.getElementById('maps-street'), mapOptions);

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
                icon: '../assets/img/ret.png',
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
}

// Graph settings
if (typeof thefts == "undefined" || typeof objects == "undefined")
{
    thefts = [];
    objects = [];
}

var barChartData = {
    labels: [objects[0], objects[3], objects[6], objects[9], objects[12]],
    datasets: [
        {
            label: "2011",
            fillColor: "rgba(220,220,220,0.5)",
            strokeColor: "rgba(220,220,220,0.8)",
            highlightFill: "rgba(220,220,220,0.75)",
            highlightStroke: "rgba(220,220,220,1)",
            data: [thefts[0], thefts[3], thefts[6], thefts[9], thefts[12]]
        },
        {
            label: "2012",
            fillColor: "rgba(150,187,205,0.5)",
            strokeColor: "rgba(150,187,205,0.8)",
            highlightFill: "rgba(150,187,205,0.75)",
            highlightStroke: "rgba(150,187,205,1)",
            data: [thefts[1], thefts[4], thefts[7], thefts[10], thefts[13]]
        },
        {
            label: "2013",
            fillColor: "rgba(80,187,205,0.5)",
            strokeColor: "rgba(80,187,205,0.8)",
            highlightFill: "rgba(80,187,205,0.75)",
            highlightStroke: "rgba(80,187,205,1)",
            data: [thefts[2], thefts[5], thefts[8], thefts[11], thefts[14]]
        }
    ]
}

$(document).ready(function () {
    // Street info
    if ($('#maps-street').length) {
        if (typeof center == "undefined") {
            alert("Maps center was not implemented");
        }
        else
        {
            google.maps.event.addDomListener(window, 'load', initializeStreetsMap);
        }
    }

    // Heatmap
    if ($('#maps-heatmap').length)
    {
        google.maps.event.addDomListener(window, 'load', initializeHeatMap);
    }

    // Bar graph
    if ($("#chart").length) {
        var ctx = $("#chart").get(0).getContext("2d");
        window.myBar = new Chart(ctx).Bar(barChartData, {
            responsive: false
        });
    }

});