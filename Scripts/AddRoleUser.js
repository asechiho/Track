angular.module("app", [])
    .directive("buttonsnolink", function() {
        return {
            restrict: "E",
            template: '<div class="{{clas}}"><a class="{{color}}" href>{{text}}</a></div>',
            scope: {
                text: "@label",
                color: "@color",
                clas: "@clas"
            }
        }
    })
    .directive("buttons", function() {
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
    .controller("selectrole", function ($scope, $http) {

        $scope.nickname = "";
        $scope.class = "hide";

        $scope.Close = function() {
            $scope.class = "hide";
        }

        $scope.Open = function (name) {
            $http({
                    method: "Get",
                    url: "GetRolesInUser?nickName=" + name
                })
                .success(function(date) {
                    $scope.listRoles = date;
                })
                .error(function(err) {
                    alert(err);
                });
            $scope.nickname = name;
            $scope.class = "";
        }

        $scope.Save = function() {

            $http({ method: "get", url: "AddRoleInUser?nickName=" + $scope.nickname + "&roleName=" + $scope.val });

        }
    });