/// <reference path="angular.min.js" />

var app = angular
    .module("Demo", ["ngRoute"])
    .config(function ($routeProvider) {
        $routeProvider
            .when("/home", {
                templateUrl: "Template/home.html",
                controller: "homeController"
            })
            .when("/courses", {
                templateUrl: "Template/courses.html",
                controller: "coursesController"
            })
            .when("/students", {
                templateUrl: "Templates/students.html",
                controller: "studentsController"
            })
    })
    .controller("homeController", function ($scope) {
        $scope.message = "Home Page";


    })
    .controller("coursesController", function ($scope) {
        $scope.courses = ["C#", "VB.NET", "ASP.NET", "SQL Server"];
    })
    .controller("studentsController", function ($scope, $http) {
        $http.get("StudentService/GetAllStudents")
                    .then(function (response) {
                             $scope.students = response.data;
            })

    })
