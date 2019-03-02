angular.module("app", [])
    .controller("BasketCtrl", function($scope, $http) {

        var id = JSON.parse(localStorage.getItem("id"));

        $http({ method: "GET", url: "GetItemBasket", param: { ids: id } })
            .success(function(date) {
                $scope.product = date;
            })
            .error(function(err) {
                console.log("error download item: ", err);
            });
    });
