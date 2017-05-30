
1. Validation of data is done on reception of data. Data from twitter is manipulated if not in desired form, hence, I am just checking if data is coming into my server.
2. As data is maniupulated, the client will get all data required else the place holders for various items to be displayed will have some proper message.
3. OAuthBase is the file that has the data that has the code to create a signature, this was pulled from the github location - https://gist.github.com/tacoman667/4149849


Important files on server:

oAuthBase.cs
GetTweetsController.cs
TweetDTO.cs
TwitterKeys.cs (the data in this xml is removed to keep my keys secured)



Important files on client:

TweetApp.js
GetTweets.cshtml


Running of client and server:
Server solution : TweetsService
ClientSolution : TweetsClient


TweetsService has to be run first and then the client solution
localhost:*****/gettweets gives the response of the server in a webpage


service is deployed on AWS, can be accessed here: http://tweetsservice-dev.us-west-2.elasticbeanstalk.com/gettweets
Client is deployed on AWS, can be accessed here: http://tweetfeedclient.us-west-2.elasticbeanstalk.com/
