(function () {
    "use strict";

    angular
        .module("app")
        .controller("LandingPageController", LandingPageController);
 
    LandingPageController.$inject = ["DataService", "TermService"];

    function LandingPageController(DataService, TermService) {
        var vm = this;
        vm.search = "";
        vm.termId = "";

        vm.upvote = upvote;
        vm.searchFact = searchFact;


        function searchFact() {
            return DataService.getFacts(vm.search)
                .then(function (data) {
                    vm.facts = data;
                    console.log(data);
                    return vm.facts;
                });

        }

        function upvote() {
            return TermService.getFacts(vm.termId)
                .then(function (data) {
                    vm.term = data;
                    console.log(data);
                    return vm.term;
                });

        }
    }

})();