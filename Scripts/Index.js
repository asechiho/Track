angular.module("app", [])
    .controller("IndexMakers", function($scope, $http) {

        $http({ method: "GET", url: "GetMakers", param: { sql: "" } })
            .success(function(date) {
                $scope.makers = date;
            })
            .error(function(err) {
                Console.log("error ", err);
            });

    })

    .controller("Reviews", function($scope, $http) {

        $http({ method: "Get", url: "ReadCommentsIndex" })
            .success(function(date) {
                $scope.comments = date;
            })
            .error(function(err) {
                alert(err);
            });
    })