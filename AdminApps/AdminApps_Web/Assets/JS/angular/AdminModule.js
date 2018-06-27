angular.module("Admin", ["ngRoute"]).config(function ($routeProvider) {
    $routeProvider.when("/allUsers", {
        templateUrl: "/Admin/AllUsers"
    }).otherwise({

    });
}).constant("dataUrl", "http://localhost:52055/");