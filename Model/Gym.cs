using System;
using System.Collections.Generic;
using System.Text;

namespace BoxingApp
{
    public class Gym
    {
        public string Gym_ID { get; set; }
        public string Gym_Name { get; set; }

        public Gym(string GymID, string GymName)
        {
            Gym_ID = GymID;
            Gym_Name = GymName;
        }
    }
}
