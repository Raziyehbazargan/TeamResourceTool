using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TeamResourceTool.Models
{
    public class Team
    {
        public byte Id { get; set; }

        [Required]
        [Display(Name = "Team Name")]
        public string Name { get; set; }

        [Display(Name = "Team Logo")]
        public byte[] ImageFile { get; set; }


        //Team to TeamMembers and projects : one to many Relationship mapping
        public virtual ICollection<Resource> TeamMembers { get; set; }

        public virtual ICollection<Project> Projects { get; set; }
    }
}