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
            $scope.users = response.data;
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
            .then(function successCallback() {
                //$location.path('/#!/User/');
                $window.location.href = '/';
            });
    }
}]);

app.controller('EditUserController', ['$scope', '$http', '$routeParams', '$window', function ($scope, $http, $routeParams, $window) {
    var id = $routeParams.id;

    $http.get('/User/GetById?id=' + id)
        .then(function successCallback(response) {
            $scope.user = response.data;
        });

    $scope.submit = function () {
        var user = {
            "Id": $scope.user.Id,
            "Name": $scope.user.Name,
            "Age": $scope.user.Age,
            "Address": $scope.user.Address
        }

        $http.post('http://localhost:57287/User/Edit', user)
            .then(function successCallback() {
                //$location.path('/#!/User/');
                $window.location.href = '/';                
            });
    }
}]);

//app.factory('listUsers', ['$http', function ($http) {
//    return $http.get('http://localhost:57287/User/ListAllUsers')
//        .then(function successCallback(data) {
//            return data;
//        });
//        //.error(function (err) {
//        //    return err;
//        //});
//}]);