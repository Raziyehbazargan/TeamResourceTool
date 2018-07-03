using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TeamResourceTool.Models
{
    public class Project
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Project Name")]
        public string Name { get; set; }

        [Required]
        public string Status { get; set; }

        [Display(Name = "Build Start Date")]
        public DateTime? BuildStart { get; set; }

        [Display(Name = "Go Live Date")]
        public DateTime? GoLive { get; set; }

        [Display(Name = "Event Start Date")]
        public DateTime? EventStartDate { get; set; }

        [Display(Name = "Event End Date")]
        public DateTime? EventEndDate { get; set; }

        public string Client { get; set; }

        public string Priority { get; set; }

        [Display(Name = "Build Spec")]
        public string BuildSpecPath { get; set; }

        [Required]
        [Display(Name = "Onsite Demand")]
        public bool NeedOnsiteSupport { get; set; }

        [Display(Name = "Onsite Location")]
        public string EventLocation { get; set; }

        [Display(Name = "General Info")]
        public string Description { get; set; }


        //Team to projects : one to many Relationship mapping
        [Display(Name = "Team")]
        public byte TeamId { get; set; }
        public virtual Team Team { get; set; }


        //Project to Resource : many to many Relationship mapping
        public virtual ICollection<ProjectResource> ProjectResource { get; set; }

    }
}