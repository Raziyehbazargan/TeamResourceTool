using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TeamResourceTool.Dtos
{
    public class ResourceDTO
    {
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public bool IsActive { get; set; }

        public byte[] ImageFile { get; set; }


        //Team to Team Member and Role : one to many Relationship mapping
        public byte TeamId { get; set; }
       // public virtual Team Team { get; set; }


        //Team Member to Role : one to one Relationship mapping
        public byte RoleId { get; set; }
       // public virtual Role Role { get; set; }


        //Resource to Projects : many to many Relationship mapping
        //public virtual ICollection<ProjectResource> ProjectResource { get; set; }
    }
}