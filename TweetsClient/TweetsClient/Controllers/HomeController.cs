using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TweetsClient.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult GetTweets()
        {
            return View();
        }
    }
}
