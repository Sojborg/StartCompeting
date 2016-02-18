"use strict";

app.directive('temperature',
    [
    function () {
        return {
            templateUrl: 'Client/app/widgets/temperature/temperature.template.html',
            link: function (scope, el, attrs) {
                scope.selectedLocation = {
                    name: "testing",
                    temperature: 20
                }
            }
        };
}]);