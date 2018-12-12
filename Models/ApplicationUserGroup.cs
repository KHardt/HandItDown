using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HandItDown.Models
{
    public class ApplicationUserGroup
    {
        [Key]
        public int ApplicationUserGroupId { get; set; }


        [Required]
        public ApplicationUser {get; set;}
 
       
        [Required]
        public int GroupId { get; set; }

        public Group Group { get; set; }


    }
}
