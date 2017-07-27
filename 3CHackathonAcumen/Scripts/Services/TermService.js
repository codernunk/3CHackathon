angular
    .module("app")
    .service("TermService", ["$http", function ($http) {
        var urlBase = "http://localhost:61103/";

        return {
            upvote: upvote,
            downvote: downvote,
            addView: addView
        };

        function upvote(termId) {
            return $http.get(urlBase + "api/values/upvote/", { params: { termId: termId } })
                .then(upvoteComplete)
                .catch(upvoteFailed);

            function upvoteComplete(response) {
                return response.data;
            }

            function upvoteFailed(error) {
                return console.log("XHR failed" + error.data.message);
            }
        }

        function downvote(search) {
            return $http.get(urlBase + "api/values/downvote/", { params: { termId: termId } })
                .then(downvoteComplete)
                .catch(downvoteFailed);

            function downvoteComplete(response) {
                return response.data;
            }

            function downvoteFailed(error) {
                return console.log("XHR failed" + error.data.message);
            }
        }

        function addView(termId) {
            return $http.get(urlBase + "api/values/addview/", { params: { termId: termId } })
                .then(addViewComplete)
                .catch(addViewFailed);

            function addViewComplete(response) {
                return response.data;
            }

            function addViewFailed(error) {
                return console.log("XHR failed" + error.data.message);
            }
        }
    }]);