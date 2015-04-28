var map;
var imageGreen = 'http://maps.google.com/mapfiles/ms/icons/green-dot.png'
var imageBlue = 'http://maps.google.com/mapfiles/ms/icons/blue-dot.png'
var imageRed = 'http://maps.google.com/mapfiles/ms/icons/red-dot.png'
var markers = [];


function initialize() {
    var mapOptions = {
        zoom: 16,
        center: new google.maps.LatLng(-25.284, -57.637),
        mapTypeId: google.maps.MapTypeId.ROADMAP
    };

   

    map = new google.maps.Map(document.getElementById('map-canvas'),
        mapOptions);

    var ctaLayer = new google.maps.KmlLayer({ url: 'http://app.cidesa.com.py/ph/maps/PH-MCALLOPEZ.kml' });
    ctaLayer.setMap(map);


    //var imageGreen = 'http://maps.google.com/mapfiles/ms/icons/green-dot.png'
    //var imageBlue = 'http://maps.google.com/mapfiles/ms/icons/blue-dot.png'
    //var imageRed = 'http://maps.google.com/mapfiles/ms/icons/red-dot.png'

    //var myLatLng = new google.maps.LatLng(-25.284573746213134, -57.63796601977447);
    //var myLatLng1 = new google.maps.LatLng(-25.285573746213134, -57.63796601977447);
    //var myLatLng2 = new google.maps.LatLng(-25.286573746213134, -57.63796601977447);

    //var beachMarker = new google.maps.Marker({
    //    position: myLatLng,
    //    map: map,
    //    icon: imageRed

    //});

    //var marker2 = new google.maps.Marker({
    //    position: myLatLng1,
    //    map: map,
    //    icon: imageGreen

    //});

    //var marker3 = new google.maps.Marker({
    //    position: myLatLng2,
    //    map: map,
    //    icon: imageBlue

    //});



    //beachMarker.setIcon('http://maps.google.com/mapfiles/ms/icons/red-dot.png')

   


}

// Sets the map on all markers in the array.
function setAllMap(map) {
    for (var i = 0; i < markers.length; i++) {
        markers[i].setMap(map);
    }
}


// Removes the overlays from the map, but keeps them in the array.
function clearOverlays() {
    setAllMap(null);
}

function initializeWithClick() {
    var mapOptions = {
        zoom: 16,
        center: new google.maps.LatLng(-25.284, -57.637),
        mapTypeId: google.maps.MapTypeId.ROADMAP
    };

    map = new google.maps.Map(document.getElementById('map-canvas'),
        mapOptions);

    //https://skydrive.live.com/redir?resid=337365EE0300EEC2!1599&authkey=!AEUPGc077Sqg_js
    //http://app.cidesa.com.py/PH-MCALLOPEZ.kml

    //var ctaLayer = new google.maps.KmlLayer({ url: 'http://app.cidesa.com.py/ph/maps/PH-MCALLOPEZ.kml' });
    //ctaLayer.setMap(map);

    google.maps.event.addListener(map, 'click', seleccionar)

    geocoder = new google.maps.Geocoder();

    //google.maps.event.addListener(map, 'click', function (event) {
    //    document.getElementById('MainContent_txtLat').value = event.latLng.lat() + ', ' + event.latLng.lng()
    //})

}




function SetMarker(tipo, lat, lng) {
    switch (tipo) {
        case "1":
            imgIcon = imageGreen;
            break;
        case "2":
            imgIcon = imageRed;
            break;
        case "3":
            imgIcon = imageBlue;
            break;
        default:
            imgIcon = imageGreen;
    }


    imgIcon = '/Images/Geo/' + tipo;

    var myLatLng = new google.maps.LatLng(lat, lng);
    var beachMarker = new google.maps.Marker({
        position: myLatLng,
        map: map,
        icon: imgIcon
    });
    markers.push(beachMarker);
}