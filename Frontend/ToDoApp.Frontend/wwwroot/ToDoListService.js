var app = angular.module('app');

app.factory('todoListService', ['$http', '$q', 'globalService', function ($http, $q, globalService) {
    return {
        getToDosByEmail: function (searchParameters) {
            return $http.get(globalService.serverUrl + 'todoitem', { params: searchParameters })
                .success(function (response) {
                    return response;
                })
                .error(function (error) {
                    return error;
                });
        },
        getToDoItem: function (searchParameters) {
            return $http.get(globalService.serverUrl + 'todoitem', { params: searchParameters })
                .success(function (response) {
                    return response;
                })
                .error(function (error) {
                    return error;
                });
        },
        submitNewToDo: function(todo) {
            return $http.post(globalService.serverUrl + 'todoitem', todo)
                .success(function (response) {
                    return response;
                })
                .error(function (error) {
                    return error;
                });
        },
        updateToDo: function (todo) {
            return $http.put(globalService.serverUrl + 'todoitem', todo)
                .success(function (response) {
                    return response;
                })
                .error(function (error) {
                    return error;
                });
        },
        deleteToDo: function (id) {
            return $http.delete(globalService.serverUrl + 'todoitem/' + id)
                .success(function (response) {
                    return response;
                })
                .error(function (error) {
                    return error;
                });
        }
    };
}]);