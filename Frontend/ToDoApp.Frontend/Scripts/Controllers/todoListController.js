'use strict';

var app = angular.module('app');

app.controller('todoListController', ['$scope', '$state', '$stateParams', 'todoListService', function ($scope, $state, $stateParams, todoListService) {
    
    $scope.priorities = ['High', 'Medium', 'Low'];
        
        var getAllToDos = function() {
            todoListService.getToDosByEmail({ email: $stateParams.email }).success(function (response) {
                $scope.toDoList = response;
            }).error(function (error) {
                console.log(error);
            });
        };
        
        getAllToDos();

        $scope.addNewToDo = function() {
            $state.go('new-todo', {email : $stateParams.email});
        };
    }
]);