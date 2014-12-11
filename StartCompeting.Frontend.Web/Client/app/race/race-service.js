app.service('raceService', function ($http) {

    var apiPath = '/api/Race';

    var service = {
        loadRaces: loadRaces,
        loadRaceTypes: loadRaceTypes,
        loadRaceById: loadRaceById,
        createRace: createRace,
        updateRace: updateRace
    };

    return service;

    function loadRaces() {
        return $http.get(apiPath).then(function(reply) {
            return reply.data;
        });
    }

    function loadRaceTypes() {
        return $http.get("/api/RaceType").then(function(reply) {
            return reply.data;
        });
    }

    function loadRaceById(id) {
        return $http.get(apiPath + "?id=" + id)
            .then(function(reply) {
                var data = reply.data;
                var formData = {};
                formData.id = data.Id;
                formData.name = data.Name;
                formData.raceTypeId = data.RaceTypeId;
                formData.raceLength = data.RaceLength;
                return formData;
            });
    }

    function createRace(formData) {
        return $http.post(apiPath, formData)
            .then(function (data) {
                return true;
            }
        );
    }

    function updateRace(formData) {
        return $http.put(apiPath, formData)
            .success(function (data) {
            return true;
        });
    }
});