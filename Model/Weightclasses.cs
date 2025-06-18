using System;
using System.Collections.Generic;
using System.Text;

namespace BoxingApp
{
    public class Weightclasses
    {
        public string Weightclasses_ID { get; set; }
        public string Weightclasses_Name { get; set; }

        public Weightclasses(string WeightclassesID, string WeightclassesName)
        {
            Weightclasses_ID = WeightclassesID;  
            Weightclasses_Name = WeightclassesName;
        }
    }
}
