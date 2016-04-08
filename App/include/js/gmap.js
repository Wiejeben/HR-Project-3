function initialize() {

    var latlng = new google.maps.LatLng(35.7022077, 139.7722703);

    var mapOptions = {
        zoom: 8,
        center: latlng
    }

    map = new google.maps.Map(document.getElementById('map'), mapOptions);

    var marker = new google.maps.Marker({
        position: latlng,
        map: map,
        title: 'Hey buddy.'
    });
}

google.maps.event.addDomListener(window, 'load', initialize);