(function () {
    "use strict";

    angular
        .module("app")
        .controller("LandingPageController", LandingPageController);
 
    LandingPageController.$inject = ["DataService"];

    function LandingPageController(DataService) {
        var vm = this;
        vm.search = "";
        vm.facts = null;
        vm.index = 0;
        vm.termId = "2";

        vm.currentFact = null;

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
            if (vm.index - 1 > 0) {
                vm.index--;
                vm.currentFact = vm.facts[vm.index];
            }
        }
        function upvote() {
            return TermService.upvote(vm.termId)
                .then(function (data) {
                    vm.term = data;
                    console.log(data);
                    return vm.term;
                });

        }

        vm.nextTerm = function () {
            if (vm.index + 1 < vm.facts.length) {
                vm.index++;
                vm.currentFact = vm.facts[vm.index];
            }
        }
    }
})();