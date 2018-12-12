using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HandItDown.Models
{
    public class Group
    {
        [Key]
        public int GroupId { get; set; }

        [Required]
        [Display(Name = "Group Name")]
        public string GroupName { get; set; }
    }
}
