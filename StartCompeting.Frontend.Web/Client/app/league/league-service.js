app.service('leagueService', function ($http) {

    var apiPath = '/api/League';

    var service = {
        loadLeagues: loadLeagues,
        loadLeagueTypes: loadLeagueTypes,
        loadLeagueById: loadLeagueById,
        createLeague: createLeague,
        updateLeague: updateLeague
    };

    return service;

    function loadLeagues() {
        return $http.get(apiPath).then(function(reply) {
            return reply.data;
        });
    }

    function loadLeagueTypes() {
        return $http.get("/api/LeagueType").then(function(reply) {
            return reply.data;
        });
    }

    function loadLeagueById(id) {
        return $http.get(apiPath + "?id=" + id)
            .then(function(reply) {
                var data = reply.data;
                var formData = {};
                formData.id = data.Id;
                formData.name = data.Name;
                formData.leagueTypeId = data.LeagueTypeId;
                return formData;
            });
    }

    function createLeague(formData) {
        return $http.post(apiPath, formData)
            .then(function (data) {
                return true;
            }
        );
    }

    function updateLeague(formData) {
        return $http.put(apiPath, formData)
            .success(function (data) {
            return true;
        });
    }
});