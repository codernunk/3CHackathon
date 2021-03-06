﻿angular
    .module("app")
    .service("DataService", ["$http", function ($http) {
        var urlBase = "http://localhost:61103/";

        return {
            getFacts: getFacts,
            getDepartments: getDepartments
        };

        function getFacts(search) {
            return $http.get(urlBase + "api/values/searchTerms/", { params: { search: search } })
                .then(getFactsComplete)
                .catch(getFactsFailed);

            function getFactsComplete(response) {
                return response.data;
            }

            function getFactsFailed(error) {
                return console.log("XHR failed" + error.data.message);
            }
        }
        function getRandomQuestion() {
            return $http.get(urlBase + "api/values/getQ/")
                .then(getRandomQuestionComplete)
                .catch(getRandomQuestionFailed);

            function getRandomQuestionComplete(response) {
                return response.data;
            }

            function getRandomQuestionsFailed(error) {
                return console.log("XHR failed" + error.data.message);
            }
        }

        function getDepartments() {
            return $http.get(urlBase + "api/values/getDepartments/")
                .then(getRandomQuestionComplete)
                .catch(getRandomQuestionsFailed);

            function getRandomQuestionComplete(response) {
                return response.data;
            }

            function getRandomQuestionsFailed(error) {
                return console.log("XHR failed" + error.data.message);
            }
        }

    }]);