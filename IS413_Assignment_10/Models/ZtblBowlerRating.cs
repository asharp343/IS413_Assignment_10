using System;
using System.Collections.Generic;

#nullable disable

namespace IS413_Assignment_10.Models
{
    public partial class ZtblBowlerRating
    {
        public string BowlerRating { get; set; }
        public long? BowlerLowAvg { get; set; }
        public long? BowlerHighAvg { get; set; }
    }
}
