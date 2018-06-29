using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TeamResourceTool.Models
{
    public class ProjectResource
    {
        [Key, Column(Order = 0)]
        public int ID { get; set; }

        [Key, Column(Order = 1)]
        public int ProjectID { get; set; }

        [Key, Column(Order = 2)]
        public int ResourceID { get; set; }

        public virtual Project Project { get; set; }

        public virtual Resource Resource { get; set; }

        public bool OnSite { get; set; }

        public string Note { get; set; }

    }
}