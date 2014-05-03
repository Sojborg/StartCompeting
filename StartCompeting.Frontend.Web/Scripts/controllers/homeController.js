var app = angular.module('startCompetingApp', []);

app.controller('homeController', function($scope, $http) {

    var serviceUrl = '/StartCompeting/api/';

    $http.get(serviceUrl + "RaceType").success(function (data) {
        $scope.raceTypes = data;
    });

    $scope.formData = {
        name: "Aarhus halvmarathon",
        raceLength: "10",
        RaceTypeId: $scope.raceTypes[1]
        //{
        //    RaceTypeId: "1",
        //    Name: "Running"
        //}
    };

    $scope.submit = function() {
        $http.post('CreateRace', $scope.formData)
            .success(function(data) {
                alert("saved");
            }
        );
    };
});