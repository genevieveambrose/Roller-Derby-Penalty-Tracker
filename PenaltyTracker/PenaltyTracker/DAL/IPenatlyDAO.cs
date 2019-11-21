using PenaltyTracker.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PenaltyTracker.DAL
{
    public interface IPenatlyDAO
    {
        // returns a skater's penalties
        IList<Penalty> ShowPenalties(int skaterNumber);

        // returns a type of penalty
        IList<Penalty> ShowTypePenalties(string penaltyType);

        // adds a skater penalty
        bool AddPenalty(int skaterNumber, string penaltyType);

        // shows ALL penalties of all types
        IList<Penalty> ShowAllPenalties();

    }
}
