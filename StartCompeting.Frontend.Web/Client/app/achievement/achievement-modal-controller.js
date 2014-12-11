app.controller('AchievementModalCtrl', function ($scope, $modalInstance, achievementService, achievementId) {

    $scope.formData = {
    };

    $scope.loadAchievementById = function (id) {
        achievementService.loadAchievementById(id).then(function (data) {
            $scope.formData = data;
        });
    }

    $scope.ok = function () {
        $modalInstance.dismiss('cancel');
    };

});