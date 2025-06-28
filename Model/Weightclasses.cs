using System;
using System.Collections.Generic;
using System.Text;

namespace BoxingApp
{
    public class Weightclasses
    {
        public string WeightclassesID { get; set; }
        public string WeightclassesName { get; set; }
        public int WeightclassesID1 { get; }

        public Weightclasses(string WeightclassesID, string WeightclassesName)
        {
            WeightclassesID = WeightclassesID;  
            WeightclassesName = WeightclassesName;
        }

        
    }
}
