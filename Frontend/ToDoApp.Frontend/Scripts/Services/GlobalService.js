var rentApp = angular.module('app');

rentApp.factory('globalService', function () {
    var defaultServerUrl = 'http://localhost/';
    return {
        serverUrl: defaultServerUrl + 'v1/'
    };
});