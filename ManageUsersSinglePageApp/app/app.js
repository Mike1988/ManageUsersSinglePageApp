// App Config
var app = angular.module('myApp', ['ngRoute']);

app.config(function ($routeProvider) {
    $routeProvider
        .when('/', {
            controller: 'ListUserController',
            templateUrl: 'app/views/user/ListAllUsers.html'
        })
        .when('/User/Create', {
            controller: 'CreateUserController',
            templateUrl: 'app/views/user/Create.html'
        })
        .when('/User/Edit/:id', {
            controller: 'EditUserController',
            templateUrl: 'app/views/user/Edit.html'
        })
        .otherwise({
            redirectTo: '/'
        });
});

// Controllers
app.controller('ListUserController', ['$scope', '$http', function ($scope, $http) {
    $http.get('/User/ListAllUsers')
        .then(function successCallback(response) {   
            if (response.data.success === true) {
                $scope.users = response.data.result;
            }
        });
}]);

app.controller('CreateUserController', ['$scope', '$http', '$location', '$window', function ($scope, $http, $location, $window) {
    $scope.submit = function () {
        var user = {
            "Name": $scope.Name,
            "Age": $scope.Age,
            "Address": $scope.Address
        }

        $http.post('/User/Create', user)
            .then(function successCallback(response) {
                checkValidData($scope, $window, response)
            });        
    }
}]);

app.controller('EditUserController', ['$scope', '$http', '$routeParams', '$window', function ($scope, $http, $routeParams, $window) {
    var id = $routeParams.id;

    $http.get('/User/GetById?id=' + id)
        .then(function successCallback(response) {
            if (response.data.success === true) {
                $scope.user = response.data.result;
            }
        });

    $scope.submit = function () {
        var user = {
            "Id": $scope.user.Id,
            "Name": $scope.user.Name,
            "Age": $scope.user.Age,
            "Address": $scope.user.Address
        }

        $http.post('http://localhost:57287/User/Edit', user)
            .then(function successCallback(response) {
                checkValidData($scope, $window, response)
        });
    }
}]);

//app.factory('listUsers', ['$http', function ($http) {
//    return $http.get('/User/ListAllUsers')
//        .then(function successCallback(data) {
//            return data;
//        });
//        //.error(function (err) {
//        //    return err;
//        //});
//}]);

function checkValidData($scope, $window, response) {
    if (response.data.success === false) {
        $scope.validationErrors = [];

        var error = response.data.errors;
        for (var key in error) {
            $scope.validationErrors.push(error[key][0]);
        }
    }
    else {
        $window.location.href = '/';
    }
}