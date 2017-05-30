using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TweetsService;
using TweetsService.Controllers;

namespace TweetsService.Tests.Controllers
{
    [TestClass]
    public class GetTweetsControllerTest
    {
        [TestMethod]
        public void Get()
        {
            GetTweetsController controller = new GetTweetsController();

            IEnumerable<TweetDTO> result = controller.GetTweets();
            
            Assert.IsNotNull(result);
            
        }
    }
}
