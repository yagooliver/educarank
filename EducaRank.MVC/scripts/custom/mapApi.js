var map;
var infoWindow;
var marker;
var longitude;
var latitude;

function initMap(zoom) {
    map = new google.maps.Map(document.getElementById('map'), {
        center: { lat: -3.7319, lng: -38.5267 },
        zoom: zoom
    });
}

consultaEndereco = function (endereco, i, unidadeEscolar, idEscola, colocacao, nota) {
    var parameters = {
        endereco: endereco
    };
    var URL = "https://maps.googleapis.com/maps/api/geocode/json?address=" + parameters.endereco;// + parameters.key

    $.ajax({
        url: URL,
        type: 'GET',
        datatype: 'JSON',
        success: function (response) {
            //marcadores = {
            latitude = response.results[0].geometry.location.lat;
            longitude = response.results[0].geometry.location.lng;
            var icon = {
                url: "../img/school-icon.png", // url
                scaledSize: new google.maps.Size(45, 45), // scaled size
                origin: new google.maps.Point(0, 0), // origin
                anchor: new google.maps.Point(0, 0) // anchor
            };
            marker = new google.maps.Marker({
                position: new google.maps.LatLng(latitude, longitude),
                map: map,
                icon: icon,
                title: unidadeEscolar
            });

            google.maps.event.addListener(marker, 'mouseover', (function (marker, i) {
                return function () {
                    infowindow.setContent(unidadeEscolar);
                    infowindow.open(map, marker);
                }
            })(marker, i));

            google.maps.event.addListener(marker, 'click', (function (marker, i) {
                return function () {
                    $('.modal').empty();
                    $(".modal").load("/Home/DetalheEscola?id=" + idEscola + "&Colocacao=" + colocacao + "&Nota=" + nota, function () {
                        $(".modal").css('width', '100%');
                        $(".modal").modal();
                    })
                }
            })(marker, i));
        }
    })
}


function consultaEscola(escola, bairro, tipoCiclo) {
    var parameters = {
        escola: escola,
        bairro: bairro,
        tipoCiclo: tipoCiclo
    }
    initMap(12);
    var data = JSON.stringify(parameters);
    var url = "/Home/ConsultaEscola";

    $.ajax({
        url: url,
        type: 'POST',
        dataType: 'JSON',
        data: { escolaVM: parameters },
        success: function (response) {
            infowindow = new google.maps.InfoWindow();
            var i;
            for (var i = 0; i < response.length; i++) {
                consultaEndereco(response[i].Endereco, i, response[i].UnidadeEscolar,response[i].idEscola, response[i].Colocacao, response[i].Nota);//response[i].idEscola);
            }
        }
    })
}