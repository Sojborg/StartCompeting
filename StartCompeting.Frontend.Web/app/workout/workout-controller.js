app.controller('WorkoutController', function($scope, $http, workoutService) {

    $scope.formData = {
    };

    $scope.submit = function () {
        if ($scope.formData.id == undefined || $scope.formData.id == 0)
            workoutService.createWorkout($scope.formData).then(function(data) {
                if (data)
                    $scope.resetWorkout();
            });
        else {

            workoutService.updateWorkout($scope.formData).then(function(data) {
                if (data) {
                    $scope.resetWorkout();
                }
            });
        }
    };

    $scope.getWorkout = function (id) {
        workoutService.loadWorkoutById(id).then(function(data) {
            $scope.formData = data;
        });
    };

    $scope.resetWorkout = function() {
        $scope.form.$setPristine();
        $scope.loadWorkouts();
        alert("saved");
    }

    $scope.loadWorkouts = function() {
        workoutService.loadWorkouts().then(function (data) {
            $scope.workouts = data;
        },
        function (errorMessage) {
            $scope.error = errorMessage;
        });
    }

    $scope.loadRaceTypes = function () {
        workoutService.loadRaceTypes().then(function (data) {
            $scope.raceTypes = data;
        },
        function (errorMessage) {
            $scope.error = errorMessage;
        });
        
    }

    $scope.loadRaceTypes();
    $scope.loadWorkouts();
});