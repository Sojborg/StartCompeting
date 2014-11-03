var app = angular.module('startCompetingApp', [
    "ngQuickDate",
    "ngRoute"
]);

app.config([
    '$routeProvider',
    function($routeProvider) {
        $routeProvider.
            when('/workouts', {
                templateUrl: 'app/workout/workout-list.html',
                controller: 'WorkoutController'
            }).
            when('/', {
                templateUrl: 'app/home/home.html',
                controller: 'HomeController'
            }).
            otherwise({
                redirectTo: '/'
            });
    }
]);