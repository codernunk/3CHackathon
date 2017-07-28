angular
    .module("app", ["ngMaterial"])
.directive('animationend', function() {
    return {
        restrict: 'A',
        scope: {
            animationend: '&'
        },
        link: function(scope, element) {
            var callback = scope.animationend(),
				  events = 'animationend webkitAnimationEnd MSAnimationEnd' +
						'transitionend webkitTransitionEnd';

            element.on(events, function(event) {
                callback.call(element[0], event);
            });
        }
    };
});