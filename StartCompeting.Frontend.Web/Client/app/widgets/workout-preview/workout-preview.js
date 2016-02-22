"use strict";

app.directive('workoutPreview',
    ['workoutService',
    function (workoutService) {
        return {
            templateUrl: 'Client/app/widgets/workout-preview/workout-preview.html',
            link: function (scope, el, attrs) {
                scope.workout = {};
                workoutService.loadWorkoutById(3).then(function (data) {
                    scope.workout = data;
                });

            }
        };
}]);