using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TeamResourceTool.Dtos
{
    public class ProjectDTO
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Project Name")]
        public string Name { get; set; }

        [Required]
        public string Status { get; set; }

        [Display(Name = "Build Start Date")]
        public DateTime? BuildStart { get; set; }

        public DateTime? GoLive { get; set; }

        public DateTime? EventStartDate { get; set; }

        public DateTime? EventEndDate { get; set; }

        public string Client { get; set; }

        public string Priority { get; set; }

        public string BuildSpecPath { get; set; }

        [Required]
        public bool NeedOnsiteSupport { get; set; }

        public string EventLocation { get; set; }

        public string Description { get; set; }

        //public IEnumerable<Resource> Resources { get; set; }

        //Team to projects : one to many Relationship mapping
        [Display(Name = "Team")]
        public byte TeamId { get; set; }
       // public virtual Team Team { get; set; }


        //Project to Resource : many to many Relationship mapping
       // public virtual ICollection<ProjectResource> ProjectResource { get; set; }
    }
}