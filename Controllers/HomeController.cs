using BowlingLeague.Models;
using BowlingLeague.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace BowlingLeague.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        //private readonly BowlingLeagueContext context; // this is created at the start and passed to the index file
        private BowlingLeagueContext context { get; set; }

        public HomeController(ILogger<HomeController> logger, BowlingLeagueContext ctx)
        {
            _logger = logger;
            context = ctx;
        }


        public IActionResult Index(long? teamnombre, string TeamName, int pageNum = 0) //can pass the string as a parameter string Blah
        {
            //var bowl = "%Jim%"; // then you can include this with {bowl} in the select string statement
            int pageSize = 5; //5 items per page

            ViewBag.NameTeam = TeamName; //used to display team name in the heading

            return View(new IndexViewModel
            {
                Bowlers = (context.Bowlers
                    .Where(m => m.TeamId == teamnombre || teamnombre == null) //displays bowlers from team if Team selected matches, else display all bowlers
                    .OrderBy(m => m.TeamId)
                    .Skip((pageNum - 1) * pageSize)
                    .Take(pageSize)
                    .ToList()),

                PageNumberingInfo = new PageNumberingInfo
                {
                    NumItemsPerPage = pageSize,
                    CurrentPage = pageNum,
                    //if no team is selected, then get full count, else only count the num from the team selected
                    TotalNumItems = (teamnombre == null ? context.Bowlers.Count() :
                        context.Bowlers.Where(x => x.TeamId == teamnombre).Count())
                },

                TeamTitle = TeamName
                
            });
                
                
                //.FromSqlInterpolated($"SELECT * FROM Bowlers WHERE TeamId = {teamnombre} OR {teamnombre} IS NULL")                                                                                    //.OrderBy(x => x.BowlerFirstName)
                //.ToList());
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
