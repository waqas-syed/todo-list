'use strict';

var app = angular.module('app');

app.controller('todoItemController', ['$scope', '$state', '$stateParams', 'todoListService', function ($scope, $state, $stateParams, todoListService) {

        $scope.priorities = ['High', 'Medium', 'Low'];
    
        $scope.submitNewToDo = function () {
            todoListService.submitNewToDo({
                Description: $scope.description,
                DueDate: $scope.dt,
                Priority: $scope.priority,
                OwnerEmail: $stateParams.email
            }).success(function (response) {
                $state.go('todo-list', { email: $stateParams.email });
            }).error(function (response) {
                console.log(response);
            });
        };

    }
]);