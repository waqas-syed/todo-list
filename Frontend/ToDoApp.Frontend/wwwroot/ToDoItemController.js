'use strict';

var app = angular.module('app');

app.controller('todoItemController', [
    '$scope', '$state', '$stateParams', 'todoListService', 'authService',
    function ($scope, $state, $stateParams, todoListService, authService) {

    $scope.inEditMode = false;

    authService.fillAuthData();
    if (authService.authentication.isAuth) {
        $scope.email = authService.authentication.email;
    }

    $scope.priorities = ['High', 'Medium', 'Low'];
    if ($stateParams.id !== null &&$stateParams.id !== undefined) {
        todoListService.getToDoItem({ id: $stateParams.id }).success(function (response) {
            $scope.dt = new Date(Date.parse(response.DueDate));
            $scope.description = response.Description;
            $scope.priority = response.Priority;
            $scope.email = response.OwnerEmail;
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
                    OwnerEmail: $scope.email
                };
                todoListService.updateToDo(toDo).success(function (response) {
                    $state.go('todo-list', { email: $scope.email });
                }).error(function (response) {
                    console.log(response);
                });
            } else {
                var toDo = {
                    Description: $scope.description,
                    DueDate: new Date($scope.dt.getFullYear(), $scope.dt.getMonth(), $scope.dt.getDate() + 1),
                    Priority: $scope.priority,
                    OwnerEmail: $scope.email
                };
                todoListService.submitNewToDo(toDo).success(function(response) {
                    $state.go('todo-list', { email: $scope.email });
                }).error(function(response) {
                    console.log(response);
                });
            }
        };
    }
]);