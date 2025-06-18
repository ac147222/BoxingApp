using System;
using System.Collections.Generic;
using System.Text;

namespace BoxingApp
{
    public class Match
    {
        public int Match_ID { get; set; }
        public string Match_Name { get; set; }
        public DateTime Match_Date { get; set; }
        public Match(int matchID, string matchName, DateTime matchDate)
        {
            Match_ID = matchID;
            Match_Name = matchName;
            Match_Date = matchDate;
        }
    }
}
