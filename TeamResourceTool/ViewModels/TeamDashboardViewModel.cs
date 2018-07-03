using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TeamResourceTool.Models;

namespace TeamResourceTool.ViewModels
{
    public class TeamDashboardViewModel
    {
        public IEnumerable<Project> BuildProjects { get; set; }

        public IEnumerable<Project> LiveProjects { get; set; }

        public IEnumerable<Project> InProgressProjects { get; set; }
    }
}