var app = angular.module('startCompetingApp', [
    "ngQuickDate",
    "ngRoute",
    "angular-loading-bar",
    "ngAnimate",
    "ngMaterial",
    "dashboard",
    "uiGmapgoogle-maps",
    "md.data.table"
]);

app.config([
    '$routeProvider',
    function($routeProvider) {
        $routeProvider.
            when('/workouts', {
                templateUrl: 'Client/app/workout/workout-list.html',
                controller: 'WorkoutController'
            }).
            when('/newworkout/:workoutId?', {
                templateUrl: 'Client/app/workout/new-workout.html',
                controller: 'NewWorkoutController'
            }).
            when('/races', {
                templateUrl: 'Client/app/race/race-list.html',
                controller: 'RaceController'
            }).
            when('/newrace/:raceId?', {
                templateUrl: 'Client/app/race/new-race.html',
                controller: 'NewRaceController'
            }).
            when('/achievement', {
                templateUrl: 'Client/app/race/achievement-list.html',
                controller: 'AchievementController'
            }).
            when('/leagues', {
                templateUrl: 'Client/app/league/league-list.html',
                controller: 'LeagueController'
            }).
            when('/map', {
                templateUrl: 'Client/app/map/map.html',
                controller: 'MapController'
            }).
            when('/', {
                template: '<home-controller></home-controller>',
            }).
            otherwise({
                redirectTo: '/'
            });
    }
]);