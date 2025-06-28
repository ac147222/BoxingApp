using System;

namespace BoxingApp
{
    public class Fighter
    {
        public int FighterID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public int RegionID { get; set; }
        public int GymID { get; set; }
        public int WeightclassID { get; set; }
        public int Wins { get; set; }
        public int Losses { get; set; }
        public int Draws { get; set; }

        public Fighter() { }

        public Fighter(int fighterID, string firstName, string lastName, int age, int regionID, int gymID, int weightclassID, int wins, int losses, int draws)
        {
            FighterID = fighterID;
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            RegionID = regionID;
            GymID = gymID;
            WeightclassID = weightclassID;
            Wins = wins;
            Losses = losses;
            Draws = draws;
        }
    }
}