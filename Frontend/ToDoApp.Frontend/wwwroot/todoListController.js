'use strict';

var app = angular.module('app');

app.controller('todoListController', ['$scope', '$state', '$stateParams', 'todoListService', function ($scope, $state, $stateParams, todoListService) {

        $scope.priorities = ['High', 'Medium', 'Low'];
        todoListService.getToDosByEmail({email:$stateParams.email}).success(function(response) {
            $scope.ToDoList = response;
        }).error(function(error) {
            console.log(error);
        });

        $scope.addNewToDo = function() {
            $state.go('new-todo');
        };

    }
]);