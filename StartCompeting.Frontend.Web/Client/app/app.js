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
                templateUrl: 'Client/app/workout/workout-list.html',
                controller: 'WorkoutController'
            }).
            when('/races', {
                templateUrl: 'Client/app/race/race-list.html',
                controller: 'RaceController'
            }).
            when('/achievement', {
                templateUrl: 'Client/app/race/achievement-list.html',
                controller: 'AchievementController'
            }).
            when('/', {
                templateUrl: 'Client/app/home/home.html',
                controller: 'HomeController'
            }).
            otherwise({
                redirectTo: '/'
            });
    }
]);