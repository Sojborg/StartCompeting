app.controller('RaceController', function($scope, $http, $modal, raceService) {

    loadRaces();

    $scope.formData = {

    };

    $scope.open = function (raceId) {

        var modalInstance = $modal.open({
            templateUrl: 'Client/app/race/race-modal.html',
            controller: 'RaceModalCtrl',
            size: '',
            resolve: {
                raceId: function () {
                    return raceId;
                }
            }
        });

        modalInstance.result.then(function () {
            loadRaces();
        }, function () {
            //$log.info('Modal dismissed at: ' + new Date());
        });
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

    function loadRaces () {
        raceService.loadRaces().then(function (data) {
            $scope.races = data;
        },
        function (errorMessage) {
            $scope.error = errorMessage;
        });
    }
});