var rentApp = angular.module('app');

rentApp.factory('globalService', function () {
    var defaultServerUrl = 'http://localhost:55467/';
    return {
        serverUrl: defaultServerUrl + 'v1/',
        serverUrlWithoutVersion: defaultServerUrl
    };
});