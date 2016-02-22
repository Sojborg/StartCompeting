"use strict";

angular.module('dashboard').directive('dashboard', function () {
    return {
        templateUrl: 'Client/ext-modules/dashboard/dashboard.template.html',
        link: function (scope, element, attrs) {
            scope.showAddWidgetButton = true;

            scope.toggleAddWidget = function() {
                scope.showAddWidgetButton = !scope.showAddWidgetButton;
            }

            scope.addNewWidget = function (widget) {
                var newWidget = angular.copy(widget.settings);
                scope.widgets.push(newWidget);
                scope.toggleAddWidget();
            }

            scope.selectedWidget;
        }
    };
});