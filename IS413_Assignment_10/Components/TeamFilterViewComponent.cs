using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using IS413_Assignment_10.Models;

// View component for team filter

namespace IS413_Assignment_10.Components
{
    public class TeamFilterViewComponent : ViewComponent
    {
        private BowlingLeagueContext context { get; set; }

        public TeamFilterViewComponent(BowlingLeagueContext context)
        {
            this.context = context;
        }

        public IViewComponentResult Invoke()
        {

            return View(context.Teams
                .Distinct()
                .OrderBy(x => x));
        }
    }
}