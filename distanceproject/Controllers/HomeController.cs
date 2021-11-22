using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using distanceproject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Net.Http;
using Newtonsoft.Json;
using distanceproject.Models;
using distanceproject.Helper;
using System.Text;

namespace distanceproject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        distanceApi _api = new distanceApi();
   public ActionResult Home()
        {
            return View();

        }
        public ActionResult Index()
        {
            return View();

        }

        [HttpPost]
        public async Task<IActionResult> Index(distance dis)
        {
            HttpClient cli = _api.Initial();
            string disnew = JsonConvert.SerializeObject(dis);
            StringContent content = new StringContent(disnew, Encoding.UTF8, "application/json");
            HttpResponseMessage response = cli.PostAsync(cli.BaseAddress + "api/distances", content).Result;
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("List");
            }
            return View();

        }

        public async Task<IActionResult> List()
        {
            List<distance> distanceDatas = new List<distance>();
            HttpClient cli = _api.Initial();
            HttpResponseMessage result = await cli.GetAsync("api/distances");
            if (result.IsSuccessStatusCode)
            {
                var res = result.Content.ReadAsStringAsync().Result;
                distanceDatas = JsonConvert.DeserializeObject<List<distance>>(res);
            }


            return View(distanceDatas);
        }
        
        public async Task<ActionResult> Delete(int id)
        {
            HttpClient cli = _api.Initial();
            HttpResponseMessage response = cli.DeleteAsync("api/distances/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("List");
            }
            return View();


        }
        public async Task<IActionResult> Details(int id)
        {
            var dist = new distance();
            HttpClient cli = _api.Initial();
            HttpResponseMessage result = await cli.GetAsync($"api/distances/{id}");
            if (result.IsSuccessStatusCode)
            {
                var res = result.Content.ReadAsStringAsync().Result;
               dist = JsonConvert.DeserializeObject<distance>(res);
            }
            ViewData["from_lat"] = dist.from_loc_lat;
            ViewData["from_lng"] = dist.from_loc_lng;
            ViewData["to_lat"] = dist.to_location_lat;
            ViewData["to_lng"] = dist.to_location_lng;
          
            return View(dist);
        }
        
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
