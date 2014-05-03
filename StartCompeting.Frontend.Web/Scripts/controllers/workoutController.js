var app = angular.module('startCompetingApp', ["ngQuickDate"]);

app.controller('WorkoutController', function($scope, $http) {

    var serviceUrl = '/StartCompeting/api/';

    loadRaceTypes();
    loadWorkouts();

    $scope.formData = {
    };

    $scope.submit = function() {
        $http.post(serviceUrl + "Workout", $scope.formData)
            .success(function (data) {
                $scope.form.$setPristine();
                loadWorkouts();
                alert("saved");
            }
        );
    };

    $scope.getWorkout = function (id) {
        loadWorkoutById(id);
    };

    function loadWorkoutById(id) {        
        $http.get(serviceUrl + "Workout?workoutId=" + id)
            .success(function (data) {
                $scope.formData.name = data.Name;
                $scope.formData.startDateTime = data.StartDateTime
                $scope.formData.raceTypeId = data.RaceTypeId;
                $scope.formData.length = data.Length;
                $scope.formData.elapsedHours = data.ElapsedHours;
                $scope.formData.elapsedMinutes = data.ElapsedMinutes;
                $scope.formData.elapsedSeconds = data.ElapsedSeconds;
                $scope.formData.avgSpeed = data.AvgSpeed;
            });
    }

    function loadWorkouts() {
        $http.get(serviceUrl + "Workout").success(function (data) {
            $scope.workouts = data;
        });
    }

    function loadRaceTypes() {
        $http.get(serviceUrl + "RaceType").success(function (data) {
            $scope.raceTypes = data;
        });
    }
});