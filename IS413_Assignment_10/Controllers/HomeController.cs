using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using IS413_Assignment_10.Models;
using IS413_Assignment_10.Models.ViewModels;

namespace IS413_Assignment_10.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private BowlingLeagueContext context { get; set; }

        public HomeController(ILogger<HomeController> logger, BowlingLeagueContext context)
        {
            _logger = logger;
            this.context = context;
        }

        public IActionResult Index(long? teamid, string team,int pageNum = 0)
        {
            ViewBag.SelectedTeamId = teamid;
            int pageSize = 5;

            return View(new IndexViewModel
            {
                Bowlers = context.Bowlers
                .Where(m => m.TeamId == teamid || teamid == null)
                .OrderBy(m => m.BowlerFirstName)
                .Skip((pageNum - 1) * pageSize)
                .Take(pageSize)
                .ToList(),

                PageNumberInfo = new PageNumberInfo
                {
                    NumItemsPerPage = pageSize,
                    CurrentPage = pageNum,

                    // If no mealtype has been selected in the filter get the full count. Otherwise, only count the number from the mealtype that has been selected
                    TotalNumItems = (teamid == null ? context.Bowlers.Count() : context.Bowlers.Where(x => x.TeamId == teamid).Count())
                },

                Team = team
            });
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
