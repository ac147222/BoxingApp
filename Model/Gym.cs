namespace BoxingApp.Models
{
    public class Gym
    {
        public int GymID { get; set; }
        public string GymName { get; set; }

        public Gym(int id, string weightclass)
        {
            GymID = id;
            GymName = weightclass;
        }
    }
}