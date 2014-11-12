app.service('raceService', function ($http, $q) {

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

    function loadRaceById(id) {
        var deferred = $q.defer();

        $http.get(apiPath + "?id=" + id)
            .success(function (data) {
                var formData = {};
                formData.id = data.Id;
                formData.name = data.Name;
                formData.raceTypeId = data.RaceTypeId;
                formData.raceLength = data.RaceLength;
                deferred.resolve(formData);
            });

        return deferred.promise;
    }

    function createRace(formData) {
        var deferred = $q.defer();

        $http.post(apiPath, formData)
            .success(function (data) {
                deferred.resolve(true);
            }
        );

        return deferred.promise;
    }

    function updateRace(formData) {
        var deferred = $q.defer();

        $http.put(apiPath, formData)
            .success(function (data) {
                deferred.resolve(true);
            });

        return deferred.promise;
    }
});