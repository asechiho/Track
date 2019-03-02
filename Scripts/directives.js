angular.module("app", [])

    .directive("required", function () {
        return {
            restrict: "E",
            templateUrl: "Required.html",
            link: function (scope, element, attrs) {
                
            }
        }
    })

    .directive("buttons", function () {
        return {
            restrict: "E",
            template: '<div class="buttons-default"><a href="{{href}}" class="{{color}}">{{text}}</a></div>',
            scope: {
                text: "@label",
                href: "@link",
                color: "@color"
            }
        }
    })