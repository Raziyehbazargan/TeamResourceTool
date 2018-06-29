using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TeamResourceTool.Models;

namespace TeamResourceTool.ViewModels
{
    public class AssignResource
    {
        public IEnumerable<Resource> Resources { get; set; }
        public ProjectResource ProjectResource { get; set; }
    }
}