using BowlingLeague.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BowlingLeague.Components
{
    public class TeamViewComponent : ViewComponent
    {
        private BowlingLeagueContext context;
        public TeamViewComponent(BowlingLeagueContext ctx) //bring in the context file
        {
            context = ctx;
        }
        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedTeam = RouteData?.Values["TeamName"];

            return View(context.Teams
                .Distinct()
                .OrderBy(x => x));
/*                .Select(x => x.TeamName)
                .Distinct()
                .OrderBy(x => x)
                .ToList());*/
        }
    }
}
