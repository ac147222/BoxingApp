using System;
using System.Collections.Generic;
using System.Text;

namespace BoxingApp
{
    public class OutcomeType
    {
        public int OutcomeTypeID { get; set; }
        public string OutcomeTypeName { get; set; }
        public OutcomeType(int outcomeTypeID, string outcomeTypeName)
        {
            OutcomeTypeID = outcomeTypeID;
            OutcomeTypeName = outcomeTypeName;
        }
    }
}