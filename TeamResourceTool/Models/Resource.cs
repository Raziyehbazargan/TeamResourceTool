using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TeamResourceTool.Models
{
    public class Resource
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Active")]
        public bool IsActive { get; set; }

        [Display(Name = "Picture")]
        public byte[] ImageFile { get; set; }


        //Team to Team Member and Role : one to many Relationship mapping
        [Display(Name = "Team")]
        public byte TeamId { get; set; }
        public virtual Team Team { get; set; }


        //Team Member to Role : one to one Relationship mapping
        [Display(Name = "Role")]
        public byte RoleId { get; set; }
        public virtual Role Role { get; set; }


        //Resource to Projects : many to many Relationship mapping
        public virtual ICollection<ProjectResource> ProjectResource { get; set; }
    }
}