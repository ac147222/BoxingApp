using System;
using System.Collections.Generic;
using System.Text;

namespace BoxingApp
{
    public class Weightclasses
    {
        public string Weightclasses_ID { get; set; }
        public string Weightclasses_Name { get; set; }
        public int Weightclasses_ID1 { get; }

        public Weightclasses(string WeightclassesID, string WeightclassesName)
        {
            Weightclasses_ID = WeightclassesID;  
            Weightclasses_Name = WeightclassesName;
        }

        public Weightclasses(int weightclasses_ID, string? weightclasses_Name)
        {
            Weightclasses_ID1 = weightclasses_ID;
            Weightclasses_Name = weightclasses_Name;
        }
    }
}
