using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Xml;
using System.Web;
using System.Web.Mvc;
using OAuth;
using System.IO;
using System.Text;
using Newtonsoft.Json.Linq;
using System.Web.Script.Serialization;
using System.Web.Http.Cors;

namespace TweetsService.Controllers
{
    [EnableCorsAttribute("*","*","*")]
    public class GetTweetsController : ApiController
    {
        public IEnumerable<TweetDTO> GetTweets()
        {
            List<TweetDTO> tweetList = new List<TweetDTO>();
            try{
                string url = "https://api.twitter.com/1.1/statuses/user_timeline.json" + "?screen_name=salesforce&count=10";
                string header = getHeader(url, "GET");
                var webReq = (HttpWebRequest)WebRequest.Create(url);
                webReq.Headers.Add("Authorization", header);
                

                using (HttpWebResponse webResp = (HttpWebResponse)webReq.GetResponse())
                {
                    Stream tweetStream = webResp.GetResponseStream();
                    var tweetRead = new StreamReader(tweetStream);
                    JavaScriptSerializer js = new JavaScriptSerializer();
                    var tweets = js.Deserialize<dynamic>(tweetRead.ReadToEnd());
                    TweetDTO tempTweet = null;
                    foreach (var i in tweets)
                    {
                        tempTweet = new TweetDTO();
                        tempTweet.userName = i.ContainsKey("user") ? (i["user"].ContainsKey("name") ? i["user"]["name"] : "") : "";
                        tempTweet.screenName = i.ContainsKey("user") ? (i["user"].ContainsKey("screen_name") ? i["user"]["screen_name"] : "") : "";
                        tempTweet.retweets = i.ContainsKey("retweet_count") ? i["retweet_count"] : 0;
                        tempTweet.tweetDate = i["created_at"].Split('+')[0];
                        tempTweet.userImage = i.ContainsKey("user") ? (i["user"].ContainsKey("profile_image_url") ? i["user"]["profile_image_url"] : "") : "";
                        tempTweet.tweetText = i.ContainsKey("text") ? i["text"] : "";
                        List<string> images = new List<string>();
                        foreach (var s in i.ContainsKey("entities") ? (i["entities"].ContainsKey("media") ? i["entities"]["media"] : new List<string>()) : new List<string>())
                        {
                            images.Add(s["media_url"]);
                        }
                        tempTweet.tweetImage = images;
                        tweetList.Add(tempTweet);
                    }
                }
            
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return tweetList;
        }
        
        public string getHeader( string url,string method)
        {
            TwitterKeys keys = new TwitterKeys();
            string consumerKey = keys.ConsumerKey;
            string consumerSecret = keys.ConsumerSecret;
            string authToken = keys.AuthToken;
            string authSecret = keys.AuthTokenSecret;
            
            Random random = new Random();
            string randNo = random.Next(123400, 9999999).ToString();


            string uri = "", parameters = "";
            OAuthBase oAuth = new OAuthBase();
            string timeStamp = oAuth.GenerateTimeStamp();
            string signature = oAuth.GenerateSignature(new Uri(url), consumerKey, consumerSecret, authToken, authSecret, method, timeStamp, randNo, out uri, out parameters);
            string auth = "";


            auth = "OAuth ";
            auth += @"oauth_consumer_key=""" + HttpUtility.UrlEncode(consumerKey) + @""",";
            auth += @"oauth_nonce=""" + HttpUtility.UrlEncode(randNo) + @""",";
            auth += @"oauth_signature=""" + HttpUtility.UrlEncode(signature) + @""",";
            auth += @"oauth_signature_method=""" + "HMAC-SHA1" + @""",";
            auth += @"oauth_timestamp=""" + timeStamp + @""",";
            auth += @"oauth_token=""" + HttpUtility.UrlEncode(authToken) + @""",";
            auth += @"oauth_version=""" + @"1.0""";
            
            return auth;
        }


        
    }
}