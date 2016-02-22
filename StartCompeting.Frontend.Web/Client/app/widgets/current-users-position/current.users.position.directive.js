"use strict";

app.directive('temperature',
    [
    function () {
        return {
            templateUrl: 'Client/app/widgets/current-users-position/current.users.position.html',
            link: function (scope, el, attrs) { 
                scope.selectedLocation = {
                    name: "testing",
                    temperature: 20
                }

                scope.map;
                scope.initMap = function() {
                    scope.map = new google.maps.Map(document.getElementById('widget-map'), {
                        center: { lat: 56.166, lng: 10.216 },
                        zoom: 12
                    });

                    var marker = new google.maps.Marker({
                        icon: "https://chart.googleapis.com/chart?chst=d_bubble_icon_text_small&chld=bus|bbT|9|FF6450|eee",
                        position: new google.maps.LatLng(56.166, 10.216),
                        optimized: true,
                        map: scope.map
                    });
                }
                scope.options = {};

                var widget = el.closest('.gridster-item');
                scope.options.height = widget.height();
                scope.options.width = widget.width();

                widget.resize(function() {
                    if (!scope.map) return;
                    scope.options.width = widget.width();
                    scope.options.height = widget.height();
                    google.maps.event.trigger(scope.map, "resize");
                });

                setTimeout(function () {
                    scope.initMap();
                }, 20);
            }
        };
}]);