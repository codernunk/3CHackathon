angular
    .module("app")
    .service("DataService", ["$http", function ($http) {
        var urlBase = "http://localhost:61103/";

        return {
            getFacts: getFacts
        };

        function getFacts(search) {
            return $http.get(urlBase + "api/values/searchTerm/", { params: { search: search } })
                .then(getFactsComplete)
                .catch(getFactsFailed);

            function getFactsComplete(response) {
                return response.data;
            }

            function getFactsFailed(error) {
                return console.log("XHR failed" + error.data.message);
            }
        }
    }]);