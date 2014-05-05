app.service('workoutService', function($http, $q) {
    //var serviceUrl = '/StartCompeting/api/';

    //this.updateWorkout = function(formData) {
    //    $http.put(serviceUrl + "Workout", formData)
    //        .success(function (data) {
    //            //resetWorkout();
    //        }
    //    );
    //}

    //this.createWorkout = function(formData) {
    //    $http.post(serviceUrl + "Workout", formData)
    //        .success(function (data) {
    //            //resetWorkout();
    //        }
    //    );
    //}

    //this.loadWorkoutById = function (id) {
    //    $http.get(serviceUrl + "Workout?workoutId=" + id)
    //        .success(function (data) {
    //            var formData = {};
    //            formData.id = data.Id;
    //            formData.name = data.Name;
    //            formData.startDateTime = data.StartDateTime
    //            formData.raceTypeId = data.RaceTypeId;
    //            formData.length = data.Length;
    //            formData.elapsedHours = data.ElapsedHours;
    //            formData.elapsedMinutes = data.ElapsedMinutes;
    //            formData.elapsedSeconds = data.ElapsedSeconds;
    //            formData.avgSpeed = data.AvgSpeed;
    //        });
    //}

    ////this.loadWorkouts = function () {
    ////    $http.get(serviceUrl + "Workout").success(function (data) {
    ////        var workouts = data;
    ////        return workouts;
    ////    });
    ////}

    //this.loadRaceTypes = function () {
    //    $http.get(serviceUrl + "RaceType").success(function (data) {
    //        //$scope.raceTypes = data;
    //        return data;
    //    });
    //}

    return{
        apiPath: '/StartCompeting/api/Workout',

        loadWorkouts: function() {
            var deferred = $q.defer();

            $http.get(this.apiPath).success(function(data) {
                deferred.resolve(data);
            }).error(function() {
                deferred.reject("An error occured while fetching items");
            });

            return deferred.promise;
        },

        loadRaceTypes: function () {
            var deferred = $q.defer();

            $http.get("/StartCompeting/api/RaceType").success(function (data) {
                deferred.resolve(data);
            }).error(function () {
                deferred.reject("An error occured while fetching items");
            });

            return deferred.promise;
        },

        loadWorkoutById: function (id) {
            var deferred = $q.defer();

            $http.get(this.apiPath + "?workoutId=" + id)
                .success(function (data) {
                    var formData = {};
                    formData.id = data.Id;
                    formData.name = data.Name;
                    formData.startDateTime = data.StartDateTime
                    formData.raceTypeId = data.RaceTypeId;
                    formData.length = data.Length;
                    formData.elapsedHours = data.ElapsedHours;
                    formData.elapsedMinutes = data.ElapsedMinutes;
                    formData.elapsedSeconds = data.ElapsedSeconds;
                    formData.avgSpeed = data.AvgSpeed;
                    deferred.resolve(formData);
                });

            return deferred.promise;
        },

        createWorkout: function (formData) {
            var deferred = $q.defer();

            $http.post(this.apiPath, formData)
                .success(function (data) {
                    deferred.resolve(true);
                }
            );

            return deferred.promise;
        },

        updateWorkout: function(formData) {
            var deferred = $q.defer();

            $http.put(this.apiPath, formData)
                .success(function(data) {
                    deferred.resolve(true);
                });

            return deferred.promise;
        }
    }
});