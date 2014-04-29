var app = angular.module('startCompetingApp', ["ngQuickDate"]);

app.controller('WorkoutController', function($scope, $http) {

    $http.get('/api/RaceType').success(function(data) {
        $scope.raceTypes = data;
    });

    $http.get('/api/Workout').success(function (data) {
        $scope.workouts = data;
    });

    $scope.formData = {
    };

    $scope.submit = function() {
        $http.post('/api/Workout', $scope.formData)
            .success(function(data) {
                alert("saved");
            }
        );
    };
});