using PenaltyTracker.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PenaltyTracker.DAL
{
    public interface ISkaterDAO
    {
        // returns a list of skaters
        IList<Skater> ShowSkaters();

        //adds a new skater
        int AddSkater(Skater newSkater);

        //updates a skater name
        bool UpdateSkater(Skater updatedSkater);

        //searches for a skater
        IList<Skater> Search(int skaterNumber);

        //removes a skater from the roster
        bool RemoveSkater(int skaterNumber);
    }
}
