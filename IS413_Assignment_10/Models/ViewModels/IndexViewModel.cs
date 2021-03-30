using System;
using System.Collections.Generic;

namespace IS413_Assignment_10.Models.ViewModels
{
    public class IndexViewModel
    {
        public IndexViewModel()
        {
        }

        public List<Bowler> Bowlers { get; set; }

        public PageNumberInfo PageNumberInfo { get; set; }

        public string Team { get; set; }
    }
}
