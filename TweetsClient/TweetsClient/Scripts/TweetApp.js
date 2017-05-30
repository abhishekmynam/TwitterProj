/// <reference path="../../Scripts/angular.js" />
var curApp = angular.module("MyApp", []);
curApp.service('TwitterService', function ($http) {
    var baseUrl = "http://tweetsservice-dev.us-west-2.elasticbeanstalk.com";

    this.getTweets = function () {
        return $http.get(baseUrl + '/GetTweets');
    };

});
curApp.controller("MainController", function ($scope, TwitterService, $interval) {
    
    $scope.message = "Twitter did not return data";
    $scope.tweets = TwitterService.getTweets();

    var getTweets = function () {
        TwitterService.getTweets().then(function (tweets) { $scope.tweets = tweets.data; })
        .catch(function (error) { $scope.status = 'unable to load tweets, error message: ' + error.message; })
    }
    getTweets();
    $interval(getTweets, 60000);
});


