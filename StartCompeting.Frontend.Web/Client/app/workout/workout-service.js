app.service('workoutService', function ($http, $q) {

    var apiPath = '/api/Workout';

    var service = {
        loadWorkouts: loadWorkouts,
        loadRaceTypes: loadRaceTypes,
        loadWorkoutById: loadWorkoutById,
        createWorkout: createWorkout,
        updateWorkout: updateWorkout
    };

    return service;

    function loadWorkouts() {
        var deferred = $q.defer();

        $http.get(apiPath).success(function (data) {
            deferred.resolve(data);
        }).error(function () {
            deferred.reject("An error occured while fetching items");
        });

        return deferred.promise;
    }

    function loadRaceTypes() {
        var deferred = $q.defer();

        $http.get("/api/RaceType").success(function (data) {
            deferred.resolve(data);
        }).error(function () {
            deferred.reject("An error occured while fetching items");
        });

        return deferred.promise;
    }

    function loadWorkoutById(id) {
        var deferred = $q.defer();

        $http.get(apiPath + "?workoutId=" + id)
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
    }

    function createWorkout(formData) {
        var deferred = $q.defer();

        $http.post(apiPath, formData)
            .success(function (data) {
                deferred.resolve(true);
            }
        );

        return deferred.promise;
    }

    function updateWorkout(formData) {
        var deferred = $q.defer();

        $http.put(apiPath, formData)
            .success(function (data) {
                deferred.resolve(true);
            });

        return deferred.promise;
    }
});
