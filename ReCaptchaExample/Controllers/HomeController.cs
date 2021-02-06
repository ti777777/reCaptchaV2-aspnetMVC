using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace ReCaptchaExample.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public string Login(string uid,string password,string g)
        {
            HttpClient client = new HttpClient();
            var values = new Dictionary<string, string>
            {
                { "secret", "6Lckr0waAAAAALpIl2TVtG8Nf6plHY0ug5xyMvNb" },
                { "response", g },
            };

            var content = new FormUrlEncodedContent(values);

            return client.PostAsync("https://www.google.com/recaptcha/api/siteverify", content).Result.Content.ReadAsStringAsync().Result;

        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}