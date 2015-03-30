
app.controller("MapController", mapController);

function mapController($scope) {
    $scope.callback = function (map) {
        map.setView([51.433333, 5.483333], 12);
    };
}


app.directive('mapbox', ['workoutService',
    function (workoutService) {
        return {
            restrict: 'EA',
            replace: true,
            scope: {
                callback: "="
            },
            template: '<div></div>',
            link: function (scope, element, attributes) {

                var id = scope.$eval(attributes.workoutId);

                L.mapbox.accessToken = 'pk.eyJ1Ijoic29qYm9yZyIsImEiOiJ4engxV1pZIn0.rbLiVa797JFI-ouJqy5Ytw';
                var map = L.mapbox.map('map', 'sojborg.l1nm7ahj');

                var polyline = L.polyline([]).addTo(map);

                var startLocation = [];
                workoutService.loadWorkoutById(id).then(function (data) {
                    var gpsCoords = data.GpsCoords;

                    for (var i = 0; i < gpsCoords.length; i++) {
                        var lat = gpsCoords[i].Latitude;
                        var long = gpsCoords[i].Longitude;

                        if (i == 0) {
                            startLocation = [lat, long];
                        }

                        polyline.addLatLng(
                        L.latLng(
                           lat,
                           long
                        ));
                    }

                    map.setView(startLocation, 14);
                });
            }
        };
    }
]);