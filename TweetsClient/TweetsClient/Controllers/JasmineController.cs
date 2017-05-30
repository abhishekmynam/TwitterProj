using System;
using System.Web.Mvc;

namespace TweetsClient.Controllers
{
    public class JasmineController : Controller
    {
        public ViewResult Run()
        {
            return View("SpecRunner");
        }
    }
}
