using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace TeamResourceTool.Models.Chart
{
    [DataContract]
    public class TeamProjectsDataPoint
    {
        //DataContract for Serializing Data - required to serve in JSON format
        public TeamProjectsDataPoint(int y, string indexLabel)
        {
            this.Y = y;
            this.IndexLabel = indexLabel;
        }

        [DataMember(Name = "y")]
        public Nullable<int> Y = null;

        //Explicitly setting the name to be used while serializing to JSON.
        [DataMember(Name = "indexLabel")]
        public string IndexLabel = null;

    }
}