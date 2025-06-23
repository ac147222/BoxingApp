using System;
using System.Collections.Generic;
using System.Text;

namespace BoxingApp
{
    public class MatchOutcome
    {
        public int Match_ID { get; set; }
        public int Winner_Fighter_ID { get; set; }
        public int Loser_Fighter_ID { get; set; }
        public DateTime Match_Date { get; set; }
        public MatchOutcome(int matchID, int winnerFighterID, int loserFighterID, DateTime matchDate)
        {
            Match_ID = matchID;
            Winner_Fighter_ID = winnerFighterID;
            Loser_Fighter_ID = loserFighterID;
            Match_Date = matchDate;
        }
    }
}
   