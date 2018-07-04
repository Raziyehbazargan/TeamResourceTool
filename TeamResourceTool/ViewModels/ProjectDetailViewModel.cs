using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TeamResourceTool.Models;

namespace TeamResourceTool.ViewModels
{
    public class ProjectDetailViewModel
    {
        public Project Project { get; set; }

        public IEnumerable<Resource> Resources { get; set; }

        public IEnumerable<Resource> OnsiteResources { get; set; }
    }
}