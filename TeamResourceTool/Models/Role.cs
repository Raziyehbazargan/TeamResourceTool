using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TeamResourceTool.Models
{
    public class Role
    {
        public byte Id { get; set; }

        [Required]
        [Display(Name = "Role")]
        public string Name { get; set; }
    }
}