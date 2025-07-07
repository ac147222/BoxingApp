using System;
using System.Collections.Generic;
using System.Text;

namespace BoxingApp.Models
{
    public class OutcomeType
    {
        public int OutcomeID { get; set; }
        public string OutcomeDescription { get; set; }

        public OutcomeType() { }

        public OutcomeType(int outcomeID, string outcomeDescription)
        {
            OutcomeID = outcomeID;
            OutcomeDescription = outcomeDescription;
        }
    }
}