//describe('My App Tests', function () {
//    beforeEachModule(module('MyApp'));
//    describe('GetTweets', function () {
//        var getTweets;
//        afterEach(function () {
//            $httpBackend.verifyNoOutstandingExpectation();
//            $httpBackend.verifyNoOutstandingRequest();
//        });
//        beforeEach(inject(function ($filter) {
//            $httpBackend.expectGET('data.json').respond({
//                "userName": "SalesForce",
//                "screenName": "salesforce"
//            });
//            tweets.loadJson();
//            $httpBackend.flush();
//            expect(tweets.length).toEqual("10");
//        }));
//        it("getTweets", function () {
//            $httpBackend.expectGET('data.json').respond({
//                "userName": "SalesForce",
//                "screenName": "salesforce"
//            });
//            tweets.loadJson();
//            $httpBackend.flush();
//            expect(tweets[0].userName).toEqual("SalesForce");
//        });
//    });
//});