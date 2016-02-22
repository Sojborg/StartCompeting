
app.controller("MapController", mapController);

function mapController($scope) {
    $scope.callback = function (map) {
        map.setView([51.433333, 5.483333], 12);
    };
}


app.directive('mapbox', ['workoutService',
    function () {
        return {
            restrict: 'EA',
            replace: true,
            scope: {
                coords: "="
            },
            template: '<div></div>',
            link: function (scope, element, attributes) {

                var id = scope.$eval(attributes.workoutId);

                L.mapbox.accessToken = 'pk.eyJ1Ijoic29qYm9yZyIsImEiOiJ4engxV1pZIn0.rbLiVa797JFI-ouJqy5Ytw';
                var map = L.mapbox.map('map', 'sojborg.l1nm7ahj');

                var polyline = L.polyline([]).addTo(map);

                scope.coords.then(function (reply) {
                    var gpsCoords = reply.data.gpsCoords;

                    if (gpsCoords.length > 0) {
                        var startLocation = [gpsCoords[0].latitude, gpsCoords[1].longitude];

                        for (var i = 0; i < gpsCoords.length; i++) {
                            var lat = gpsCoords[i].latitude;
                            var long = gpsCoords[i].longitude;

                            polyline.addLatLng(
                                L.latLng(
                                    lat,
                                    long
                                ));
                        }

                        map.setView(startLocation, 11);
                    }
                });
            }
        };
    }
]);