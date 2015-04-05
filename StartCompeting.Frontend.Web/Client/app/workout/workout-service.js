app.service('workoutService', function ($http, $q) {

    var apiPath = '/api/Workout';

    var service = {
        loadWorkouts: loadWorkouts,
        loadRaceTypes: loadRaceTypes,
        loadWorkoutById: loadWorkoutById,
        loadWorkoutByIdP: loadWorkoutByIdP,
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
                return reply.data;
            });
    }

    function loadWorkoutByIdP(id) {
        var promise = $http.get(apiPath + "?workoutId=" + id);
        return promise;
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
