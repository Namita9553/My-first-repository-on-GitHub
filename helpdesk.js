/// <reference path="angular.js" />

var myApp = angular.module("Module", []);
myApp.controller("myController", function ($scope) {
    var service_provider = [{
        profession: "Plumber",
        details: [
        { name: "Abc1", availability: "Yes1", phone_no: "123431", address: "xyz1", likes: 0, dislikes: 0 },
        { name: "Abc21", availability: "Yes21", phone_no: "1234321", address: "xyz21", likes: 0, dislikes: 0 }
        ]
    },

    {
        profession: "Carpenter",
        details: [
        { name: "Abc2", availability: "Yes2", phone_no: "123432", address: "xyz2", likes: 0, dislikes: 0 },
        { name: "Abc22", availability: "Yes22", phone_no: "1234322", address: "xyz22", likes: 0, dislikes: 0 }
        ]
    },
    {
        profession: "Electrician",
        details: [
        { name: "Abc3", availability: "Yes3", phone_no: "123433", address: "xyz3", likes: 0, dislikes: 0 },
        { name: "Abc23", availability: "Yes23", phone_no: "1234323", address: "xyz23", likes: 0, dislikes: 0 }
        ]
    }];
    $scope.service_provider = service_provider;

    $scope.incrementLikes= function (technology)
    {
        technology.likes++;
    }
    $scope.incrementDislikes = function (technology) {
        technology.dislikes++;
    }
    $scope.rowLimit = 5;
    $scope.sortColumn = "name";
}
);
