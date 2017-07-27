(function () {
    "use strict";

    angular
        .module("app")
        .controller("LandingPageController", LandingPageController);
 
    LandingPageController.$inject = ["DataService"];

    function LandingPageController(DataService) {
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