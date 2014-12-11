app.service('achievementService', function ($http, $q) {

    var apiPath = '/api/achievement';

    var service = {
        loadAchievements: loadAchievements,
        loadRaceTypes: loadRaceTypes,
        loadAchievementById: loadAchievementById,
        createRace: createRace,
        updateRace: updateRace
    };

    return service;

    function loadAchievements() {
        var deferred = $q.defer();

        $http.get(apiPath).success(function (data) {
            deferred.resolve(data);
        }).error(function () {
            deferred.reject("An error occured while fetching items");
        });

        return deferred.promise;
    }

    function loadAchievementById(id) {
        var deferred = $q.defer();

        $http.get(apiPath + "?id=" + id)
            .success(function (data) {
                var formData = {};
                formData.id = data.Id;
                formData.name = data.Name;
                formData.points = data.Points;
                deferred.resolve(formData);
            });

        return deferred.promise;
    }
});