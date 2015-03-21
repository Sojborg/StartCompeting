(function() {
    require.config({
        baseUrl: 'Client/app',
        urlArgs: 'v=1.0',
        paths: {
            'app' : 'app',
            'angular': '../bower_components/angular/angular',
            'angular-loading-bar': '../bower_components/angular-loading-bar/angular-loading-bar/build/loading-bar',
            'ngRoute': '../bower_components/angular-route/angular-route',
            'angular-smart-table': '../bower_components/angular-smart-table/dist/smart-table',
            'ngAnimate': '../bower_components/angular-animate/angular-animate',
            'ngQuickDate': '../bower_components/ngQuickDate/ng-quick-date',
            'NewWorkoutController': '/workout/new-workout-controller.js',
            'WorkoutController': '/workout/workout-controller.js',
            'workoutService': '/workout/workout-service.js'
        }
    });
});