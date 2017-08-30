'use strict';

var app = angular.module('app');

app.controller('todoItemController', ['$scope', '$state', '$stateParams', 'todoListService', function ($scope, $state, $stateParams, todoListService) {
        $scope.inEditMode = false;
    $scope.priorities = ['High', 'Medium', 'Low'];
        if ($stateParams.id !== null &&$stateParams.id !== undefined) {
            todoListService.getToDoItem({ id: $stateParams.id }).success(function (response) {
                $scope.dt = new Date(Date.parse(response.DueDate));
                $scope.description = response.Description;
                $scope.priority = response.Priority;
                $stateParams.email = response.OwnerEmail;
                $scope.inEditMode = true;
            }).error(function(error) {
                console.log(error);
            });
    };
    
        $scope.submitNewToDo = function () {
            if ($scope.dt === null || $scope.dt === undefined) {
                $scope.dt = new Date();
            }
            
            if ($scope.inEditMode) {
                var toDo = {
                    Id: $stateParams.id,
                    Description: $scope.description,
                    DueDate: new Date($scope.dt.getFullYear(), $scope.dt.getMonth(), $scope.dt.getDate() + 1),
                    Priority: $scope.priority,
                    OwnerEmail: $stateParams.email
                };
                todoListService.updateToDo(toDo).success(function (response) {
                    $state.go('todo-list', { email: $stateParams.email });
                }).error(function (response) {
                    console.log(response);
                });
            } else {
                var toDo = {
                    Description: $scope.description,
                    DueDate: new Date($scope.dt.getFullYear(), $scope.dt.getMonth(), $scope.dt.getDate() + 1),
                    Priority: $scope.priority,
                    OwnerEmail: $stateParams.email
                };
                todoListService.submitNewToDo(toDo).success(function(response) {
                    $state.go('todo-list', { email: $stateParams.email });
                }).error(function(response) {
                    console.log(response);
                });
            }
        };
    }
]);