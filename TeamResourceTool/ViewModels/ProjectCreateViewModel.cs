using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TeamResourceTool.Models;

namespace TeamResourceTool.ViewModels
{
    public class ProjectCreateViewModel
    {
        public IEnumerable<Team> Teams { get; set; }

        public Project Project { get; set; }

        public string[] StatusList = { "Active", "Closed", "Pending / Hold", "Cancelled" };


    }
}