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
        return $http.get(apiPath).then(function(reply) {
            return reply.data;
        });
    }

    function loadRaceTypes() {
        return $http.get("/api/RaceType").then(function(reply) {
            return reply.data;
        });
    }

    function loadWorkoutById(id) {
        return $http.get(apiPath + "?workoutId=" + id)
            .then(function(reply) {
                var data = reply.data;
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
                return formData;
            });
    }

    function createWorkout(formData) {
        return $http.post(apiPath, formData)
            .then(function (reply) {
                return true;
            }
        );
    }

    function updateWorkout(formData) {
        return $http.put(apiPath, formData)
            .then(function (reply) {
            return true;
        });
    }
});
