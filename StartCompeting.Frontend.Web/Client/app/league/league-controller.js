app.controller('LeagueController', function($scope, $http, leagueService) {

    loadLeagues();

    $scope.formData = {

    };

    $scope.open = function (raceId) {

        //var modalInstance = $modal.open({
        //    templateUrl: 'Client/app/league/league-modal.html',
        //    controller: 'LeagueModalCtrl',
        //    size: '',
        //    resolve: {
        //        raceId: function () {
        //            return raceId;
        //        }
        //    }
        //});

        //modalInstance.result.then(function () {
        //    loadLeagues();
        //}, function () {
        //    //$log.info('Modal dismissed at: ' + new Date());
        //});
    };

    $scope.submit = function () {
        if (FormData.id == 0)
            createLeague($scope.formData);
        else
            updateLeague($scope.formData);
    };

    $scope.getLeague = function (id) {
        loadLeagueById(id);
    };

    function loadLeagues () {
        leagueService.loadLeagues().then(function (data) {
            $scope.leagues = data;
        },
        function (errorMessage) {
            $scope.error = errorMessage;
        });
    }
});