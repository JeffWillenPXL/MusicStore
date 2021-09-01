using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MusicStore.Web.Models;
using MusicStore.Web.Services;

namespace MusicStore.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IFileProvider _fileProvider;

        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        //public IActionResult Index()
        //{
        //    return View();
        //}

        //public IActionResult Privacy()
        //{
        //    return View();
        //}

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}

        public HomeController(IFileProvider fileProvider)
        {
            _fileProvider = fileProvider;
        }

        public IActionResult Index()
        {
            var result = new ContentResult
            {
                Content = $"{RouteData.Values["controller"]}:{RouteData.Values["action"]}"
            };
            return result;
        }

        public IActionResult About()
        {
            var result = new ContentResult
            {
                Content = $"{RouteData.Values["controller"]}:{RouteData.Values["action"]}"
            };
            return result;
        }

        public IActionResult Details(int id)
        {
            var result = new ContentResult
            {
                Content = $"{RouteData.Values["controller"]}:{RouteData.Values["action"]}:{id}"
            };
            return result;
        }

        public IActionResult Search(string genre)
        {
            switch (genre)
            {
                case "Rock":
                    return RedirectPermanent("https://www.youtube.com/watch?v=v2AC41dglnM");
                case "Jazz":
                    return RedirectToAction("Index");
                case "Metal":
                    int id = new Random().Next();
                    return RedirectToAction("Details", id);
                case "Classic":
                    return File(_fileProvider.GetFileBytes("site.css"), "text/css");
                default:
                    return Content($"{RouteData.Values["controller"]}:{RouteData.Values["action"]}:{genre}");
            }
        }
    }
}
