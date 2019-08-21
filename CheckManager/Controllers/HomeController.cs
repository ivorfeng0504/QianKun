using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CheckManager.Models;
using CheckManagerBLL;

namespace CheckManager.Controllers
{
    public class HomeController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var manager = new BllManager();
            Stopwatch sw=new Stopwatch();
            sw.Start();
            var list = await manager.GeBrandInfosAsycn("test");
            sw.Stop();
            var dd = sw.ElapsedMilliseconds;
            sw.Restart();
            var list1 = manager.GeBrandInfos("test");
            sw.Stop();
            var bb=sw.ElapsedMilliseconds;

            return View(list);
        }

        public IActionResult Detail()
        {
            return View();
        }
        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
