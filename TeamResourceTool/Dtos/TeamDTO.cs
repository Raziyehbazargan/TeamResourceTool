using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TeamResourceTool.Dtos
{
    public class TeamDTO
    {
        public byte Id { get; set; }

        [Required]
        public string Name { get; set; }

        public byte[] ImageFile { get; set; }
         
        //Team to TeamMembers and projects : one to many Relationship mapping
       // public virtual ICollection<Resource> TeamMembers { get; set; }

       /// public virtual ICollection<Project> Projects { get; set; }
    }
}