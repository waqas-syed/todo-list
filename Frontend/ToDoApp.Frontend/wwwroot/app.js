(function () {
    'use strict';

    var rentApp = angular.module('app', ['ui.router', 'LocalStorageModule']);

    rentApp.config(["$stateProvider", "$urlRouterProvider", "$httpProvider", "$locationProvider",
            function ($stateProvider, $urlRouterProvider, $httpProvider, $locationProvider) {
                $locationProvider.html5Mode(true);
                $httpProvider.interceptors.push('authInterceptorService');

                $httpProvider.interceptors.push(function () {
                    return {
                        "request": function (config) {
                            if (config.url && config.url.endsWith(".html")) {
                                config.headers["Content-Type"] = "text/html; charset=utf=8";
                                config.headers["Accept"] = "text/html; charset=utf=8";
                            }
                            return config;
                        }
                    };
                });

                $httpProvider.defaults.useXDomain = true;
                $httpProvider.defaults.withCredentials = true;
                delete $httpProvider.defaults.headers.common["X-Requested-With"];
                $httpProvider.defaults.headers.common["Accept"] = "application/json";
                $httpProvider.defaults.headers.common["Content-Type"] = "application/json";
                $httpProvider.defaults.headers.common["X-Requested-With"] = "XMLHttpRequest";
                $urlRouterProvider.otherwise("/home");

                $stateProvider
                    .state("home",
                        {
                            url: "/",
                            templateUrl: "/views/login.html"
                        })
                    .state("login",
                        {
                            url: "/login",
                            controller: "scripts/loginController",
                            templateUrl: "/views/login.html",
                            permissions: { hideFromLoggedInUser: true }
                        })
                    .state("signup",
                        {
                            url: "/signup",
                            controller: "scripts/signupController",
                            templateUrl: "/views/signup.html",
                            permissions: { hideFromLoggedInUser: true}
                        });
            }
        ]
    );

    rentApp.run(["$rootScope", "authService", "$state", "$anchorScroll", function ($rootScope, authService, $state, $anchorScroll) {

        authService.fillAuthData();
        $rootScope.$on('$stateChangeSuccess',
            function(event, next) {
                $anchorScroll();
            });
        $rootScope.$on('$stateChangeStart',
            function(event, next) {
                if (next.permissions !== null && next.permissions !== undefined) {
                    if (authService.authentication.isAuth) {
                        var hideFromLoggedInUser = next.permissions.hideFromLoggedInUser;
                        if (hideFromLoggedInUser !== undefined && hideFromLoggedInUser != null && hideFromLoggedInUser) {
                            event.preventDefault();
                            $state.go('home');
                        }
                    }
                }
            });
        $rootScope.$on('$stateChangeError',
            function(event, toState, toParams, fromState, fromParams, error) {
                //console.log(event);
                //console.log(toState);
                //console.log(toParams);
                //console.log(fromState);
                //console.log(fromParams);
                //console.log(error);
            });

        $rootScope.$on('$stateNotFound',
            function(event, unfoundState, fromState, fromParams) {
                //console.log(event);
                //console.log(unfoundState);
                //console.log(fromState);
                //console.log(fromParams);
            });

        $rootScope.$on('unauthorized', function () {
            authService.logOut();
            $state.go('login');
        });

    }]);
})();