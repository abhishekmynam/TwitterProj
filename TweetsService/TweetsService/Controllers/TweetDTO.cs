using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TweetsService.Controllers
{
    public class TweetDTO
    {
        public string userName;
        public string screenName;
        public string userImage;
        public List<string> tweetImage;
        public string tweetText;
        public int retweets;
        public string tweetDate;
    }
}
