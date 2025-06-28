using System;
using System.Collections.Generic;
using System.Text;


namespace BoxingApp
{
    public class MatchOutcome
    {
        public int MatchOutcomeID { get; set; }
        public int MatchID { get; set; }
        public int? WinnerID { get; set; }
        public int OutcomeID { get; set; }

        public MatchOutcome() { }

        public MatchOutcome(int matchOutcomeID, int matchID, int? winnerID, int outcomeID)
        {
            MatchOutcomeID = matchOutcomeID;
            MatchID = matchID;
            WinnerID = winnerID;
            OutcomeID = outcomeID;
        }
    }
}