"use strict";

app.directive('workoutPreview',
    ['workoutService',
    function (workoutService) {
        return {
            templateUrl: 'Client/app/widgets/workout-preview/workout-preview.html',
            link: function (scope, el, attrs) {
                scope.workouts = [];
                scope.workout = {};
                workoutService.loadWorkouts().then(function (data) {
                    scope.workouts = data;
                    scope.setCurrentWorkout(_.last(data));
                });

                scope.previousPage = function() {
                    var index = scope.workouts.indexOf(scope.workout);
                    if (index > 0) {
                        var previousWorkout = scope.workouts[index-1];
                        scope.setCurrentWorkout(previousWorkout);
                    }
                }

                scope.nextPage = function() {
                    var index = scope.workouts.indexOf(scope.workout);
                    if ((index+1) < scope.workouts.length) {
                        var nextWorkout = scope.workouts[index+1];
                        scope.setCurrentWorkout(nextWorkout);
                    }
                }

                scope.setCurrentWorkout = function(workout) {
                    scope.workout = workout;
                }

                scope.getTypeIcon = function(id) {
                    switch (id) {
                    case 1:
                        return "fa-child";
                    case 2:
                        return "fa-child";
                    default:
                        return "fa-hashtag";
                    }
                }

                scope.getLocalDate = function(date) {
                    return date.toLocaleDateString();
                }
            }
        };
}]);