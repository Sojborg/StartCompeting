var app = angular.module('startCompetingApp', []);

app.controller('RaceController', function($scope, $http) {

    var serviceUrl = '/StartCompeting/api/';
    loadRaces();
    loadRaceTypes();

    $http.get(serviceUrl + "RaceType").success(function (data) {
        $scope.raceTypes = data;
    });

    $scope.formData = {

    };

    $scope.submit = function() {
        $http.post('Race', $scope.formData)
            .success(function (data) {
                $scope.form.$setPristine();
                loadWorkouts();
                alert("saved");
            }
        );
    };

    function loadRaces() {
        $http.get(serviceUrl + "Race").success(function (data) {
            $scope.races = data;
        });
    }

    function loadRaceTypes() {
        $http.get(serviceUrl + "RaceType").success(function (data) {
            $scope.raceTypes = data;
        });
    }
});