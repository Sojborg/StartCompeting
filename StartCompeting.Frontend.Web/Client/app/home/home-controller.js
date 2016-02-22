app.directive('homeController', [function () {
    return {
        template: "<dashboard></dashboard>",
        scope: {},
        link: function (scope) {

            scope.gridsterOpts = {
                columns: 12,
                margins: [20, 20],
                outerMargin: false,
                pushing: true,
                floating: false,
                swapping: false
            };

            scope.widgetDefinitions = [
                {
                    title: 'Current online users',
                    settings: {
                        sizeX: 3,
                        sizeY: 3,
                        minSizeX: 2,
                        minSizeY: 2,
                        template: '<current-users-position></current-users-position>'
                    }
                },
                {
                    title: 'Latest work',
                    settings: {
                        sizeX: 2,
                        sizeY: 2,
                        minSizeX: 2,
                        minSizeY: 2,
                        template: '<workout-preview></workout-preview>'
                    }
                }
            ];

            scope.widgets = [
                {
                    sizeX: 3,
                    sizeY: 3,
                    minSizeX: 5,
                    minSizeY: 2,
                    template: '<current-users-position></current-users-position>'
                },
                {
                    sizeX: 2,
                    sizeY: 3,
                    minSizeX: 2,
                    minSizeY: 2,
                    template: '<workout-preview></workout-preview>'
                }
            ];
        }
    }
}]);