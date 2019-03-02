angular.module("app", [])
    .controller("Buy", function($scope,$http) {

        $http({method: "GET", url: "../DateUser"})
            .success(function(date) {
                $scope.user = date;
                $scope.user.phoneCode = $scope.user.phone.substring(0, 2);
                $scope.user.phoneNumb = $scope.user.phone.substring(2, $scope.user.phone.length);
            })
            .error(function(err) {

            });

        $scope.Phone = function(value) {
            if (value != null) {
                $scope.user.phoneCode = $scope.user.phone.substring(0, 2);
                $scope.user.phoneNumb = $scope.user.phone.substring(2, $scope.user.phone.length);
            }
        }

        $scope.Buy = function(value, rtl) {
            if (value == 0) {
                $http({ method: "GET", url: "../AddOrderAll?phone=" + $scope.user.phoneCode + $scope.user.phoneNumb + "&addr=" + $scope.user.address })
                    .success(function(date) {

                    });
            } else {
                $http({ method: "GET", url: "../AddOrder?phone=" + $scope.user.phoneCode + $scope.user.phoneNumb + "&addr=" + $scope.user.address + "&id=" + value + "&rtl = " + rtl })
                    .success(function(date) {


                    });
            }
        }

        $scope.Exit = function(value, rtl) {
            if (value == "-1") {
                $http({
                    method: "GET",
                    url: "../Basket"
                }).success(function(date) {

                });
            }else if (value == "0") {
                $http({
                    method: "GET",
                    url: "../Detail?id=" + value
                }).success(function(date) {

                });
            } else {
                $http({
                    method: "GET",
                    url: "../Cars_Maker?id=" + rtl
                }).success(function (date) {

                });
            }
        }
    })

.directive("buttons", function () {
    return {
        restrict: "E",
        template: '<div class="{{clas}}"><a href="{{link}}" class="{{color}}">{{text}}</a></div>',
        scope: {
            text: "@label",
            link: "@link",
            color: "@color",
            clas: "@clas"
        }
    }
})
