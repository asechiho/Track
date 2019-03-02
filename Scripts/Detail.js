angular.module("app", [])
    .directive("buttonsnolink", function() {
        return {
            restrict: "E",
            template: '<div class="{{clas}}"><a class="{{color}}">{{text}}</a></div>',
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
    .controller("Commentaries", function($scope, $http) {

        $scope.class = "hide";
        var url = window.location.href;
        var l = url.length-1, str="";
        while (l > 0) {
            if (url[l] != "/") {
                str = url[l] + str;
                l--;
            } else {
                break;
            }
        }
        $scope.id = str;
        $http({ method: "Get", url: "../ReadComments?id=" + $scope.id })
            .success(function(date) {
                $scope.commentaries = date;
                $scope.lengthCom = date.count;
            })
            .error(function(err) {

            });

        $scope.OpenDialog = function() {
            $scope.class = "";
        }

        $scope.CloseDialog = function() {
            $scope.class = "hide";
        };

        $scope.SaveChange = function(product) {
            $http({ method: "Get", url: "../AddComment?id=" + product + "&comment=" + $scope.message })
                .success(function(date) {
                    alert(date);
                    $http({ method: "Get", url: "../Detail?id=" + product });
                })
                .error(function(err) {

                });
        }
    });
