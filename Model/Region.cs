using System;
using System.Collections.Generic;
using System.Text;

namespace BoxingApp
{
    public class Region
    {
        public int Region_ID { get; set; }
        public string Region_Name { get; set; }
         
        public Region(int RegionID, string RegionName)
        {
            Region_ID = RegionID;
            Region_Name = RegionName;
        }
    }
}
