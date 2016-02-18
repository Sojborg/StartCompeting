app.directive('homeController', [function() {
    return {
        template: "<dashboard></dashboard>",
        scope: {},
        link: function(scope) {

            scope.title = 'My First Dashboard';

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
                    title: 'Temperature',
                    settings: {
                        sizeX: 3,
                        sizeY: 3,
                        minSizeX: 2,
                        minSizeY: 2,
                        template: '<temperature></temperature>',
                        widgetSettings: {
                            id: 1000,
                            templateUrl: 'app/dialogs/wwaSelectLocationTemplate.html',
                            controller: 'wwaSelectLocationController'
                        }
                    }
                }
                //,
                //{
                //    title: 'Inventory',
                //    settings: {
                //        sizeX: 5,
                //        sizeY: 3,
                //        minSizeX: 2,
                //        minSizeY: 2,
                //        template: '<wwa-inventory></wwa-inventory>',
                //        widgetSettings: {
                //            id: 1002,
                //            templateUrl: 'app/dialogs/wwaSelectLocationTemplate.html',
                //            controller: 'wwaSelectLocationController'
                //        }
                //    }
                //},
                //{
                //    title: 'Employee',
                //    settings: {
                //        sizeX: 5,
                //        sizeY: 3,
                //        minSizeX: 2,
                //        minSizeY: 2,
                //        template: '<wwa-employee></wwa-employee>',
                //        widgetSettings: {
                //            id: 5000,
                //            templateUrl: 'app/dialogs/wwaSelectEmployeeTemplate.html',
                //            controller: 'wwaSelectEmployeeController'
                //        }
                //    }
                //}
            ];

            scope.widgets = [
                {
                    sizeX: 3,
                    sizeY: 3,
                    minSizeX: 2,
                    minSizeY: 2,
                    template: '<temperature></temperature>',
                    widgetSettings: {
                        id: 1000,
                        templateUrl: 'app/dialogs/wwaSelectLocationTemplate.html',
                        controller: 'wwaSelectLocationController'
                    }
                }
            ];
        }
    }
}]);