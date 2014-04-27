var app = angular.module('startCompetingApp', ["ngQuickDate"]);

app.controller('WorkoutController', function($scope, $http) {

    $http.get('GetRaceTypes').success(function(data) {
        $scope.raceTypes = data;
    });

    $http.get('/TestApi/Get').success(function (data) {
        alert(data);
    });

//    $scope.raceTypes = [
//    {
//        RaceType:
//            {
//                RaceTypeId:
//                    "1",
//                Name:
//                "Cycling"
//            }
//    },
//    {
//        RaceType:
//        {
//            RaceTypeId:
//                "2",
//            Name:
//                "Running"
//        }
//    },
//    {
//        RaceType:
//        {
//            RaceTypeId:
//                "3",
//            Name:
//                "Swimming"
//        }
//    }
//];

    $scope.formData = {
    };

    $scope.submit = function() {
        $http.post('CreateWorkout', $scope.formData)
            .success(function(data) {
                alert("saved");
            }
        );
    };
});