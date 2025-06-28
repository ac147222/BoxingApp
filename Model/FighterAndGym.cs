using System;
using System.Collections.Generic;
using System.Text;

namespace BoxingApp
{
    public class FighterAndGym
    {
        public int FighterAndGymID { get; set; }
        public int FighterID { get; set; }
        public int GymID { get; set; }
        public int TotalWins { get; set; }
        public int TotalLosses { get; set; }
        public int TotalDraws { get; set; }

        public FighterAndGym() { }

        public FighterAndGym(int fighterAndGymID, int fighterID, int gymID, int totalWins, int totalLosses, int totalDraws)
        {
            FighterAndGymID = fighterAndGymID;
            FighterID = fighterID;
            GymID = gymID;
            TotalWins = totalWins;
            TotalLosses = totalLosses;
            TotalDraws = totalDraws;
        }
    }
}