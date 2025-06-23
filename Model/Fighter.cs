using System;
using System.Collections.Generic;
using System.Text;

namespace BoxingApp
{
    public class Fighter
    {
        public int Fighter_ID { get; set; }
        public string Fighter_Name { get; set; }
        public int Region_ID { get; set; }
        public Fighter(int fighterID, string fighterName, int regionID)
        {
            Fighter_ID = fighterID;
            Fighter_Name = fighterName;
            Region_ID = regionID;
        }
    }

}
 