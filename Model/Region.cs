using System;
using System.Collections.Generic;
using System.Text;

namespace BoxingApp
{
    public class Region
    {
        public int RegionID { get; set; }
        public string RegionName { get; set; }
         
        public Region(int regionID, string regionName)
        {
            RegionID = regionID;
            RegionName = regionName;
        }
    }
}
