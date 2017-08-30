'use strict';

var rentApp = angular.module('app');
rentApp.controller('loginController', ['$scope', '$location', 'authService', function ($scope, $location, authService) {
    
    $scope.message = "";
    $scope.login = function () {
        authService.login($scope.loginData).then(function (response) {
                $location.path('/home');
            },
            function (err) {
                console.log(err);
            });
    };
}]);