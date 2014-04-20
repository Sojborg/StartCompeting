var app = angular.module('startCompetingApp', []);

app.controller('HomeController', function($scope, $http) {

    //$http.get('Home/Users').success(function(data) {
    //    $scope.users = data;
    //});

    $scope.raceTypes = [
    {
        RaceType:
            {
                RaceTypeId:
                    "1",
                Name:
                "Running"
            }
    },
    {
        RaceType:
        {
            RaceTypeId:
                "2",
            Name:
                "Biking"
        }
    },
    {
        RaceType:
        {
            RaceTypeId:
                "3",
            Name:
                "Swimming"
        }
    }
];

    $scope.formData = {
        name: "Aarhus halvmarathon",
        raceLength: "10",
        RaceTypeId: $scope.raceTypes[1]
        //{
        //    RaceTypeId: "1",
        //    Name: "Running"
        //}
    };

    

    $scope.submit = function() {
        $http.post('CreateRace', $scope.formData)
            .success(function(data) {
                alert("saved");
            }
        );
    };
});