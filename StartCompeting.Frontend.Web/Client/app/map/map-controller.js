
app.controller("MapController", mapController);

function mapController($scope) {
    $scope.callback = function (map) {
        map.setView([51.433333, 5.483333], 12);
    };
}


app.directive('mapbox', [
    function () {
        return {
            restrict: 'EA',
            replace: true,
            scope: {
                callback: "="
            },
            template: '<div></div>',
            link: function (scope, element, attributes) {
                L.mapbox.accessToken = 'pk.eyJ1Ijoic29qYm9yZyIsImEiOiJ4engxV1pZIn0.rbLiVa797JFI-ouJqy5Ytw';
                var map = L.mapbox.map('map', 'sojborg.l1nm7ahj');

                var polyline = L.polyline([]).addTo(map);

                polyline.addLatLng(
                    L.latLng(
                        ))

                scope.callback(map);
            }
        };
    }
]);