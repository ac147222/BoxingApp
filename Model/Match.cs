namespace BoxingApp.Models
{
    public class Match
    {
        public int MatchID { get; set; }
        public int Fighter1ID { get; set; }
        public int Fighter2ID { get; set; }
        public DateTime MatchDate { get; set; }

        public Match(int matchID, int fighter1ID, int fighter2ID, DateTime matchDate)
        {
            MatchID = matchID;
            Fighter1ID = fighter1ID;
            Fighter2ID = fighter2ID;
            MatchDate = matchDate;
        }
    }
}