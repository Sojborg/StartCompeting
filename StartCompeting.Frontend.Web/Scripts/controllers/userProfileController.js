app.controller('UserProfileController', function($scope, $http) {

    var serviceUrl = '/StartCompeting/api/';
    loadUserProfileById(1);

    $scope.formData = {

    };

    $scope.submit = function () {
        if (FormData.id == 0)
            createRace($scope.formData);
        else
            updateRace($scope.formData);
    };

    function loadUserProfileById(id) {
        $http.get(serviceUrl + "UserProfile?id=" + id)
            .success(function (data) {
                $scope.races = data.Races;
                $scope.workouts = data.Workouts;
                //$scope.formData.name =     data.Name;
                //$scope.formData.raceTypeId = data.RaceTypeId;
                //$scope.formData.raceLength = data.RaceLength;
        });
    }
});