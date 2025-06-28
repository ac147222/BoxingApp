using System;
using System.Collections.Generic;
using System.Text;

namespace BoxingApp
{
    public class Gym
    {
        public string GymID { get; set; }
        public string GymName { get; set; }

        public Gym(string GymID, string GymName)
        {
            GymID = GymID;
            GymName = GymName;
        }
    }
}
