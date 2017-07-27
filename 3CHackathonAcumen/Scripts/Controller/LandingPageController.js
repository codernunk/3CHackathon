(function () {
    "use strict";

    angular
        .module("app")
        .controller("LandingPageController", LandingPageController);

    function LandingPageController() {
        var vm = this;
        vm.search = "";
        vm.facts = "";

        vm.searchFact = searchFact;

        function searchFact() {
            return DataService.getFacts(vm.search)
                .then(function (data) {
                    vm.facts = data;
                    console.log(data);
                    return vm.facts;
                });
        }
    }
})();