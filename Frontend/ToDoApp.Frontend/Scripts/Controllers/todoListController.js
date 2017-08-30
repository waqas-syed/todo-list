'use strict';

var app = angular.module('app');

app.controller('todoListController', ['$scope', '$stateParams', 'todoListService', function ($scope, $stateParams, todoListService) {

        todoListService.getToDosByEmail({email:$stateParams.email}).success(function(response) {
            $scope.ToDoList = response;
        }).error(function(error) {
            console.log(error);
        });
    }
]);