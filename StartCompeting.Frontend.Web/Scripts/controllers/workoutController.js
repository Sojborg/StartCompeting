var app = angular.module('startCompetingApp', ["ngQuickDate"]);

app.controller('WorkoutController', function($scope, $http) {

    $http.get('/api/RaceType').success(function(data) {
        $scope.raceTypes = data;
    });

    $scope.formData = {
    };

    $scope.submit = function() {
        $http.post('/api/RaceType', $scope.formData)
            .success(function(data) {
                alert("saved");
            }
        );
    };
});