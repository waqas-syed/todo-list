'use strict';

var app = angular.module('app');

app.controller('todoItemController', ['$scope', '$state', '$stateParams', 'todoListService', function ($scope, $state, $stateParams, todoListService) {

        $scope.priorities = ['High', 'Medium', 'Low'];
    
        $scope.submitNewToDo = function () {
            var toDo = {
                Description: $scope.description,
                DueDate: new Date($scope.dt.getFullYear(), $scope.dt.getMonth(), $scope.dt.getDate() + 1),
                Priority: $scope.priority,
                OwnerEmail: $stateParams.email
            };
            todoListService.submitNewToDo(toDo).success(function (response) {
                $state.go('todo-list', { email: $stateParams.email });
            }).error(function (response) {
                console.log(response);
            });
        };

    }
]);