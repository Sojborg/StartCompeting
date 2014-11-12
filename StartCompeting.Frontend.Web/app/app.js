var app = angular.module('startCompetingApp', [
    "ngQuickDate",
    "ngRoute",
    "ui.bootstrap"
]);

app.config([
    '$routeProvider',
    function($routeProvider) {
        $routeProvider.
            when('/workouts', {
                templateUrl: 'app/workout/workout-list.html',
                controller: 'WorkoutController'
            }).
            when('/races', {
                templateUrl: 'app/race/race-list.html',
                controller: 'RaceController'
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