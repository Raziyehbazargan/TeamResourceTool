using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace TeamResourceTool.Models
{
    [DataContract]
    public class DataPoint
    {
        //DataContract for Serializing Data - required to serve in JSON format
        public DataPoint(int y, string label)
        {
            this.Y = y;
            this.Label = label;
        }

        [DataMember(Name = "y")]
        public Nullable<int> Y = null;

        //Explicitly setting the name to be used while serializing to JSON.
        [DataMember(Name = "label")]
        public string Label = null;

    }
}