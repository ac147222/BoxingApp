using System;
using System.Collections.Generic;
using System.Text;

namespace BoxingApp
{
    public class Match
    {
        public int MatchID { get; set; }
        public string MatchName { get; set; }
        public DateTime MatchDate { get; set; }
        public Match(int matchID, string matchName, DateTime matchDate)
        {
            MatchID = matchID;
            MatchName = matchName;
            MatchDate = matchDate;
        }
    }
}
