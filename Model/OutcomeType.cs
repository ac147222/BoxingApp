using System;
using System.Collections.Generic;
using System.Text;

namespace BoxingApp
{
    public class OutcomeType
    {
        public int Outcome_Type_ID { get; set; }
        public string Outcome_Type_Name { get; set; }
        public OutcomeType(int outcomeTypeID, string outcomeTypeName)
        {
            Outcome_Type_ID = outcomeTypeID;
            Outcome_Type_Name = outcomeTypeName;
        }
    }
}