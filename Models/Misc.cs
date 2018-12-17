using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HandItDown.Models
{
    public class Misc
    {


        [Key]
        public int MiscId { get; set; }


        [Required]
        [StringLength(255)]
        public string Description { get; set; }


        [Required]
        public int Quantity { get; set; }

        public string Color { get; set; }

        [Required]
        public ApplicationUser User { get; set; }

        [Required]
        public string UserId { get; set; }

        public string ImagePath { get; set; }

        [Required]
        public int StatusId { get; set; }
    }
}
