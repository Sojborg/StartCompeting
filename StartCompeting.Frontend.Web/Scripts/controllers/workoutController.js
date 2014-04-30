var app = angular.module('startCompetingApp', ["ngQuickDate"]);

app.controller('WorkoutController', function($scope, $http) {

    var serviceUrl = '/StartCompeting/api/';

    $http.get(serviceUrl + "RaceType").success(function (data) {
        $scope.raceTypes = data;
    });

    $http.get(serviceUrl + "Workout").success(function (data) {
        $scope.workouts = data;
    });

    $scope.formData = {
    };

    $scope.submit = function() {
        $http.post(serviceUrl + "Workout", $scope.formData)
            .success(function(data) {
                alert("saved");
            }
        );
    };
});