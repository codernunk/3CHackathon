(function () {
    "use strict";

    angular
        .module("app")
        .controller("LandingPageController", LandingPageController);

    LandingPageController.$inject = ["DataService", "TermService", "$mdDialog"];

    function LandingPageController(DataService, TermService, $mdDialog) {
        var vm = this;
        vm.search = "";
        vm.facts = null;
        vm.index = 0;
        vm.currentFact = null;
        vm.quiz = quiz;

        vm.searchTerm = function () {
            vm.index = 0;
            vm.currentFact = null;
            DataService.getFacts(vm.search)
                .then(function (data) {
                    vm.facts = data;
                    console.log(data);

                    if (vm.facts !== null || vm.facts.length > 0) {
                        vm.currentFact = vm.facts[0];
                    }
                    
                    return vm.facts;
                });
        }

        vm.previousTerm = function () {
            if (vm.index - 1 >= 0) {
                vm.index--;
                vm.currentFact = vm.facts[vm.index];
            }
        }

        vm.upvote = function () {
            console.log(vm.currentFact.term_id)
            return TermService.upvote(vm.currentFact.term_id)
                .then(function (data) {
                    vm.currentFact.up_tf = 0;

                    return vm.term;
                });

        }

        vm.downvote = function (ev) {
            var confirm = $mdDialog.prompt()
              .title('Feedback Requested')
              .textContent('Please provide a reason why the term was downvoted.  This will help the user create better questions in the future.  Thank you.')
              .placeholder('Feedback')
              .ariaLabel('Feedback Requested')
              .initialValue('')
              .targetEvent(ev)
              .ok('Submit')
              .cancel('Cancel');

            $mdDialog.show(confirm).then(function (result) {
                return TermService.downvote(vm.currentFact.term_id, result)
                .then(function (data) {
                    vm.currentFact.up_tf = 1;

                    return vm.term;
                });
            }, function () {
            });
        }

        vm.nextTerm = function (ev) {
            if (vm.index + 1 < vm.facts.length) {
                vm.index++;
                vm.currentFact = vm.facts[vm.index];
            }
        }
        function quiz(ev) {
            return showDialog("QuizDialog.template.html", ev);
        }

        function showDialog(template, ev) {
            return $mdDialog.show({
                controller: 'LandingPageController',
                controllerAs: 'vm',
                templateUrl: template,
                parent: angular.element(document.body),
                targetEvent: ev,
                clickOutsideToClose: true
            });
        }
    }
})();