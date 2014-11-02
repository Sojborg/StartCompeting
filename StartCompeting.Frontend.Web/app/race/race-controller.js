app.controller('RaceController', function($scope, $http) {

    var serviceUrl = '/api/';
    loadRaces();
    loadRaceTypes();

    $http.get(serviceUrl + "RaceType").success(function (data) {
        $scope.raceTypes = data;
    });

    $scope.formData = {

    };

    $scope.submit = function () {
        if (FormData.id == 0)
            createRace($scope.formData);
        else
            updateRace($scope.formData);
    };

    $scope.getRace = function (id) {
        loadRaceById(id);
    };

    function createRace(formData) {
        $http.post(serviceUrl + 'Race', formData)
            .success(function (data) {
                $scope.form.$setPristine();
                loadRaces();
                alert("saved");
            }
        );
    }

    function updateRace(formData) {
        $http.put(serviceUrl + 'Race', formData)
            .success(function (data) {
                $scope.form.$setPristine();
                loadRaces();
                alert("saved");
            }
        );
    }

    function loadRaceById(id) {
        $http.get(serviceUrl + "Race?id=" + id)
            .success(function (data) {
                $scope.formData.id = data.Id;
                $scope.formData.name = data.Name;
                $scope.formData.raceTypeId = data.RaceTypeId;
                $scope.formData.raceLength = data.RaceLength;
            });
    }

    function loadRaces() {
        $http.get(serviceUrl + "Race").success(function (data) {
            $scope.races = data;
        });
    }

    function loadRaceTypes() {
        $http.get(serviceUrl + "RaceType").success(function (data) {
            $scope.raceTypes = data;
        });
    }
});