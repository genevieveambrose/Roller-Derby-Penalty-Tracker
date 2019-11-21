using System;
using System.Collections.Generic;
using System.Text;

namespace PenaltyTracker.Models
{
    public class Penalty
    {
        public int PenaltyId { get; set; }
        public string PenaltyType { get; set; }
        public int SkaterNumber { get; set; }
    }
}
