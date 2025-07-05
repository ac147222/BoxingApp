using System;
using System.Collections.Generic;
using System.Text;

namespace BoxingApp
{
    public class Weightclasses
    {
        private int weightclasses_ID;
        private string? weightclasses_Name;

        public string WeightclassesID { get; set; }
        public string WeightclassesName { get; set; }
        public int WeightclassesID1 { get; }

        public Weightclasses(string WeightclassesID, string WeightclassesName)
        {
            WeightclassesID = WeightclassesID;  
            WeightclassesName = WeightclassesName;
        }

        public Weightclasses(int weightclasses_ID, string? weightclasses_Name)
        {
            this.weightclasses_ID = weightclasses_ID;
            this.weightclasses_Name = weightclasses_Name;
        }
    }
}
