angular.module("app", [])
    .controller("userCtrl", function ($scope, $http) {

        $scope.errConfirm = "false";
        angular.element(document.querySelector("#errPas")).removeClass("show-err");
        angular.element(document.querySelector("#errPas")).addClass("hide-err");

        $scope.SavePass = function (Valid) {

            if (Valid.$valid) {
                $http({
                        method: "GET",
                        url: "../ValidPassword?nickname=" + angular.element(document.querySelector("#user")).text() + "&password=" + $scope.oldPass
                    })
                    .success(function(date) {
                        $scope.err = date;
                        if ($scope.err == "Ok") {

                            alert("Password Changed");
                            $scope.pass = null;
                            $scope.errConfirm = "false";

                            angular.element(document.querySelector("#change")).removeClass("disabled");
                            $scope.errPas = "false";

                        } else if ($scope.err == "Fail") {

                            $scope.errPas = "true";
                            $scope.errPasMes = "Incorrect password";
                        } else {

                            $scope.errConfirm = "false";
                            $scope.errPas = "true";
                            $scope.errPasMes = "Incorrect password";
                        }
                    })
                    .error(function(err) {
                        Console.log("error ", err);
                    });
            } else {
                $scope.errConfirm = "false";

                if ($scope.newPass != $scope.conPass) {

                    $scope.errConfirm = "true";
                    return;
                }
            }
        }

        $scope.NonChangePass = function () {
            $scope.pass = null;
            angular.element(document.querySelector("#change")).removeClass("disabled");
        }

        $scope.ChangePass = function () {
            $scope.pass = "true";
            angular.element(document.querySelector("#change")).addClass("disabled");
        }

        $scope.NonEdit = function () {
            $scope.posts = 1;
        }

        $scope.Edit = function () {
            $scope.posts = 2;
        };

    })