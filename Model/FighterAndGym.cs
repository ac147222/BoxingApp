using System;
using System.Collections.Generic;
using System.Text;

namespace BoxingApp
{
    public class FighterAndGym
    {
        public int Fighter_ID { get; set; }
        public string Fighter_Name { get; set; }
        public int Region_ID { get; set; }
        public string Region_Name { get; set; }
        public FighterAndGym(int fighterID, string fighterName, int regionID, string regionName)
        {
            Fighter_ID = fighterID;
            Fighter_Name = fighterName;
            Region_ID = regionID;
            Region_Name = regionName;
        }
    }
}