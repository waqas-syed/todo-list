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
        }
    };
}]);