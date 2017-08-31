'use strict';

var app = angular.module('app');

app.controller('todoListController', [
    '$scope', '$state', 'todoListService', 'NgTableParams', '$filter', 'authService',
    function ($scope, $state, todoListService, NgTableParams, $filter, authService) {
    
        authService.fillAuthData();
        if (authService.authentication.isAuth) {
            $scope.email = authService.authentication.email;
        }

    $scope.priorities = ['High', 'Medium', 'Low'];
        $scope.tableParams = new NgTableParams({
            sorting: {
                Id: 'asc'
            }
        }, {
            getData: function (params) {
                todoListService.getToDosByEmail({ email: $scope.email, sort: params.orderBy() }).success(
                        function(response) {
                            $scope.toDoList = response;
                            //$scope.toDoList = params.orderBy() ? $filter('orderBy')($scope.toDoList, params.orderBy()) : $scope.toDoList;
                        }).error(function(error) {
                        console.log(error);
                    });
            }
        });
    
        $scope.addNewToDo = function() {
            $state.go('add-todo', {email : $scope.email});
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
                    $state.go($state.current, { email: $scope.email }, { reload: true });
                }).error(function (updateError) {
                    console.log(updateError);
                });

            }).error(function (error) {
                console.log(error);
            });
        };

        $scope.deleteToDo = function (id) {
            todoListService.deleteToDo(id).success(function (response) {
                todoListService.getToDosByEmail({ email: $scope.email }).success(
                    function (response) {
                        $state.go($state.current, { email: $scope.email }, { reload: true });
                    }).error(function (error) {
                    console.log(error);
                });
            }).error(function (error) {
                console.log(error);
            });
        }
    }
]);