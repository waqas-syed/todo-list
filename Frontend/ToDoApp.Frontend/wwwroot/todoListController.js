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
            $state.go('add-todo', {email : $stateParams.email});
        };

        $scope.markToDoAsCompleted = function (id) {
            todoListService.getToDoItem({ id: id }).success(function (response) {
                var dt = new Date(Date.parse(response.DueDate));
                var toDo = {
                    Id: response.Id,
                    Description: response.Description,
                    DueDate: new Date(dt.getFullYear(), dt.getMonth(), dt.getDate() + 1),
                    Priority: response.Priority,
                    OwnerEmail: response.OwnerEmail,
                    IsCompleted: true
                };
                todoListService.updateToDo(toDo).success(function (updateRespoonse) {
                    //$state.go('todo-list', { email: $stateParams.email });
                    $state.go($state.current, { email: $stateParams.email }, { reload: true });
                }).error(function (updateError) {
                    console.log(updateError);
                });

            }).error(function (error) {
                console.log(error);
            });
        };

        $scope.deleteToDo = function (id) {
            todoListService.deleteToDo(id).success(function (response) {
                getAllToDos();
            }).error(function (error) {
                console.log(error);
            });
        }
    }
]);